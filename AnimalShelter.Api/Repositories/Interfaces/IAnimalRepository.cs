using AnimalShelter.Api.Models;

namespace AnimalShelter.Api.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        Task<List<AnimalModel>> GetAllAnimalsAsync();
        Task<AnimalModel> GetAnimalByIdAsync(int id);
        Task<AnimalModel> CreateAnimalAsync(AnimalModel animal);
        Task UpdateAnimalAsync(AnimalModel animal);
        Task<bool> DeleteAnimalAsync(int id);
    }
}
