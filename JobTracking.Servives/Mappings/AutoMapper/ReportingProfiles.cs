﻿using AutoMapper;
using JobTracking.Dtos.ReportingDtos;
using JobTracking.Entities.Models;

namespace JobTracking.Services.Mappings.AutoMapper;

public class ReportingProfiles : Profile
{
    public ReportingProfiles()
    {
        CreateMap<Reporting, ReportingListDto>().ReverseMap();
        CreateMap<Reporting, ReportingCreateDto>().ReverseMap();
        CreateMap<Reporting, ReportingEditDto>().ReverseMap();
    }
}
