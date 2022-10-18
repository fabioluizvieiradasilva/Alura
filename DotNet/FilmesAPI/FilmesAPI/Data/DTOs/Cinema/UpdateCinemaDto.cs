using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O nome do cinema deve ser informado.")]
        public string Nome { get; set; }
        public Models.Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}
