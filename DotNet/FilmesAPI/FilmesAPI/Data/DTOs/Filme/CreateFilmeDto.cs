using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Filme
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório.")]
        [StringLength(maximumLength: 100, MinimumLength = 2,
            ErrorMessage = "O campo título deve ter no mínimo 2 caracteres e no máximo 100 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório.")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O campo genero é obrigatório.")]
        public string Genero { get; set; }
        [Range(1, 180, ErrorMessage = "O campo duração deve ter no mínimo 1 e no máximo 180 minutos.")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
