using AnimalShelter.Api.DTO;
using AnimalShelter.Api.Models;
using AnimalShelter.Api.Models.Enums;
using AnimalShelter.Api.Repositories.Interfaces;
using AnimalShelter.Api.Services.Interfaces;

namespace AnimalShelter.Api.Services
{
    public class AdopterService : IAdopterService
    {
        private readonly IUserRepository _userRepository;

        public AdopterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<AdopterDto>> GetAllAdoptersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users
                .Where(u => u.Rol == UserRol.ADOPTER)
                .Select(u => new AdopterDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Lastname = u.Lastname,
                    Email = u.Email,
                    Rol = u.Rol.ToString(),
                    State = u.State.ToString()
                });
        }

        public async Task<AdopterDto> GetAdopterByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null || user.Rol != UserRol.ADOPTER) return null;

            return new AdopterDto
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Email = user.Email,
                Rol = user.Rol.ToString(),
                State = user.State.ToString()
            };
        }

        public async Task<AdopterDto> CreateAdopterAsync(AdopterCreateDto adopterDto)
        {
            var user = new UserModel
            {
                Name = adopterDto.Name,
                Lastname = adopterDto.Lastname,
                Email = adopterDto.Email,
                Password = adopterDto.Password ?? string.Empty,
                Rol = UserRol.ADOPTER,
                State = Enum.TryParse<UserState>(adopterDto.State, true, out var s) ? s : UserState.ACTIVE
            };

            var created = await _userRepository.CreateUserAsync(user);

            return new AdopterDto
            {
                Id = created.Id,
                Name = created.Name,
                Lastname = created.Lastname,
                Email = created.Email,
                Rol = created.Rol.ToString(),
                State = created.State.ToString()
            };
        }

        public async Task<bool> UpdateAdopterAsync(int id, AdopterUpdateDto adopterDto)
        {
            var existing = await _userRepository.GetUserByIdAsync(id);
            if (existing == null || existing.Rol != UserRol.ADOPTER) return false;

            existing.Name = adopterDto.Name ?? existing.Name;
            existing.Lastname = adopterDto.Lastname ?? existing.Lastname;
            existing.Email = adopterDto.Email ?? existing.Email;
            if (!string.IsNullOrEmpty(adopterDto.State) && Enum.TryParse<UserState>(adopterDto.State, true, out var s))
                existing.State = s;

            await _userRepository.UpdateUserAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAdopterAsync(int id)
        {
            var existing = await _userRepository.GetUserByIdAsync(id);
            if (existing == null || existing.Rol != UserRol.ADOPTER) return false;

            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
