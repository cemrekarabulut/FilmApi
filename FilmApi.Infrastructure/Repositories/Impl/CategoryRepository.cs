using Microsoft.EntityFrameworkCore;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Context;

namespace FilmApi.Infrastructure.Repositories.Impl
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApiContext context) : base(context) { }

        public async Task<List<Category>> GetAllWithFilmsAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .Include(c => c.Films)
                .ToListAsync();
        }
    }
}
