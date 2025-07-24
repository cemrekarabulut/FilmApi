using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.FeatureModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Models;  

namespace FilmApi.Application.Service
{
    public interface IFeatureService
    {
    Task<List<CreateFeatureModel>> GetAllAsync();
    Task AddAsync(CreateFeatureModel model);
    Task<Feature?> GetByIdAsync(int id);
    Task UpdateAsync(Feature feature);
    Task DeleteAsync(Feature feature);
    }
}