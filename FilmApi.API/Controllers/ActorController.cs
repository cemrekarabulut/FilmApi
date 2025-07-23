using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
         [HttpGet]
        public IActionResult ActorList()
        {
            var values = _context.Actor.ToList();
            return Ok(values);
        }
        [HttpPost]

        public IActionResult CreateActor(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return Ok("Aktör ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteActor(int id)
        {
            var value = _context.Actors.Find(id);
            _context.Actors.Remove(value);
            _context.SaveChanges();
            return Ok("Aktör silme başarılı");
        }
        [HttpGet("GetActor")]
        public IActionResult GetActor(int id)
        {
            var value = _context.Actors.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateActor(Actor actor)
        {
            _context.Categories.Update(actor);
            _context.SaveChanges();
            return Ok("Aktör güncelleme işlemi başarılı");
        }
    }
}