using AutoMapper;
using FilmApi.Application.DTOs.PersonDto;
using FilmApi.Application.DTOs.FilmDto;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;

namespace FilmApi.Application.Service.Impl
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper, IFilmRepository filmRepository)
        {
            _personRepository = personRepository;
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<List<ResultPersonDto>> GetAllAsync()
        {
            var persons = await _personRepository.GetAllAsync();
            return _mapper.Map<List<ResultPersonDto>>(persons);
        }

        public async Task AddAsync(CreatePersonDto createPerson)
        {
            var person = _mapper.Map<Person>(createPerson);
            await _personRepository.AddAsync(person);
        }

        public async Task<ResultPersonDto?> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person is null)
                return null;

            return _mapper.Map<ResultPersonDto>(person);
        }

        public async Task DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person is not null)
                await _personRepository.DeleteAsync(person);
        }

        public async Task UpdateAsync(UpdatePersonDto updatePerson)
        {
            var person = await _personRepository.GetByIdAsync(updatePerson.PersonId);
            if (person is null)
                throw new KeyNotFoundException($"Kişi bulunamadı: {updatePerson.PersonId}");

            _mapper.Map(updatePerson, person);
            await _personRepository.UpdateAsync(person);
        }

        public async Task<List<ResultFilmDto>> GetFilmsByActorIdAsync(int actorId)
        {
            var actor = await _personRepository.GetByIdAsync(actorId);
            if (actor is null)
                throw new KeyNotFoundException($"Kişi bulunamadı: {actorId}");

            if (actor.Feature?.Job != "Actor")
                throw new InvalidOperationException("Bu kişi bir aktör değildir.");

            return _mapper.Map<List<ResultFilmDto>>(actor.Films);
        }

        public async Task AddFilmToActorAsync(int actorId, int filmId)
        {
            var actor = await _personRepository.GetByIdAsync(actorId);
            if (actor is null)
                throw new KeyNotFoundException($"Kişi bulunamadı: {actorId}");

            if (actor.Feature?.Job != "Actor")
                throw new InvalidOperationException("Bu kişi bir aktör değildir.");

            var film = await _filmRepository.GetByIdAsync(filmId);
            if (film is null)
                throw new KeyNotFoundException($"Film bulunamadı: {filmId}");

            actor.Films.Add(film);
            await _personRepository.UpdateAsync(actor);
        }

        public async Task<List<ResultPersonDto>> GetByFeatureAsync(string featureName)
        {
            var persons = await _personRepository.GetByFeatureAsync(featureName);
            return _mapper.Map<List<ResultPersonDto>>(persons);
        }
    }
}