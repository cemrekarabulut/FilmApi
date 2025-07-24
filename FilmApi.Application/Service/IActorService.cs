using FilmApi.Models.ActorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Application.Service;
using FilmApi.Infrastructure.Repositories;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Models; 

namespace FilmApi.Application.Service
{
    public interface IActorService
    {
    Task<List<CreateActorModel>> GetAllAsync();
    Task AddAsync(CreateActorModel model);
    Task<Actor?> GetByIdAsync(int id);
    Task UpdateAsync(Actor actor);
    Task DeleteAsync(Actor actor);
    }

}
