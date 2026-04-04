using FilmApi.Domain.Entities;

namespace FilmApi.Infrastructure.Repositories
{
    public interface IFilmRepository : IBaseRepository<Film>
    {
        Task<List<Film>> GetByCategoryAsync(string categoryName);
        Task<List<Film>> GetAllWithDetailsAsync();
    }
}