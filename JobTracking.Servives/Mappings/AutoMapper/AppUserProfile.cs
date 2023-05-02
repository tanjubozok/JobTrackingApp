using AutoMapper;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Entities.Models;

namespace JobTracking.Servives.Mappings.AutoMapper;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, AppUserLoginDto>().ReverseMap();
        CreateMap<AppUser, AppUserRegisterDto>().ReverseMap();
        CreateMap<AppUser, AppUserListDto>().ReverseMap();
        CreateMap<AppUser, AppUserProfileDto>().ReverseMap();
    }
}
