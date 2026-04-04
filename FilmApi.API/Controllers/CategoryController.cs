using Microsoft.AspNetCore.Mvc;
using FilmApi.Application.Service;
using FilmApi.Application.DTOs.CategoryDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>Tüm kategorileri listeler.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResultCategoryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        /// <summary>Kategorileri filmleriyle birlikte listeler.</summary>
        [HttpGet("with-films")]
        [ProducesResponseType(typeof(List<ResultCategoryWithFilmsDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategoriesWithFilms()
        {
            var categories = await _categoryService.GetAllWithFilmsAsync();
            return Ok(categories);
        }

        /// <summary>ID'ye göre kategori getirir.</summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResultCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category is null)
                return NotFound(new { message = $"ID {id} ile kategori bulunamadı." });

            return Ok(category);
        }

        /// <summary>Yeni kategori ekler.</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategory)
        {
            await _categoryService.AddAsync(createCategory);
            return StatusCode(StatusCodes.Status201Created, new { message = "Kategori başarıyla eklendi." });
        }

        /// <summary>Kategori günceller.</summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategory)
        {
            if (id != updateCategory.CategoryId)
                return BadRequest(new { message = "Route ID ile body ID eşleşmiyor." });

            try
            {
                await _categoryService.UpdateAsync(updateCategory);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>Kategori siler.</summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category is null)
                return NotFound(new { message = $"ID {id} ile kategori bulunamadı." });

            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}