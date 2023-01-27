using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Filme;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController: ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;            
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDTO)
        {
            ReadFilmeDto readFilmeDto = _filmeService.AdicionaFilme(filmeDTO);

            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = readFilmeDto.Id }, readFilmeDto);
        }
        
        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readFilmeDto =  _filmeService.RecuperaFilmes(classificacaoEtaria);
            if(readFilmeDto == null)
                return NotFound();

            return Ok(readFilmeDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            ReadFilmeDto readFilmeDto = _filmeService.RecuperaFilmePorId(id);            
            if(readFilmeDto == null)
                return NotFound();        
            
            return Ok(readFilmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result result = _filmeService.AtualizaFilme(id, filmeDto);
            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverFilme(int id)
        {
            Result result = _filmeService.RemoverFilme(id);
            if (result.IsFailed)
                return NotFound();            

            return NoContent();
        }
    }
}
