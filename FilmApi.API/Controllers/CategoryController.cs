using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using FilmApi.Models.CategoryModels;
using FilmApi.Application.Service;
//using FilmApi.Domain.Entities;
using FilmApi.Application.DTOs.CategoryDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
             List<ResultCategoryDto> categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("withFilms")]
        public async Task<IActionResult> GetAllCategoriesWithFilms()
        {
             List<ResultCategoryWithFilmsDto> categories = await _categoryService.GetAllWithFilmsAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategory)
        {
            await _categoryService.AddAsync(createCategory);
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound("Kategori bulunamadı.");
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategory)
        {
         await _categoryService.UpdateAsync(updateCategory);
            return Ok("Kategori güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound("Kategori bulunamadı.");
            await _categoryService.DeleteAsync(id);
            return Ok("Kategori silindi.");
        }
    }
}

         
        

        