using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Infrastructure.Repositories.Impl
{
    public class ActorRepository(ApiContext context) : BaseRepository<Actor>(context), IActorRepository
    {
        public async Task<Actor> GetActorByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.NameSurname == name);
        }
    }
}  