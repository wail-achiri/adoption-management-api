using AnimalShelter.Api.DTO;

namespace AnimalShelter.Api.Services.Interfaces
{
    public interface IAdopterService
    {
        Task<IEnumerable<AdopterDto>> GetAllAdoptersAsync();
        Task<AdopterDto> GetAdopterByIdAsync(int id);
        Task<AdopterDto> CreateAdopterAsync(AdopterCreateDto adopterDto);
        Task<bool> UpdateAdopterAsync(int id, AdopterUpdateDto adopterDto);
        Task<bool> DeleteAdopterAsync(int id);
    }
}
