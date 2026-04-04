using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.FilmDto
{
    public class UpdateFilmDto
    {
        [Required]
        public int FilmId { get; set; }

        [Required(ErrorMessage = "Film adı zorunludur.")]
        [MaxLength(200)]
        public required string FilmName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bilet fiyatı 0 veya daha büyük olmalıdır.")]
        public decimal TicketPrice { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "IMDb puanı 0.0 ile 10.0 arasında olmalıdır.")]
        public double ImdbRating { get; set; }

        public List<int>? CategoryIds { get; set; }
    }
}