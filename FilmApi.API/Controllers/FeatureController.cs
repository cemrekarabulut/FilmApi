using Microsoft.AspNetCore.Mvc;
using FilmApi.Application.Service;
using FilmApi.Application.DTOs.FeatureDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        /// <summary>Tüm özellikleri listeler.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResultFeatureDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _featureService.GetAllAsync();
            return Ok(features);
        }

        /// <summary>ID'ye göre özellik getirir.</summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResultFeatureDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFeature(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            if (feature is null)
                return NotFound(new { message = $"ID {id} ile özellik bulunamadı." });

            return Ok(feature);
        }

        /// <summary>Yeni özellik ekler.</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureDto createFeature)
        {
            await _featureService.AddAsync(createFeature);
            return StatusCode(StatusCodes.Status201Created, new { message = "Özellik başarıyla eklendi." });
        }

        /// <summary>Özellik günceller.</summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateFeature(int id, [FromBody] UpdateFeatureDto updateFeature)
        {
            if (id != updateFeature.FeatureId)
                return BadRequest(new { message = "Route ID ile body ID eşleşmiyor." });

            try
            {
                await _featureService.UpdateAsync(updateFeature);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>Özellik siler.</summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            if (feature is null)
                return NotFound(new { message = $"ID {id} ile özellik bulunamadı." });

            await _featureService.DeleteAsync(id);
            return NoContent();
        }
    }
}