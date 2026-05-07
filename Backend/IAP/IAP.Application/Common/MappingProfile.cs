using AutoMapper;
using IAP.Application.DTOs.Company;
using IAP.Application.DTOs.User;
using IAP.Domain.Entity;

namespace IAP.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Company, CompanyDTO>().ReverseMap();

            CreateMap<CreateCompanyDTO, Company>().ReverseMap();

            CreateMap<UpdateCompanyDTO, Company>().ReverseMap();
        }
    }
}