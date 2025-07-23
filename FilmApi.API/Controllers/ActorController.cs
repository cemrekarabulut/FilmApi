using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Domain.Entities;
using FilmApi.Domain.Interfaces;
using FilmApi.Application.Services;
using FilmApi.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FilmApi.API.Services;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
           _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> ActorList()
        {
            var actors = await _actorService.GetAllActorsAsync();
            return Ok(actors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor(CreateActorModel model)
        {
            await _actorService.AddAsync(model); 
            return Ok("Aktör ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if (actor == null)
                return NotFound("Aktör bulunamadı");

            _actorService.DeleteAsync(actor);
            return Ok("Aktör silme başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActor(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if (actor == null)
                return NotFound("Aktör bulunamadı");

            return Ok(actor);
        }

        [HttpPut]
        public IActionResult UpdateActor(Actor actor)
        {
            _actorService.UpdateAsync(actor);
            return Ok("Aktör güncelleme işlemi başarılı");
        }
    }
}
