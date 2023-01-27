using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Gerente;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController: ControllerBase
    {
        private readonly GerenteService _gerenteService;
        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            List<ReadGerenteDto> gerenteDto = _gerenteService.RecuperaGerentes();
            return Ok(gerenteDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerenteId(int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperaGerentePorId(id);
            if(readGerenteDto == null)
                return NotFound();
            
            return Ok(readGerenteDto);
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto createGerenteDto)
        {
            ReadGerenteDto gerenteDto = _gerenteService.AdicionaGerente(createGerenteDto);
            return CreatedAtAction(nameof(RecuperaGerenteId), new { Id = gerenteDto.Id }, gerenteDto);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverGerente(int id)
        {
            Result result = _gerenteService.RemoveGerente(id);
            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
