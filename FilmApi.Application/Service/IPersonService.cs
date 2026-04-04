using FilmApi.Application.DTOs.PersonDto;
using FilmApi.Application.DTOs.FilmDto;

namespace FilmApi.Application.Service
{
    public interface IPersonService
    {
        Task<List<ResultPersonDto>> GetAllAsync();
        Task AddAsync(CreatePersonDto createPerson);
        Task<ResultPersonDto?> GetByIdAsync(int id);
        Task UpdateAsync(UpdatePersonDto updatePerson);
        Task DeleteAsync(int id);
        Task<List<ResultFilmDto>> GetFilmsByActorIdAsync(int actorId);
        Task AddFilmToActorAsync(int actorId, int filmId);
        Task<List<ResultPersonDto>> GetByFeatureAsync(string featureName);
    }
}
