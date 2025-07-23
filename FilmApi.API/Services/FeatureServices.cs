using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.API.Models.FeatureModels;
using FilmApi.Infrastructure.Repositories;

namespace FilmApi.API.Services
{
    public class FeatureServices
    {
      private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public Task<FeatureModel> CreateAsync(FeatureModel model, CancellationToken cancellationToken = default)
            => _featureRepository.CreateAsync(model, cancellationToken);

        public Task<List<FeatureModel>> GetAllAsync(CancellationToken cancellationToken = default)
            => _featureRepository.GetAllAsync(cancellationToken);

        public Task<FeatureModel> UpdateAsync(FeatureModel model, CancellationToken cancellationToken = default)
            => _featureRepository.UpdateAsync(model, cancellationToken);

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
            => _featureRepository.DeleteAsync(id, cancellationToken);

        public Task<FeatureModel> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => _featureRepository.GetByIdAsync(id, cancellationToken);  
    }
}