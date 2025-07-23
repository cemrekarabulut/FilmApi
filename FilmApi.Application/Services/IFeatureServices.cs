using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.FeatureModels;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
//using FilmApi.Models;  


namespace FilmApi.Application.Services
{
    public interface IFeatureServices
    {

    Task<List<CreateFeatureModel>> GetAllAsync();
    Task AddAsync(CreateFeatureModel model);
    Task<Feature?> GetByIdAsync(int id);
    void Update(Feature feature);
    void Delete(Feature feature);
    }
}