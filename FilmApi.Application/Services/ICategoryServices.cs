using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.CategoryModels;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
//using FilmApi.Models;  

namespace FilmApi.Application.Services
{
    public interface ICategoryServices
    {
    Task<List<CreateCategoryModel>> GetAllAsync();
    Task AddAsync(CreateCategoryModel model);
    Task<Category?> GetByIdAsync(int id);
    void Update(Category category);
    void Delete(Category category);
}

    }