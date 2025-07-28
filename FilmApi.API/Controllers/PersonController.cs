using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Domain.Entities;
using FilmApi.Application.Service;
using FilmApi.Models.ActorModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FilmApi.Application.DTOs.PersonDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> PersonList()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonDto createPerson)
        {
            await _personService.AddAsync(createPerson);
            return Ok("Kişi ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
                return NotFound("Kişi bulunamadı");

            await _personService.DeleteAsync(id);
            return Ok("Kişi silme başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
                return NotFound("Kişi bulunamadı");

            return Ok(person);
        }

        [HttpGet("{id}/films")]
        public async Task<IActionResult> GetFilmsByActor(int id)
        {
            var films = await _personService.GetFilmsByActorIdAsync(id);
            return Ok(films);
        }

        [HttpPut]
        public IActionResult UpdatePerson(UpdatePersonDto updatePerson)
        {
            _personService.UpdateAsync(updatePerson);
            return Ok("Kişi güncelleme işlemi başarılı");
        }
        
        [HttpPost("{actorId}/add-film/{filmId}")]
        public async Task<IActionResult> AddFilmToActor(int actorId, int filmId)
        {
        await _personService.AddFilmToActorAsync(actorId, filmId);
        return Ok("Film başarıyla aktöre eklendi.");
        }

    }
}
