using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosApi.Data.Dto;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastroUsuario(CreateUsuarioDto createUsuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(usuario);
                
            var resultadoIdentity = _userManager.CreateAsync(identityUser, createUsuarioDto.Password);            
            if (resultadoIdentity.Result.Succeeded)
            {
                var codigoConfirmacao = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;

                var encodedCode = HttpUtility.UrlEncode(codigoConfirmacao);

                _emailService.EnviarEmail(new[] {identityUser.Email}, "Link de Ativação", identityUser.Id, encodedCode);
                
                return Result.Ok().WithSuccess(codigoConfirmacao);
            }

            return Result.Fail("Falha ao cadastrar usuario");
        }

        public Result AtivaContaUsuario(AtivaContaRequest ativaContaRequest)
        {
            var identityUser = _userManager.Users.FirstOrDefault(user => user.Id == ativaContaRequest.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, ativaContaRequest.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
                return Result.Ok();

            return Result.Fail("Falha ao ativar conta do usuário");
        }
    }
}
