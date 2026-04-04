using System.ComponentModel.DataAnnotations;
using FilmApi.Application.DTOs.FilmDto;

namespace FilmApi.Application.DTOs.CategoryDto
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        public required string CategoryName { get; set; }

        public List<CreateFilmWithoutCategoryIdDto>? Films { get; set; }
    }
}