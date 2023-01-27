using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController: ControllerBase
    {
        private readonly SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto createSessaoDto)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.AdicionarSessao(createSessaoDto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readSessaoDto.Id }, readSessaoDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.RecuperaSessaoPorId(id);            
            if(readSessaoDto == null)
                return NotFound();
            
            return Ok(readSessaoDto);
        }
    }
}
