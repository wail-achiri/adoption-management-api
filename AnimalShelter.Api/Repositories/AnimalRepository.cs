using AnimalShelter.Api.Data;
using AnimalShelter.Api.Models;
using AnimalShelter.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Api.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalShelterDbContext _dbcontext; 

        public AnimalRepository(AnimalShelterDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<AnimalModel>> GetAllAnimalsAsync()
        {
            return await _dbcontext.Animals.ToListAsync();
        }

        public async Task<AnimalModel> GetAnimalByIdAsync(int id)
        {
            return await _dbcontext.Animals.FindAsync(id);
        }

        public async Task<AnimalModel> CreateAnimalAsync(AnimalModel animal)
        {
            _dbcontext.Animals.Add(animal);
            await _dbcontext.SaveChangesAsync();
            return animal;
        }

        public async Task UpdateAnimalAsync(AnimalModel animal)
        {
            _dbcontext.Animals.Update(animal);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAnimalAsync(int id)
        {
            var animal = await _dbcontext.Animals.FindAsync(id);
            if (animal == null) return false;

            _dbcontext.Animals.Remove(animal);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
