using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.FeatureDto
{
    public class UpdateFeatureDto
    {
        [Required]
        public int FeatureId { get; set; }

        [Required(ErrorMessage = "Görev/meslek alanı zorunludur.")]
        [MaxLength(100)]
        public required string Job { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}