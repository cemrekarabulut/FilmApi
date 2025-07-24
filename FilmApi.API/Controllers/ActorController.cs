using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Domain.Entities;
using FilmApi.Application.Service;
using FilmApi.Models.ActorModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FilmApi.Application.DTOs.ActorDto;

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
            var actors = await _actorService.GetAllAsync();
            return Ok(actors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor(CreateActorDto createActor)
        {
            await _actorService.AddAsync(createActor); 
            return Ok("Aktör ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if (actor == null)
                return NotFound("Aktör bulunamadı");

            await _actorService.DeleteAsync(id);
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
        public IActionResult UpdateActor(UpdateActorDto updateActor)
        {
            _actorService.UpdateAsync(updateActor);
            return Ok("Aktör güncelleme işlemi başarılı");
        }
    }
}
