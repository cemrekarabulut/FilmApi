using FilmApi.Application.DTOs.FilmDto;

namespace FilmApi.Application.DTOs.CategoryDto
{
    public class ResultCategoryWithFilmsDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<ResultFilmDto> Films { get; set; } = new();
    }
}