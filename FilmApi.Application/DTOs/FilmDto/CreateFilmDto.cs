using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.FilmDto
{
    public class CreateFilmDto
    {
        [Required(ErrorMessage = "Film adı zorunludur.")]
        [MaxLength(200, ErrorMessage = "Film adı en fazla 200 karakter olabilir.")]
        public required string FilmName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bilet fiyatı 0 veya daha büyük olmalıdır.")]
        public decimal TicketPrice { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "IMDb puanı 0.0 ile 10.0 arasında olmalıdır.")]
        public double ImdbRating { get; set; }

        [Required(ErrorMessage = "En az bir kategori seçilmelidir.")]
        [MinLength(1, ErrorMessage = "En az bir kategori seçilmelidir.")]
        public required List<int> CategoryIds { get; set; }
    }
}