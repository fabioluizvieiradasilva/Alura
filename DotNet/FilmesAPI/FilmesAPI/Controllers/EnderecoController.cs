using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs.Endereco;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController: ControllerBase
    {
        private readonly EnderecoService _enderecoService;        

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public IActionResult RecuperaEnredecos()
        {
            List<ReadEnderecoDto> readEnderecoDto = _enderecoService.RecuperaEnderecos();
            if(readEnderecoDto == null)
                return NotFound();
            
            return Ok(readEnderecoDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            ReadEnderecoDto readEnderecoDto = _enderecoService.RecuperaEnderecoPorId(id);
            if (readEnderecoDto == null)
                return NotFound();            
            
            return Ok(readEnderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result =  _enderecoService.AtualizaEndereco(id, enderecoDto);
            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult RemoveEndereco(int id)
        {
            Result result = _enderecoService.RemoveEndereco(id);
            if (result.IsFailed)
                return NotFound();
            
            return NoContent();
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readEnderecoDto = _enderecoService.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readEnderecoDto.Id}, readEnderecoDto);
        }


    }
}
