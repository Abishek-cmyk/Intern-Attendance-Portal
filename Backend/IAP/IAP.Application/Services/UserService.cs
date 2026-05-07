using IAP.Domain.Entity;
using IAP.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAP.Application.Services
{
    public class UserService
    {
        public readonly IUserRepository _userRepo;
        public UserService(IUserRepository UserRepo)
        {
            _userRepo = UserRepo;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userRepo.GetUserByIdAsync(id);
        }

        public async Task<bool> CreateUserAsync(User NewUser)
        {
            var isExist = await _userRepo.IsUserExistByEmailAsync(NewUser.Email);
            if (isExist)
                return false;

            var Password = NewUser.PasswordHash;
            NewUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);
            NewUser.CreatedAt = DateTime.UtcNow;

            await _userRepo.CreateUserAsync(NewUser);
            return true;

        }


        // Update User
        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            user.UpdatedAt = DateTime.UtcNow;

            return await _userRepo.UpdateUserByIdAsync(id, user);
        }


        // Delete User
        public async Task<bool> DeleteUserAsync(int id)
        {
            var existingUser = await _userRepo.GetUserByIdAsync(id);

            if (existingUser == null)
                return false;

            await _userRepo.DeleteUserByIdAsync(id);

            return true;
        }
    }
}
