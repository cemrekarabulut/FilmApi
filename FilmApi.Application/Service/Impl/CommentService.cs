using AutoMapper;
using FilmApi.Application.DTOs.CommentDto;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;

namespace FilmApi.Application.Service.Impl
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<ResultCommentDto>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            return _mapper.Map<List<ResultCommentDto>>(comments);
        }

        public async Task AddAsync(CreateCommentDto createComment)
        {
            var comment = _mapper.Map<Comment>(createComment);
            comment.CreatedAt = DateTime.UtcNow;
            await _commentRepository.AddAsync(comment);
        }

        public async Task<ResultCommentDto?> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment is null)
                return null;

            return _mapper.Map<ResultCommentDto>(comment);
        }

        public async Task UpdateAsync(UpdateCommentDto updateComment)
        {
            var comment = await _commentRepository.GetByIdAsync(updateComment.CommentId);
            if (comment is null)
                throw new KeyNotFoundException($"Yorum bulunamadı: {updateComment.CommentId}");

            _mapper.Map(updateComment, comment);
            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment is not null)
                await _commentRepository.DeleteAsync(comment);
        }
    }
}