using AutoMapper;
using IAP.Application.DTOs.User;
using IAP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAP.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}
