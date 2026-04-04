using FilmApi.Application.DTOs.CategoryDto;

namespace FilmApi.Application.Service
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task<List<ResultCategoryWithFilmsDto>> GetAllWithFilmsAsync();
        Task<ResultCategoryDto?> GetByIdAsync(int id);
        Task AddAsync(CreateCategoryDto createCategory);
        Task UpdateAsync(UpdateCategoryDto updateCategory);
        Task DeleteAsync(int id);
    }
}