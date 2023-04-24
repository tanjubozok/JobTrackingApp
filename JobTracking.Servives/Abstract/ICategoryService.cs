using JobTracking.Common.Abstract;
using JobTracking.Dtos.CategoryDtos;

namespace JobTracking.Servives.Abstract;

public interface ICategoryService
{
    Task<IResponse<List<CategoryListDto>>> GetAllAsync();
    Task<IResponse<List<CategoryListDto>>> GetNotActiveAllList();
    Task<IResponse<CategoryUpdateDto>> GetByIdAsync(int id);
    Task<IResponse<CategoryUpdateDto>> GetByIdPassiveAsync(int id);
    Task<IResponse<CategoryCreateDto>> CreateAsync(CategoryCreateDto dto);
    Task<IResponse<CategoryUpdateDto>> UpdateAsync(CategoryUpdateDto dto);
    Task<IResponse> RemoveAsync(int id);
}