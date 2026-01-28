using AnimalShelter.Api.Models;

namespace AnimalShelter.Api.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDto>> GetAllAnimalsAsync();
    }
}
