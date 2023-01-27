using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController: ControllerBase
    {
        private readonly CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;            
        }        

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string? nomeDoFilme)
        {
            List<ReadCinemaDto> cinemaDto = _cinemaService.RecuperaCinemas(nomeDoFilme);
            if (cinemaDto == null)
                return NotFound();

            return Ok(cinemaDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.RecuperaCinemaPorId(id);
            
            if(readCinemaDto == null)
                return NotFound();
            
            return Ok(readCinemaDto);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.AdicionarCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperaCinemaPorId), new {Id = readCinemaDto.Id}, readCinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
        {
            Result result = _cinemaService.AtualizaCinema(id, updateCinemaDto);
            if(result.IsFailed)
                return NotFound();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCinema(int id)
        {
            Result result = _cinemaService.RemoverCinema(id);
            
            if (result.IsFailed)
                return NotFound();            
            
            return NoContent();
        }

    }
}
