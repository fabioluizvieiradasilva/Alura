using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Endereco;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public EnderecoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto createEnderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(createEnderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);

        }
        public List<ReadEnderecoDto>RecuperaEnderecos()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            if (enderecos == null)
                return null;
            
            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);

        }
        public ReadEnderecoDto RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
                return null;

            ReadEnderecoDto readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return readEnderecoDto;

        }
        public Result AtualizaEndereco(int id, UpdateEnderecoDto updateEnderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
                return Result.Fail("Endereço não encontrado.");

            _mapper.Map(updateEnderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
        public Result RemoveEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
                return Result.Fail("Endereço não encontrado");

            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
