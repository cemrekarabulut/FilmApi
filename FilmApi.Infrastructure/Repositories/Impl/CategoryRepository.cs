using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Context;

namespace FilmApi.Infrastructure.Repositories.Impl
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApiContext _context;

        public CategoryRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllWithFilmsAsync()
        {
            return await _context.Categories
                                 .Include(c => c.Films) 
                                 .ToListAsync();
        }
    }
}
