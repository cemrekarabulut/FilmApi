using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.FeatureDto
{
    public class CreateFeatureDto
    {
        [Required(ErrorMessage = "Görev/meslek alanı zorunludur.")]
        [MaxLength(100)]
        public required string Job { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}