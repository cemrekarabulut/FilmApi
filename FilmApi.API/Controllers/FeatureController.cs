using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmApi.API.Models.FeatureModels;
using FilmApi.Domain.Interfaces;
using FilmApi.Application.Services;
using FilmApi.Domain.Entities;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _featureService.GetAllAsync();
            return Ok(features);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureModel model)
        {
            await _featureService.AddAsync(model);
            return Ok("Özellik başarıyla eklendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            if (feature == null)
                return NotFound("Özellik bulunamadı.");
            return Ok(feature);
        }

        [HttpPut]
        public IActionResult UpdateFeature(Feature feature)
        {
            _featureService.UpdateAsync(feature);
            return Ok("Özellik güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            if (feature == null)
                return NotFound("Özellik bulunamadı.");
            _featureService.DeleteAsync(feature);
            return Ok("Özellik silindi.");
        }
    }
}

       