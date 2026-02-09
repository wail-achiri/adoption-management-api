using AnimalShelter.Api.DTO;

namespace AnimalShelter.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<VolunteerDto>> GetAllVolunteersAsync();
        Task<VolunteerDto> GetVolunteerByIdAsync(int id);
        Task<VolunteerDto> CreateVolunteerAsync(VolunteerCreateDto volunteerDto);
        Task<bool> UpdateVolunteerAsync(int id, VolunteerUpdateDto volunteerDto);
        Task<bool> DeleteVolunteerAsync(int id);
    }
}
