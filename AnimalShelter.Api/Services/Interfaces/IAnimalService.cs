using AnimalShelter.Api.Models;

namespace AnimalShelter.Api.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDto>> GetAllAnimalsAsync();
        Task<AnimalDto> GetAnimalByIdAsync(int id);
        Task<AnimalDto> CreateAnimalAsync(AnimalCreateDto animalDto);
        Task<bool> UpdateAnimalAsync(int id, AnimalUpdateDto animalDto);
        Task<bool> DeleteAnimalAsync(int id);
    }
}
