using AutoMapper;
using IAP.Application.DTOs.Company;
using IAP.Application.DTOs.SystemSetting;
using IAP.Application.DTOs.User;
using IAP.Domain.Entity;
using IAP.Domain.Helper;

namespace IAP.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();

            CreateMap<User, UserDTO>()
                    .ForMember(dest => dest.CreatedAt,
                        opt => opt.MapFrom(src => DateTimeIST.ConvertUtcToIst(src.CreatedAt)))
                    .ForMember(dest => dest.UpdatedAt,
                        opt => opt.MapFrom(src => DateTimeIST.ConvertUtcToIst(src.UpdatedAt)))
                    .ReverseMap();

            CreateMap<UpdateUserDTO, User>().ReverseMap();

            CreateMap<Company, CompanyDTO>()
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(src =>
                        DateTimeIST.ConvertUtcToIst(src.CreatedAt)))
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src =>
                        DateTimeIST.ConvertUtcToIst(src.UpdatedAt)))
                .ReverseMap();

            CreateMap<CreateCompanyDTO, Company>().ReverseMap();

            CreateMap<UpdateCompanyDTO, Company>().ReverseMap();

            //System Setiing by Abi
            CreateMap<SystemSetting, SystemSettingDTO>().ReverseMap();

            CreateMap<CreateSystemSettingDTO, SystemSetting>().ReverseMap();

            CreateMap<UpdateSystemSettingDTO, SystemSetting > ().ReverseMap();


        }
    }
}