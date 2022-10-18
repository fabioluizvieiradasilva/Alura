using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Sessao
{
    public class ReadSessaoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public FilmesAPI.Models.Filme Filme { get; set; }
        public FilmesAPI.Models.Cinema Cinema { get; set; }        
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeIncio { get; set; }
    }
}
