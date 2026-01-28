using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Api.Data;
using AnimalShelter.Api.Models;
using AnimalShelter.Api.Services.Interfaces;

namespace AnimalShelter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimals()
        {
            try
            {
                var animals = await _animalService.GetAllAnimalsAsync();
                return Ok(animals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving animals: " + ex.Message);
            } 
        }

        //// GET: api/Animal/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AnimalDTO>> GetAnimalModel(int id)
        //{
        //    var animalModel = await _context.Animals.FindAsync(id);

        //    if (animalModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return animalModel;
        //}

        //// PUT: api/Animal/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnimalModel(int id, AnimalDTO animalModel)
        //{
        //    if (id != animalModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(animalModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnimalModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Animal
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<AnimalDTO>> PostAnimalModel(AnimalDTO animalModel)
        //{
        //    _context.Animals.Add(animalModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAnimalModel", new { id = animalModel.Id }, animalModel);
        //}

        //// DELETE: api/Animal/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAnimalModel(int id)
        //{
        //    var animalModel = await _context.Animals.FindAsync(id);
        //    if (animalModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Animals.Remove(animalModel);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AnimalModelExists(int id)
        //{
        //    return _context.Animals.Any(e => e.Id == id);
        //}
    }
}
