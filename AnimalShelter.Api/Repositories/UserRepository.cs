using AnimalShelter.Api.Data;
using AnimalShelter.Api.Models;
using AnimalShelter.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AnimalShelterDbContext _dbcontext; 

        public UserRepository(AnimalShelterDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _dbcontext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _dbcontext.Users.FindAsync(id);
        }

        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            _dbcontext.Users.Update(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _dbcontext.Users.FindAsync(id);
            if (user == null) return false;

            _dbcontext.Users.Remove(user);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
