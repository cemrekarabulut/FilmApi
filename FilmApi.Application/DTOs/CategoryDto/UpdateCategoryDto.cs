using System.ComponentModel.DataAnnotations;

namespace FilmApi.Application.DTOs.CategoryDto
{
    public class UpdateCategoryDto
    {
        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [MaxLength(100)]
        public required string CategoryName { get; set; }
    }
}