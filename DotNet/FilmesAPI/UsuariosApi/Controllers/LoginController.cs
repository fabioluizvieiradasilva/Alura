using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest loginRequest)
        {
            Result result = _loginService.LogaUsuario(loginRequest);
            if(result.IsFailed)
                return Unauthorized(result.Errors.FirstOrDefault());

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result result = _loginService.SolicitaResetSenhaUsuario(request);
            
            if(result.IsFailed)
                return Unauthorized(result.Errors?.FirstOrDefault());
            
            return Ok(result.Successes?.FirstOrDefault());
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetSenhaUsuario(ResetSenhaRequest request)
        {
            Result result = _loginService.ResetSenhaUsuario(request);

            if (result.IsFailed)
                return Unauthorized(result.Errors?.FirstOrDefault());

            return Ok(result.Successes?.FirstOrDefault());
        }
    }
}
