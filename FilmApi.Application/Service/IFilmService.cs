using FilmApi.Application.DTOs.FilmDto;

namespace FilmApi.Application.Service
{
    public interface IFilmService
    {
        Task<List<ResultFilmDto>> GetAllAsync();
        Task AddAsync(CreateFilmDto createFilm);
        Task<ResultFilmDto?> GetByIdAsync(int id);
        Task UpdateAsync(UpdateFilmDto updateFilm);
        Task DeleteAsync(int id);
        Task<List<ResultFilmDto>> GetFilmsByCategoryAsync(string categoryName);
    }
}