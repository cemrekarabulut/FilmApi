using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.FeatureModels;
using FilmApi.Domain.Entities;
using FilmApi.Domain.Interfaces;
using FilmApi.Infrastructure.Repositories;

namespace FilmApi.API.Services
{
    public class FeatureService :IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<List<CreateFeatureModel>> GetAllAsync()
        {
            var features = await _featureRepository.GetAllAsync();
            return features.Select(f => new CreateFeatureModel
            {
                Job = f.Job 
            }).ToList();
        }

        public async Task AddAsync(CreateFeatureModel model)
        {
            var feature = new Feature
            {
                Job = model.Job
            };
            await _featureRepository.AddAsync(feature);
        }

        public async Task<Feature?> GetByIdAsync(int id)
        {
            return await _featureRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Feature feature)
        {
            await _featureRepository.UpdateAsync(feature);
        }

        public async Task DeleteAsync(Feature feature)
        {
            await _featureRepository.DeleteAsync(feature);
        }
    }
}
        