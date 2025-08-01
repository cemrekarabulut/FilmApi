using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;

namespace FilmApi.Infrastructure.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<Person> GetPersonByName(string name);
    }
}

    