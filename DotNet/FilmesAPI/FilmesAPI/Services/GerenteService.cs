using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Gerente;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public GerenteService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadGerenteDto> RecuperaGerentes()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();
            if (gerentes == null)
                return null;

            return _mapper.Map<List<ReadGerenteDto>>(gerentes);
        }
        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            if (gerente == null)
                return null;
            
            ReadGerenteDto readGerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
            return readGerenteDto;
        }
        public ReadGerenteDto AdicionaGerente(CreateGerenteDto createGerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(createGerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }
        public Result RemoveGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
                return Result.Fail("Gerente não encontrado");

            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
        
    }
}
