using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.CategoryModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Models;  

namespace FilmApi.Application.Service
{
    public interface ICategoryService
    {
    Task<List<CreateCategoryModel>> GetAllAsync();
    Task AddAsync(CreateCategoryModel model);
    Task<Category?> GetByIdAsync(int id);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
    }
}