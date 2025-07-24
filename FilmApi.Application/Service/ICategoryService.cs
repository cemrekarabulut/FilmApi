using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.CategoryModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Models;
using FilmApi.Application.DTOs.CategoryDto;

namespace FilmApi.Application.Service
{
   public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task<List<ResultCategoryWithFilmsDto>> GetAllWithFilmsAsync();
        Task<ResultCategoryDto> GetByIdAsync(int id);
        Task AddAsync(CreateCategoryDto createCategoryDto);
        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteAsync(int id);
    }
}