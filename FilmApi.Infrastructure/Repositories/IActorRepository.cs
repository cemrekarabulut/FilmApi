using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;
using FilmApi.Domain.Interfaces;

namespace FilmApi.Infrastructure.Repositories
{
    public interface IActorRepository : IBaseRepository<Actor>
    {
        Task<Actor> GetActorByName(string name);
    }
}

    