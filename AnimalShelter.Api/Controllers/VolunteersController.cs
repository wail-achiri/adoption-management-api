using AnimalShelter.Api.DTO;
using AnimalShelter.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private readonly IUserService _userService;

        public VolunteersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VolunteerDto>>> GetVolunteers()
        {
            var volunteers = await _userService.GetAllVolunteersAsync();
            return Ok(volunteers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VolunteerDto>> GetVolunteer(int id)
        {
            var volunteer = await _userService.GetVolunteerByIdAsync(id);
            if (volunteer == null) return NotFound();
            return Ok(volunteer);
        }

        [HttpPost]
        public async Task<ActionResult<VolunteerDto>> CreateVolunteer([FromBody] VolunteerCreateDto volunteerDto)
        {
            var created = await _userService.CreateVolunteerAsync(volunteerDto);
            return CreatedAtAction(nameof(GetVolunteer), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVolunteer(int id, [FromBody] VolunteerUpdateDto volunteerDto)
        {
            var updated = await _userService.UpdateVolunteerAsync(id, volunteerDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVolunteer(int id)
        {
            var deleted = await _userService.DeleteVolunteerAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
