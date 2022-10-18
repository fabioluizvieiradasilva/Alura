using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Gerente;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController: ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperaGerente()
        {
            return _context.Gerentes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerenteId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente == null)
                return NotFound();

            ReadGerenteDto readGerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
            return Ok(readGerenteDto);
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerenteId), new { Id = gerente.Id }, gerente);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            if (gerente == null)
                return NotFound();
            _context.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
