using IAP.Domain.Data;
using IAP.Domain.Entity;
using IAP.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAP.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbcontext.Users.AddAsync(user);
            await saveAsync();
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var user = await _dbcontext.Users.FindAsync(id);
            if (user != null)
            {
                _dbcontext.Users.Remove(user);
                await saveAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var Users = await _dbcontext.Users.ToListAsync();
            return Users;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var User = await _dbcontext.Users.FindAsync(id);
            return User;

        }

        public async Task<bool> IsUserExistByEmailAsync(string email)
        {
            return await _dbcontext.Users.AnyAsync(x => x.Email == email);

        }

        public async Task saveAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> UpdateUserByIdAsync(int id, User user)
        {
            var existingUser = await _dbcontext.Users.FindAsync(id);
            if (existingUser == null)
                return false;

            existingUser.EmployeeId = user.EmployeeId;
            existingUser.Status = user.Status;
            existingUser.Role = user.Role;
            existingUser.Email = user.Email;
            existingUser.Name = user.Name;
            existingUser.CompanyId = user.CompanyId;
            existingUser.UpdatedAt = DateTime.UtcNow;

            await saveAsync();

            return true;

        }
    }
}
