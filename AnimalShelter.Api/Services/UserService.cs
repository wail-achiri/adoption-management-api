using AnimalShelter.Api.DTO;
using AnimalShelter.Api.Models;
using AnimalShelter.Api.Models.Enums;
using AnimalShelter.Api.Repositories.Interfaces;
using AnimalShelter.Api.Services.Interfaces;

namespace AnimalShelter.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<VolunteerDto>> GetAllVolunteersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users
                .Where(u => u.Rol == UserRol.VOLUNTEER)
                .Select(u => new VolunteerDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Lastname = u.Lastname,
                    Email = u.Email,
                    Rol = u.Rol.ToString(),
                    State = u.State.ToString()
                });
        }

        public async Task<VolunteerDto> GetVolunteerByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null || user.Rol != UserRol.VOLUNTEER) return null;

            return new VolunteerDto
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Email = user.Email,
                Rol = user.Rol.ToString(),
                State = user.State.ToString()
            };
        }

        public async Task<VolunteerDto> CreateVolunteerAsync(VolunteerCreateDto volunteerDto)
        {
            var user = new UserModel
            {
                Name = volunteerDto.Name,
                Lastname = volunteerDto.Lastname,
                Email = volunteerDto.Email,
                // default password handling omitted - in real apps hash & validate
                Password = volunteerDto.Password ?? string.Empty,
                Rol = UserRol.VOLUNTEER,
                State = Enum.TryParse<UserState>(volunteerDto.State, true, out var s) ? s : UserState.ACTIVE
            };

            var created = await _userRepository.CreateUserAsync(user);

            return new VolunteerDto
            {
                Id = created.Id,
                Name = created.Name,
                Lastname = created.Lastname,
                Email = created.Email,
                Rol = created.Rol.ToString(),
                State = created.State.ToString()
            };
        }

        public async Task<bool> UpdateVolunteerAsync(int id, VolunteerUpdateDto volunteerDto)
        {
            var existing = await _userRepository.GetUserByIdAsync(id);
            if (existing == null || existing.Rol != UserRol.VOLUNTEER) return false;

            existing.Name = volunteerDto.Name ?? existing.Name;
            existing.Lastname = volunteerDto.Lastname ?? existing.Lastname;
            existing.Email = volunteerDto.Email ?? existing.Email;
            if (!string.IsNullOrEmpty(volunteerDto.State) && Enum.TryParse<UserState>(volunteerDto.State, true, out var s))
                existing.State = s;

            await _userRepository.UpdateUserAsync(existing);
            return true;
        }

        public async Task<bool> DeleteVolunteerAsync(int id)
        {
            var existing = await _userRepository.GetUserByIdAsync(id);
            if (existing == null || existing.Rol != UserRol.VOLUNTEER) return false;

            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
