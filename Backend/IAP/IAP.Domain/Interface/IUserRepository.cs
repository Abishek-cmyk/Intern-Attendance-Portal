using IAP.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAP.Domain.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetUserByIdAsync(int id);

        Task CreateUserAsync(User user);

        Task<bool> UpdateUserByIdAsync(int id, User user);
        Task<bool> DeleteUserByIdAsync(int id);
        Task saveAsync();

        Task<bool> IsUserExistByEmailAsync(string email);


    }
}
