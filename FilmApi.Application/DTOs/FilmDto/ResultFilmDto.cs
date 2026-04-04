using FilmApi.Application.DTOs.CategoryDto;
using FilmApi.Application.DTOs.PersonDto;

namespace FilmApi.Application.DTOs.FilmDto
{
    public class ResultFilmDto
    {
        public int FilmId { get; set; }
        public string FilmName { get; set; } = string.Empty;
        public decimal TicketPrice { get; set; }
        public double ImdbRating { get; set; }
        public List<int> CategoryIds { get; set; } = new();
        public List<ResultCategoryDto> Categories { get; set; } = new();
        public List<ResultPersonDto> Actors { get; set; } = new();
        public ResultPersonDto? Director { get; set; }
    }
}