using AutoMapper;
using FluentValidation;
using JobTracking.Common.Abstract;
using JobTracking.Common.ComplextTypes;
using JobTracking.Common.ResponseObjects;
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

    public async Task<IResponse<CategoryCreateDto>> CreateAsync(CategoryCreateDto dto)
    {
        var validationResult = _categoryCreateDtoValidator.Validate(dto);
        if (validationResult.IsValid)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepository.CreateAsync(category);

            return new Response<CategoryCreateDto>(ResponseType.Success, dto);
        }
        return new Response<CategoryCreateDto>(ResponseType.ValidationError, validationResult.CustomValidationErrors());
    }

    public async Task<IResponse<List<CategoryListDto>>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync(x => x.IsActive & !x.IsDeleted);
        var categoryDto = _mapper.Map<List<CategoryListDto>>(categories);

        return new Response<List<CategoryListDto>>(ResponseType.Success, categoryDto);
    }

    public async Task<IResponse<CategoryUpdateDto>> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return new Response<CategoryUpdateDto>(ResponseType.NotFound, "Kategori bulunamadı");

        if (category.IsActive && !category.IsDeleted)
        {
            var categoryDto = _mapper.Map<CategoryUpdateDto>(category);

            return new Response<CategoryUpdateDto>(ResponseType.Success, categoryDto);
        }

        return new Response<CategoryUpdateDto>(ResponseType.NotFound, "Kategori bulunamadı");
    }

    public async Task<IResponse<CategoryUpdateDto>> GetByIdPassiveAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return new Response<CategoryUpdateDto>(ResponseType.NotFound, "Kategori bulunamadı");

        if (!category.IsActive && !category.IsDeleted)
        {
            var categoryDto = _mapper.Map<CategoryUpdateDto>(category);

            return new Response<CategoryUpdateDto>(ResponseType.Success, categoryDto);
        }

        return new Response<CategoryUpdateDto>(ResponseType.NotFound, "Kategori bulunamadı");
    }

    public async Task<IResponse<List<CategoryListDto>>> GetNotActiveAllList()
    {
        var categories = await _categoryRepository.GetAllAsync(x => !x.IsActive & !x.IsDeleted);
        var categoryDto = _mapper.Map<List<CategoryListDto>>(categories);
        return new Response<List<CategoryListDto>>(ResponseType.Success, categoryDto);
    }

    public Task<IResponse> RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto dto)
    {
        var validResult = _categoryUpdateDtoValidator.Validate(dto);
        if (validResult.IsValid)
        {
            var updatedEntity = await _categoryRepository.GetByIdAsync(dto.Id);
            if (updatedEntity is not null)
            {
                var category = _mapper.Map<Category>(dto);
                category.ModifiedDate = DateTime.UtcNow;
                await _categoryRepository.Update(category, updatedEntity);

                return new Response<CategoryUpdateDto>(ResponseType.Success, dto);
            }
            return new Response<CategoryUpdateDto>(ResponseType.NotFound, "Kategori bulunamdı");
        }
        return new Response<CategoryUpdateDto>(ResponseType.ValidationError, validResult.CustomValidationErrors());
    }
}
