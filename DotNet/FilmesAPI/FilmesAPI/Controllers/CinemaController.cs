using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController: ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Cinema> RecuperarCinema()
        {
            return _context.Cinemas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
                return NotFound();

            ReadCinemaDto readCinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(readCinemaDto);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new {Id = cinema.Id}, cinema);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return NotFound();

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return Ok(cinema);
        }
    }
}
