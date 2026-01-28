using AnimalShelter.Api.Models;

namespace AnimalShelter.Api.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        Task<List<AnimalModel>> GetAllAnimalsAsync();
    }
}
