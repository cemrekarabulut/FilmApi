using FilmApi.Application.DTOs.CommentDto;

namespace FilmApi.Application.Service
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllAsync();
        Task AddAsync(CreateCommentDto createComment);
        Task<ResultCommentDto?> GetByIdAsync(int id);
        Task UpdateAsync(UpdateCommentDto updateComment);
        Task DeleteAsync(int id);
    }
}