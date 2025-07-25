using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Models.FeatureModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using System.Threading.Tasks;
using FilmApi.Models;
using FilmApi.Application.DTOs.CommentDto;


namespace FilmApi.Application.Service
{
    public interface ICommentService
    {
    Task<List<ResultCommentDto>> GetAllAsync();
    Task AddAsync(CreateCommentDto createComment);
    Task<ResultCommentDto> GetByIdAsync(int id);
    Task UpdateAsync(UpdateCommentDto updateComment);
    Task DeleteAsync(int id);
    }
}