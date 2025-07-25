using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Models.FeatureModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using FilmApi.Application.DTOs.CommentDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllAsync();
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createComment)
        {
            await _commentService.AddAsync(createComment);
            return Ok("Özellik başarıyla eklendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var feature = await _commentService.GetByIdAsync(id);
            if (feature == null)
                return NotFound("Özellik bulunamadı.");
            return Ok(feature);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateCommentDto updateComment)
        {
           await _commentService.UpdateAsync(updateComment);
            return Ok("Özellik güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            if (comment == null)
                return NotFound("Özellik bulunamadı.");
            await _commentService.DeleteAsync(id);
            return Ok("Özellik silindi.");
        }
    }
}

       