using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmApi.API.Models;
using FilmApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace FilmApi.API.Services
{
    public class ActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        // Örnek bir metot
        public async Task<List<ActionModel>> GetAllActorsAsync()
        {
            var actors = await _actorRepository.GetAllAsync(x => true); // tüm aktörler
            // Domain'den API Model'e map edebilirsin
            return actors.Select(a => new ActorModel
            {
                Id = a.Id,
                NameSurname = a.NameSurname
            }).ToList();
        }
    }
}
