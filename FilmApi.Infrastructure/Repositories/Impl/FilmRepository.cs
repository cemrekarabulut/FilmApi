using Microsoft.EntityFrameworkCore;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Context;

namespace FilmApi.Infrastructure.Repositories.Impl
{
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        public FilmRepository(ApiContext context) : base(context) { }

        public async Task<List<Film>> GetByCategoryAsync(string categoryName)
        {
            return await _context.Films
                .AsNoTracking()
                .Include(f => f.Categories)
                .Include(f => f.Persons)
                .Where(f => f.Categories.Any(c => c.CategoryName == categoryName))
                .ToListAsync();
        }

        public override async Task<Film?> GetByIdAsync(int id)
        {
            return await _context.Films
                .Include(f => f.Categories)
                .Include(f => f.Persons)
                    .ThenInclude(p => p.Feature)
                .FirstOrDefaultAsync(f => f.FilmId == id);
        }

        public async Task<List<Film>> GetAllWithDetailsAsync()
        {
            return await _context.Films
                .AsNoTracking()
                .Include(f => f.Categories)
                .Include(f => f.Persons)
                .ToListAsync();
        }
    }
}