using AutoMapper;
using JobTracking.Dtos.CategoryDtos;
using JobTracking.Entities.Models;

namespace JobTracking.Servives.Mappings.AutoMapper;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        this.CreateMap<Category, CategoryListDto>().ReverseMap();
        this.CreateMap<Category, CategoryCreateDto>().ReverseMap();
        this.CreateMap<Category, CategoryUpdateDto>().ReverseMap();
    }
}