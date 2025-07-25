using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.FeatureModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using FilmApi.Infrastructure.Repositories;
using AutoMapper;
using FilmApi.Application.DTOs.CommentDto;


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
            await _commentRepository.AddAsync(comment);
        }

        public async Task<ResultCommentDto> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<ResultCommentDto>(comment);
        }

        public async Task UpdateAsync(UpdateCommentDto updateComment)
        {
            var comment = _mapper.Map<Comment>(updateComment);
            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment != null)
            {
                await _commentRepository.DeleteAsync(comment);
            }
        }
    }
}