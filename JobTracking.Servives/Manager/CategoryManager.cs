using AutoMapper;
using JobTracking.Common.Abstract;
using JobTracking.Common.ComplextTypes;
using JobTracking.Common.ResponseObjects;
using JobTracking.Dtos.CategoryDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Servives.Abstract;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Servives.Manager;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CategoryCreateDto>> CreateAsync(CategoryCreateDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        category.IsDeleted = false;
        category.IsActive = dto.IsActive;
        category.CreatedDate = DateTime.UtcNow;
        var data = await _categoryRepository.CreateAsync(category);
        var result = await _unitOfWork.CommitAsync();
        if (result > 0)
        {
            var categoryDto = _mapper.Map<CategoryCreateDto>(data);
            return new Response<CategoryCreateDto>(ResponseType.Success, categoryDto);
        }
        return new Response<CategoryCreateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
    }

    public async Task<IResponse<List<CategoryListDto>>> GetAllAsync()
    {
        var categories = await _categoryRepository
            .GetQuery(x => x.IsActive & !x.IsDeleted)
            .OrderBy(x => x.CreatedDate)
            .ToListAsync();

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

    public Task<IResponse<CategoryUpdateDto>> GetByIdPassiveAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<List<CategoryListDto>>> GetNotActiveAllList()
    {
        var categories = await _categoryRepository
            .GetQuery(x => !x.IsActive & !x.IsDeleted)
            .OrderBy(x => x.CreatedDate)
            .ToListAsync();

        var categoryDto = _mapper.Map<List<CategoryListDto>>(categories);
        return new Response<List<CategoryListDto>>(ResponseType.Success, categoryDto);
    }

    public Task<IResponse> RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto dto)
    {
        var updatedEntity = await _categoryRepository.GetByIdAsync(dto.Id);
        if (updatedEntity is not null)
        {
            var category = _mapper.Map<Category>(dto);
            category.ModifiedDate = DateTime.UtcNow;
            category.CreatedDate = updatedEntity.CreatedDate;
            _categoryRepository.Update(category, updatedEntity);
            var result = await _unitOfWork.CommitAsync();
            if (result > 0)
                return new Response<CategoryUpdateDto>(ResponseType.Success);
            return new Response<CategoryUpdateDto>(ResponseType.SaveError, "Kayıt sırasında hata oluştu");
        }
        return new Response<CategoryUpdateDto>(ResponseType.NotFound, "Kategori bulunamdı");
    }
}
