using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;
using AutoMapper;
using FilmApi.Application.DTOs.PersonDto;
using FilmApi.Application.DTOs.FilmDto;


namespace FilmApi.Application.Service.Impl
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IFilmRepository _filmRepository;
        public PersonService(IPersonRepository personRepository, IMapper mapper, IFilmRepository filmRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _filmRepository = filmRepository;
        }

        public async Task<List<ResultPersonDto>> GetAllAsync()
        {
            var Persons = await _personRepository.GetAllAsync();
            return _mapper.Map<List<ResultPersonDto>>(Persons);
        }

        public async Task AddAsync(CreatePersonDto createPerson)
        {
            var person = _mapper.Map<Person>(createPerson);
            await _personRepository.AddAsync(person);
        }
        public async Task<ResultPersonDto> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return _mapper.Map<ResultPersonDto>(person);
        }

        public async Task DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person != null)
            {
                await _personRepository.DeleteAsync(person);
            }
        }

        public async Task UpdateAsync(UpdatePersonDto updatePerson)
        {
            var person = _mapper.Map<Person>(updatePerson);
            await _personRepository.UpdateAsync(person);
        }

        public async Task<List<ResultFilmDto>> GetFilmsByActorIdAsync(int actorId)
        {
            var actor = await _personRepository.GetByIdAsync(actorId);
            if (actor == null || actor.Feature.Job != "Actor")
                throw new Exception("Bu kişi aktör değil.");

            return _mapper.Map<List<ResultFilmDto>>(actor.Films);
        }
        
        public async Task AddFilmToActorAsync(int actorId, int filmId)
{
           var actor = await _personRepository.GetByIdAsync(actorId);
           if (actor == null || actor.Feature.Job != "Actor")
           throw new Exception("Bu kişi aktör değil.");

           var film = await _filmRepository.GetByIdAsync(filmId);
           if (film == null)
           throw new Exception("Film bulunamadı.");

           actor.Films.Add(film);
           await _personRepository.UpdateAsync(actor);
}

    }

}

           