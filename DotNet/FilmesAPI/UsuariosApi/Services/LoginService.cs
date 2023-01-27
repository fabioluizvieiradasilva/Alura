using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private readonly TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest loginRequest)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(loginRequest.UserName, loginRequest.Password, false, false);
            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(
                    user => user.NormalizedUserName == loginRequest.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);

            }

            return Result.Fail("Falha ao logar.");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);

            if (identityUser != null)
            {
                string codigoDeRecuperacao = _signInManager
                    .UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefinição de senha");
        }

        private IdentityUser<int> RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager
                .UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        public Result ResetSenhaUsuario(ResetSenhaRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);
            IdentityResult identityResult = _signInManager
                .UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password).Result;
            if (identityResult.Succeeded)
                return Result.Ok().WithSuccess("Senha redefinida com sucesso");

            return Result.Fail("Erro na redefinição de senha");
        }
    }
}
