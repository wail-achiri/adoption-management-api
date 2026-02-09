using AnimalShelter.Api.Models;

namespace AnimalShelter.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> CreateUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(int id);
    }
}
