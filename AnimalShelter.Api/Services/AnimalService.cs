using AnimalShelter.Api.Models;
using AnimalShelter.Api.Repositories.Interfaces;
using AnimalShelter.Api.Services.Interfaces;

namespace AnimalShelter.Api.Services
{
    public class AnimalService : IAnimalService
    {

        private IAnimalRepository _animalRepository; 

        public AnimalService(IAnimalRepository animalRepository) { 
            _animalRepository = animalRepository;
        }

        public async Task<IEnumerable<AnimalDto>> GetAllAnimalsAsync()
        {
            var animals = await _animalRepository.GetAllAnimalsAsync();
            return animals.Select(animal => new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Age = animal.Age,
                Breed = animal.Breed,
                Type = animal.Type.ToString(),
                State = animal.State.ToString()
            });
        }


    }
}
