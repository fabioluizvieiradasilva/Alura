using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private readonly FilmeContext _context;
        private IMapper _mapper;

        public SessaoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionarSessao(CreateSessaoDto createSessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(createSessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }
        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
                return null;

            ReadSessaoDto readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return readSessaoDto;
        }
    }

}
