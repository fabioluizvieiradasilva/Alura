using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadCinemaDto>RecuperaCinemas(string? nomeDoFilme)
        {
            List<Cinema> cinemas = new List<Cinema>();

            if (string.IsNullOrEmpty(nomeDoFilme))
            {
                return null;
            }
            else
            {
                IEnumerable<Cinema> query = from cinema in _context.Cinemas
                                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return null;

            ReadCinemaDto readCinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return readCinemaDto;
        }

        public Result RemoverCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return Result.Fail("Cinema não encontrado.");

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto updateCinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                Result.Fail("Cinema não encontrado");
            
            _mapper.Map(updateCinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public ReadCinemaDto AdicionarCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }
    }
}
