using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;



namespace FilmApi.Infrastructure.Repositories.Impl
{
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        public FilmRepository(ApiContext context) : base(context)
        {

        }

        public async Task<List<Film>> GetByCategoryAsync(string categoryName)
        {
            return await _context.Films
                .Include(f => f.Categories) // Filmleri kategorileriyle birlikte getir
                .Where(f => f.Categories.Any(c => c.CategoryName == categoryName))
                .ToListAsync();
        }
        public override async Task<Film> GetByIdAsync(int id)
        {
           return await _context.Films
               .Include(f => f.Categories)
               .Include(f => f.Persons)
               .FirstOrDefaultAsync(f => f.FilmId == id);
}

}
}