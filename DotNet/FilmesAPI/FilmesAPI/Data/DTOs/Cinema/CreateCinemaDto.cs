using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O nome do cinema deve ser informado.")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
