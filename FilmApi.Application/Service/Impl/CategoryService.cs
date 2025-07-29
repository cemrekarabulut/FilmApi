using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmApi.Models.CategoryModels;
using FilmApi.Application.Service;
using FilmApi.Models;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;
using FilmApi.Application.DTOs.CategoryDto;

namespace FilmApi.Application.Service.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }
        public async Task<List<ResultCategoryWithFilmsDto>> GetAllWithFilmsAsync()
        {
            var categories = await _categoryRepository.GetAllWithFilmsAsync();
            return _mapper.Map<List<ResultCategoryWithFilmsDto>>(categories);
        }
        public async Task AddAsync(CreateCategoryDto createCategory)
        {
            var category = _mapper.Map<Category>(createCategory);
            await _categoryRepository.AddAsync(category);
        }
        public async Task<ResultCategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<ResultCategoryDto>(category);
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategory)
        {
            var category = _mapper.Map<Category>(updateCategory);
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
             var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                await _categoryRepository.DeleteAsync(category);
            }
        }
    }

}
