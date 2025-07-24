using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Models.FeatureModels;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using FilmApi.Application.DTOs.FeatureDto;

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
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeature)
        {
            await _featureService.AddAsync(createFeature);
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
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeature)
        {
            _featureService.UpdateAsync(updateFeature);
            return Ok("Özellik güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            if (feature == null)
                return NotFound("Özellik bulunamadı.");
            await _featureService.DeleteAsync(id);
            return Ok("Özellik silindi.");
        }
    }
}

       