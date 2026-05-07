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
    }
}
