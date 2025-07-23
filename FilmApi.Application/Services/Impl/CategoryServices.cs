using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.CategoryModels;
//using FilmApi.Models;
using FilmApi.Domain.Entities;

using FilmApi.Infrastructure.Repositories;

namespace FilmApi.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CreateCategoryModel>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CreateCategoryModel
            {
                CategoryName = c.CategoryName
            }).ToList();
        }

        public async Task AddAsync(CreateCategoryModel model)
        {
            var category = new Category { CategoryName = model.CategoryName };
            await _categoryRepository.AddAsync(category);
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task Delete(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }

        void ICategoryService.Delete(Category category)
        {
            throw new NotImplementedException();
        }
    }

}
