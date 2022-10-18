using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do cinema deve ser informado.")]
        public string Nome { get; set; }
        public Models.Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}
