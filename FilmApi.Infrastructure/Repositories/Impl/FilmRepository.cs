using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Context;


namespace FilmApi.Infrastructure.Repositories.Impl
{
    public class FilmRepository : BaseRepository<Film> , IFilmRepository
{
     public FilmRepository(ApiContext context) : base(context)
        {

        } 
}
}