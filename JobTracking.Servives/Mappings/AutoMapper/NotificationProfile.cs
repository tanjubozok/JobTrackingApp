using AutoMapper;
using JobTracking.Dtos.NotificationDtos;
using JobTracking.Entities.Models;

namespace JobTracking.Services.Mappings.AutoMapper;

public class NotificationProfile : Profile
{
    public NotificationProfile()
    {
        CreateMap<Notification, NotificationCreateDto>().ReverseMap();
    }
}
