using AnimalShelter.Api.Models;
using AnimalShelter.Api.Repositories.Interfaces;
using AnimalShelter.Api.Services.Interfaces;
using AnimalShelter.Api.Models.Enums;

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

        public async Task<AnimalDto> GetAnimalByIdAsync(int id)
        {
            var animal = await _animalRepository.GetAnimalByIdAsync(id);
            if (animal == null) return null;

            return new AnimalDto
            {
                Id = animal.Id,
                Name = animal.Name,
                Age = animal.Age,
                Breed = animal.Breed,
                Type = animal.Type.ToString(),
                State = animal.State.ToString()
            };
        }

        public async Task<AnimalDto> CreateAnimalAsync(AnimalCreateDto animalDto)
        {
            var animal = new AnimalModel
            {
                Name = animalDto.Name,
                Age = animalDto.Age ?? 0,
                Breed = animalDto.Breed,
                Type = !string.IsNullOrEmpty(animalDto.Type) && Enum.TryParse<AnimalType>(animalDto.Type, true, out var t) ? t : default,
                State = !string.IsNullOrEmpty(animalDto.State) && Enum.TryParse<AnimalState>(animalDto.State, true, out var s) ? s : default
            };

            var created = await _animalRepository.CreateAnimalAsync(animal);

            return new AnimalDto
            {
                Id = created.Id,
                Name = created.Name,
                Age = created.Age,
                Breed = created.Breed,
                Type = created.Type.ToString(),
                State = created.State.ToString()
            };
        }

        public async Task<bool> UpdateAnimalAsync(int id, AnimalUpdateDto animalDto)
        {
            var existing = await _animalRepository.GetAnimalByIdAsync(id);
            if (existing == null) return false;

            existing.Name = animalDto.Name ?? existing.Name;
            existing.Age = animalDto.Age ?? existing.Age;
            existing.Breed = animalDto.Breed ?? existing.Breed;
            if (!string.IsNullOrEmpty(animalDto.Type) && Enum.TryParse<AnimalType>(animalDto.Type, true, out var t))
                existing.Type = t;
            if (!string.IsNullOrEmpty(animalDto.State) && Enum.TryParse<AnimalState>(animalDto.State, true, out var s))
                existing.State = s;

            await _animalRepository.UpdateAnimalAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAnimalAsync(int id)
        {
            return await _animalRepository.DeleteAnimalAsync(id);
        }

    }
}
