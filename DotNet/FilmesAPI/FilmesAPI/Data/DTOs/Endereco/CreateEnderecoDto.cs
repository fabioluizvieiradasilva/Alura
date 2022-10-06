﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Endereco
{
    public class CreateEnderecoDto
    {
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public int Numero { get; set; }
    }
}
