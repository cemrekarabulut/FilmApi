using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.FilmDto
{
    public class CreateFilmWithoutCategoryIdDto
    {
        [Required(ErrorMessage = "Film adı zorunludur.")]
        [MaxLength(200)]
        public required string FilmName { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TicketPrice { get; set; }

        [Range(0.0, 10.0)]
        public double ImdbRating { get; set; }
    }
}