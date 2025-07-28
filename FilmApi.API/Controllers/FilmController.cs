using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Application.Service;
using FilmApi.Domain.Entities;
using FilmApi.Application.DTOs.FilmDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilms()
        {
            var films = await _filmService.GetAllAsync();
            return Ok(films);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilm(CreateFilmDto createFilm)
        {
            await _filmService.AddAsync(createFilm);
            return Ok("Film başarıyla eklendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            if (film == null)
                return NotFound("Film bulunamadı.");
            return Ok(film);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilm(UpdateFilmDto updateFilm)
        {
           await _filmService.UpdateAsync(updateFilm);
            return Ok("Film güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            if (film == null)
                return NotFound("Film bulunamadı.");
            await _filmService.DeleteAsync(id);
            return Ok("Film silindi.");
        }
    }
}

       