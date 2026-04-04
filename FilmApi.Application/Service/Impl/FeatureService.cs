using AutoMapper;
using FilmApi.Application.DTOs.FeatureDto;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;

namespace FilmApi.Application.Service.Impl
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public FeatureService(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            var features = await _featureRepository.GetAllAsync();
            return _mapper.Map<List<ResultFeatureDto>>(features);
        }

        public async Task AddAsync(CreateFeatureDto createFeature)
        {
            var feature = _mapper.Map<Feature>(createFeature);
            await _featureRepository.AddAsync(feature);
        }

        public async Task<ResultFeatureDto?> GetByIdAsync(int id)
        {
            var feature = await _featureRepository.GetByIdAsync(id);
            if (feature is null)
                return null;

            return _mapper.Map<ResultFeatureDto>(feature);
        }

        public async Task UpdateAsync(UpdateFeatureDto updateFeature)
        {
            var feature = await _featureRepository.GetByIdAsync(updateFeature.FeatureId);
            if (feature is null)
                throw new KeyNotFoundException($"Özellik bulunamadı: {updateFeature.FeatureId}");

            _mapper.Map(updateFeature, feature);
            await _featureRepository.UpdateAsync(feature);
        }

        public async Task DeleteAsync(int id)
        {
            var feature = await _featureRepository.GetByIdAsync(id);
            if (feature is not null)
                await _featureRepository.DeleteAsync(feature);
        }
    }
}