using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Context;


namespace FilmApi.Infrastructure.Repositories.Impl
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
      public CommentRepository(ApiContext context) : base(context)
        {

        } 
    }
}