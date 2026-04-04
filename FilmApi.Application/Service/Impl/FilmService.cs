using AutoMapper;
using FilmApi.Application.DTOs.FilmDto;
using FilmApi.Application.DTOs.PersonDto;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;

namespace FilmApi.Application.Service.Impl
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public FilmService(IFilmRepository filmRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _filmRepository = filmRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ResultFilmDto>> GetAllAsync()
        {
            var films = await _filmRepository.GetAllWithDetailsAsync();
            return _mapper.Map<List<ResultFilmDto>>(films);
        }

        public async Task AddAsync(CreateFilmDto createFilm)
        {
            var film = _mapper.Map<Film>(createFilm);
            film.Categories.Clear();

            var categories = await _categoryRepository.GetAllAsync(
                c => createFilm.CategoryIds.Contains(c.CategoryId));

            var foundIds = categories.Select(c => c.CategoryId).ToHashSet();
            var missingIds = createFilm.CategoryIds.Except(foundIds).ToList();

            if (missingIds.Count > 0)
                throw new KeyNotFoundException($"Aşağıdaki kategori ID'leri bulunamadı: {string.Join(", ", missingIds)}");

            foreach (var category in categories)
                film.Categories.Add(category);

            await _filmRepository.AddAsync(film);
        }

        public async Task<ResultFilmDto?> GetByIdAsync(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            if (film is null)
                return null;

            var dto = _mapper.Map<ResultFilmDto>(film);

            // BUG FIX: use Feature.Job instead of Person.Job (Person.Job is never populated)
            dto.Actors = film.Persons
                .Where(p => p.Feature?.Job == "Actor")
                .Select(p => _mapper.Map<ResultPersonDto>(p))
                .ToList();

            var director = film.Persons.FirstOrDefault(p => p.Feature?.Job == "Director");
            dto.Director = director is not null ? _mapper.Map<ResultPersonDto>(director) : null;

            return dto;
        }

        public async Task UpdateAsync(UpdateFilmDto updateFilm)
        {
            var film = await _filmRepository.GetByIdAsync(updateFilm.FilmId)
                ?? throw new KeyNotFoundException($"Film bulunamadı: {updateFilm.FilmId}");

            _mapper.Map(updateFilm, film);

            if (updateFilm.CategoryIds is { Count: > 0 })
            {
                var categories = await _categoryRepository.GetAllAsync(
                    c => updateFilm.CategoryIds.Contains(c.CategoryId));

                film.Categories.Clear();
                foreach (var category in categories)
                    film.Categories.Add(category);
            }

            await _filmRepository.UpdateAsync(film);
        }

        public async Task DeleteAsync(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            if (film is not null)
                await _filmRepository.DeleteAsync(film);
        }

        public async Task<List<ResultFilmDto>> GetFilmsByCategoryAsync(string categoryName)
        {
            var films = await _filmRepository.GetByCategoryAsync(categoryName);
            return _mapper.Map<List<ResultFilmDto>>(films);
        }
    }
}
