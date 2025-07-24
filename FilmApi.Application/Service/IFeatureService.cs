using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.FeatureModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Models;
using FilmApi.Application.DTOs.FeatureDto;

namespace FilmApi.Application.Service
{
    public interface IFeatureService
    {
    Task<List<ResultFeatureDto>> GetAllAsync();
    Task AddAsync(CreateFeatureDto createFeature);
    Task<ResultFeatureDto> GetByIdAsync(int id);
    Task UpdateAsync(UpdateFeatureDto updateFeature);
    Task DeleteAsync(int id);
    }
}