using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FilmApi.Infrastructure.Context;

namespace FilmApi.Infrastructure.Repositories.Impl
{
  public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ApiContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(ApiContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var added = (await _dbSet.AddAsync(entity)).Entity;
        await _context.SaveChangesAsync();
        return added;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removed = _dbSet.Remove(entity).Entity;
        await _context.SaveChangesAsync();
        return removed;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

   public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        if (predicate == null)
        return await _context.Set<TEntity>().ToListAsync();
        return await _context.Set<TEntity>().Where(predicate).ToListAsync(); 

    }

    public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate) //async ve await sildim
    {
        return _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var updated = _dbSet.Update(entity).Entity;
        await _context.SaveChangesAsync();
        return updated;
    }
}
}


