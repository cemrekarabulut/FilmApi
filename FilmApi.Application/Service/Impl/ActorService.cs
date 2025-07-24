using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.ActorModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;
using AutoMapper;
using FilmApi.Application.DTOs.ActorDto;

namespace FilmApi.Application.Service.Impl
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<List<ResultActorDto>> GetAllAsync()
        {
            var actors = await _actorRepository.GetAllAsync();
            return _mapper.Map<List<ResultActorDto>>(actors);
        }

        public async Task AddAsync(CreateActorDto createActor)
        {
            var actor = _mapper.Map<Actor>(createActor);
            await _actorRepository.AddAsync(actor);
        }
        public async Task<ResultActorDto> GetByIdAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            return _mapper.Map<ResultActorDto>(actor);
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            if (actor != null)
            {
                await _actorRepository.DeleteAsync(actor);
            }
        }

        public async Task UpdateAsync(UpdateActorDto updateActor)
        {
            var actor = _mapper.Map<Actor>(updateActor);
            await _actorRepository.UpdateAsync(actor);
        }
        
    }

}

           