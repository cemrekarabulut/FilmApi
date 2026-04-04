using FilmApi.Domain.Entities;

namespace FilmApi.Infrastructure.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetAllWithFilmsAsync();
    }
}