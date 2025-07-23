using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.ActorModels;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
//using FilmApi.Models; 

namespace FilmApi.Application.Services
{
    public interface IActorServices
    {
    
    Task<List<ActorModel>> GetAllAsync();
    Task AddAsync(CreateActorModel model);
    Task<Actor?> GetByIdAsync(int id);
    void Update(Actor actor);
    void Delete(Actor actor);
    }

}
