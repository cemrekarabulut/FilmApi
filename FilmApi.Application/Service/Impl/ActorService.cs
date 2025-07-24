using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.ActorModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;

namespace FilmApi.Application.Service.Impl
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<List<CreateActorModel>> GetAllAsync()
        {
            var actors = await _actorRepository.GetAllAsync();
            return actors.Select(a => new CreateActorModel
            {
               // ActorId = a.ActorId, 
                NameSurname = a.NameSurname
            }).ToList();
        }

        public async Task AddAsync(CreateActorModel model)
        {
            var actor = new Actor
            {
                NameSurname = model.NameSurname
            };
            await _actorRepository.AddAsync(actor);
        }
        public async Task<Actor?> GetByIdAsync(int id)
        {
            return await _actorRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(Actor actor)
        {
            await _actorRepository.DeleteAsync(actor);
        }

        public async Task UpdateAsync(Actor actor)
        {
            await _actorRepository.UpdateAsync(actor);
        }
        
    }

}

           