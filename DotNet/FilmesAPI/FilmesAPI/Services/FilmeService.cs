using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Filme;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if(classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes == null)
                return null;

            List<ReadFilmeDto> readFilmeDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
            return readFilmeDto;
            
        }

        public ReadFilmeDto RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(fl => fl.Id == id);
            if (filme == null)
                return null;

            ReadFilmeDto readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return readFilmeDto;
            
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(fl => fl.Id == id);
            if (filme == null)
                return Result.Fail("Filme não encontrado");

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result RemoverFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(fl => fl.Id == id);
            if (filme == null)
                return Result.Fail("Filme não encontrado");
            
            _context.Remove(filme);
            _context.SaveChanges();            
            return Result.Ok();
        }
    }
}
