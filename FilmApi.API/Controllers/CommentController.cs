using Microsoft.AspNetCore.Mvc;
using FilmApi.Application.Service;
using FilmApi.Application.DTOs.CommentDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>Tüm yorumları listeler.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResultCommentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentService.GetAllAsync();
            return Ok(comments);
        }

        /// <summary>ID'ye göre yorum getirir.</summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResultCommentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            if (comment is null)
                return NotFound(new { message = $"ID {id} ile yorum bulunamadı." });

            return Ok(comment);
        }

        /// <summary>Yeni yorum ekler.</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto createComment)
        {
            await _commentService.AddAsync(createComment);
            return StatusCode(StatusCodes.Status201Created, new { message = "Yorum başarıyla eklendi." });
        }

        /// <summary>Yorum günceller.</summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] UpdateCommentDto updateComment)
        {
            if (id != updateComment.CommentId)
                return BadRequest(new { message = "Route ID ile body ID eşleşmiyor." });

            try
            {
                await _commentService.UpdateAsync(updateComment);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>Yorum siler.</summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            if (comment is null)
                return NotFound(new { message = $"ID {id} ile yorum bulunamadı." });

            await _commentService.DeleteAsync(id);
            return NoContent();
        }
    }
}