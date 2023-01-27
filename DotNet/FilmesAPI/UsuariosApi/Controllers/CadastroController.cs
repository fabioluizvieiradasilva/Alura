using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dto;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController: ControllerBase
    {
        private readonly CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            Result result = _cadastroService.CadastroUsuario(createUsuarioDto);
            if (result.IsFailed)
                return StatusCode(500);
            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest ativaContaRequest)
        {
            Result result = _cadastroService.AtivaContaUsuario(ativaContaRequest);
            if (result.IsFailed)
                return StatusCode(500);

            return Ok(result.Successes);
        }
    }
}
