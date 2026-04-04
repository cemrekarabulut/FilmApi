using Microsoft.AspNetCore.Mvc;
using FilmApi.Application.Service;
using FilmApi.Application.DTOs.PersonDto;

namespace FilmApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>Tüm kişileri listeler.</summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResultPersonDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPersons()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        /// <summary>ID'ye göre kişi getirir.</summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResultPersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person is null)
                return NotFound(new { message = $"ID {id} ile kişi bulunamadı." });

            return Ok(person);
        }

        /// <summary>Yeni kişi ekler.</summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto createPerson)
        {
            await _personService.AddAsync(createPerson);
            return StatusCode(StatusCodes.Status201Created, new { message = "Kişi başarıyla eklendi." });
        }

        /// <summary>Kişi günceller.</summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] UpdatePersonDto updatePerson)
        {
            if (id != updatePerson.PersonId)
                return BadRequest(new { message = "Route ID ile body ID eşleşmiyor." });

            try
            {
                await _personService.UpdateAsync(updatePerson);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>Kişi siler.</summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person is null)
                return NotFound(new { message = $"ID {id} ile kişi bulunamadı." });

            await _personService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>Aktörün oynadığı filmleri getirir.</summary>
        [HttpGet("{id:int}/films")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFilmsByActor(int id)
        {
            try
            {
                var films = await _personService.GetFilmsByActorIdAsync(id);
                return Ok(films);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>Aktöre film ekler.</summary>
        [HttpPost("{actorId:int}/add-film/{filmId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddFilmToActor(int actorId, int filmId)
        {
            try
            {
                await _personService.AddFilmToActorAsync(actorId, filmId);
                return Ok(new { message = "Film başarıyla aktöre eklendi." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>Özelliğe (Feature) göre kişileri listeler.</summary>
        [HttpGet("by-feature/{featureName}")]
        [ProducesResponseType(typeof(List<ResultPersonDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPersonsByFeature(string featureName)
        {
            var persons = await _personService.GetByFeatureAsync(featureName);
            return Ok(persons);
        }
    }
}
