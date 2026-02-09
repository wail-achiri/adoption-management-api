using AnimalShelter.Api.DTO;
using AnimalShelter.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptersController : ControllerBase
    {
        private readonly IAdopterService _adopterService;

        public AdoptersController(IAdopterService adopterService)
        {
            _adopterService = adopterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdopterDto>>> GetAdopters()
        {
            var adopters = await _adopterService.GetAllAdoptersAsync();
            return Ok(adopters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdopterDto>> GetAdopter(int id)
        {
            var adopter = await _adopterService.GetAdopterByIdAsync(id);
            if (adopter == null) return NotFound();
            return Ok(adopter);
        }

        [HttpPost]
        public async Task<ActionResult<AdopterDto>> CreateAdopter([FromBody] AdopterCreateDto adopterDto)
        {
            var created = await _adopterService.CreateAdopterAsync(adopterDto);
            return CreatedAtAction(nameof(GetAdopter), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdopter(int id, [FromBody] AdopterUpdateDto adopterDto)
        {
            var updated = await _adopterService.UpdateAdopterAsync(id, adopterDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdopter(int id)
        {
            var deleted = await _adopterService.DeleteAdopterAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
