using FilmApi.Application.DTOs.FeatureDto;

namespace FilmApi.Application.Service
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllAsync();
        Task AddAsync(CreateFeatureDto createFeature);
        Task<ResultFeatureDto?> GetByIdAsync(int id);
        Task UpdateAsync(UpdateFeatureDto updateFeature);
        Task DeleteAsync(int id);
    }
}