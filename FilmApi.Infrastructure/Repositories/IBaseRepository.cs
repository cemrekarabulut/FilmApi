using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using FilmApi.Infrastructure.Context;

namespace FilmApi.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

    }
}
