using Microsoft.EntityFrameworkCore;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Context;

namespace FilmApi.Infrastructure.Repositories.Impl
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApiContext context) : base(context) { }

        public override async Task<Person?> GetByIdAsync(int id)
        {
            return await _context.Persons
                .Include(p => p.Feature)
                .Include(p => p.Films)
                .FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public async Task<List<Person>> GetByFeatureAsync(string featureName)
        {
            return await _context.Persons
                .AsNoTracking()
                .Include(p => p.Feature)
                .Where(p => p.Feature.Job == featureName)
                .ToListAsync();
        }
    }
}
