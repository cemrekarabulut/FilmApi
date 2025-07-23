using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;

namespace FilmApi.Infrastructure.Repositories
{
    public interface IFeatureRepository : IBaseRepository<Feature>
    {
        Task<FilmApi.API.Models.FeatureModels.FeatureModel> CreateAsync(FilmApi.API.Models.FeatureModels.FeatureModel model, CancellationToken cancellationToken);
    }
}