using FilmApi.Domain.Entities;

namespace FilmApi.Infrastructure.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<List<Person>> GetByFeatureAsync(string featureName);
    }
}
