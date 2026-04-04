using Microsoft.AspNetCore.Mvc;
using FilmApi.Application.Service;
using FilmApi.Application.DTOs.FilmDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        /// <summary>Tüm filmleri listeler.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResultFilmDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFilms()
        {
            var films = await _filmService.GetAllAsync();
            return Ok(films);
        }

        /// <summary>ID'ye göre film getirir.</summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResultFilmDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            if (film is null)
                return NotFound(new { message = $"ID {id} ile film bulunamadı." });

            return Ok(film);
        }

        /// <summary>Yeni film ekler.</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateFilm([FromBody] CreateFilmDto createFilm)
        {
            try
            {
                await _filmService.AddAsync(createFilm);
                return StatusCode(StatusCodes.Status201Created, new { message = "Film başarıyla eklendi." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>Film günceller.</summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateFilm(int id, [FromBody] UpdateFilmDto updateFilm)
        {
            if (id != updateFilm.FilmId)
                return BadRequest(new { message = "Route ID ile body ID eşleşmiyor." });

            try
            {
                await _filmService.UpdateAsync(updateFilm);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>Film siler.</summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            if (film is null)
                return NotFound(new { message = $"ID {id} ile film bulunamadı." });

            await _filmService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>Kategoriye göre film listeler.</summary>
        [HttpGet("by-category/{categoryName}")]
        [ProducesResponseType(typeof(List<ResultFilmDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilmsByCategory(string categoryName)
        {
            var films = await _filmService.GetFilmsByCategoryAsync(categoryName);
            return Ok(films);
        }
    }
}