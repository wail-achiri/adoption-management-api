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
    }
}
