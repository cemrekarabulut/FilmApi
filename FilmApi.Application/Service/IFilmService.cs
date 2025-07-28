using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.FeatureModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Models;
using FilmApi.Application.DTOs.FilmDto;

namespace FilmApi.Application.Service
{
    public interface IFilmService
    {
    Task<List<ResultFilmDto>> GetAllAsync();
    Task AddAsync(CreateFilmDto createFeature);
    Task<ResultFilmDto> GetByIdAsync(int id);
    Task UpdateAsync(UpdateFilmDto updateFeature);
    Task DeleteAsync(int id);
    }
}