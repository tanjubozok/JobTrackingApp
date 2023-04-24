using AutoMapper;
using FluentValidation;
using JobTracking.Dtos.CategoryDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Servives.Abstract;
using JobTracking.Servives.Extensions;

namespace JobTracking.Servives.Manager;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CategoryCreateDto> _categoryCreateDtoValidator;
    private readonly IValidator<CategoryUpdateDto> _categoryUpdateDtoValidator;

    public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CategoryCreateDto> categoryCreateDtoValidator, IValidator<CategoryUpdateDto> categoryUpdateDtoValidator)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryCreateDtoValidator = categoryCreateDtoValidator;
        _categoryUpdateDtoValidator = categoryUpdateDtoValidator;
    }

    public Task<CategoryCreateDto> CreateAsync(CategoryCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryListDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryUpdateDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryUpdateDto> GetByIdPassiveAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryListDto>> GetNotActiveAllList()
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryUpdateDto> UpdateAsync(CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
