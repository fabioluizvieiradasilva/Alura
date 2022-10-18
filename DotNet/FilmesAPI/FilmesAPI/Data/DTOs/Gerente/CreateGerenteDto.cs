using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Gerente
{
    public class CreateGerenteDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
