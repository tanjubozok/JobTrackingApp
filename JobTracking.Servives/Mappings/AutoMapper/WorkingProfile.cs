using AutoMapper;
using JobTracking.Dtos.WorkingDtos;
using JobTracking.Entities.Models;

namespace JobTracking.Servives.Mappings.AutoMapper;

public class WorkingProfile : Profile
{
    public WorkingProfile()
    {
        this.CreateMap<Working, WorkingListDto>().ReverseMap();
        this.CreateMap<Working, WorkingCreateDto>().ReverseMap();
        this.CreateMap<Working, WorkingUpdateDto>().ReverseMap();
    }
}