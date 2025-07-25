using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;

namespace FilmApi.Infrastructure.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        
    }
}