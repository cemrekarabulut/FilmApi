using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmApi.API.Models.CategoryModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;

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
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryModel model)
        {
            await _categoryService.AddAsync(model);
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
        public async Task<IActionResult> UpdateCategory(Category category)
        {
         _categoryService.UpdateAsync(category);
            return Ok("Kategori güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound("Kategori bulunamadı.");
         _categoryService.Delete(category);
            return Ok("Kategori silindi.");
        }
    }
}

         
        

        