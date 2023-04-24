using JobTracking.Dtos.CategoryDtos;

namespace JobTracking.Servives.Abstract;

public interface ICategoryService
{
    Task<List<CategoryListDto>> GetAllAsync();
    Task<List<CategoryListDto>> GetNotActiveAllList();
    Task<CategoryUpdateDto> GetByIdAsync(int id);
    Task<CategoryUpdateDto> GetByIdPassiveAsync(int id);
    Task<CategoryCreateDto> CreateAsync(CategoryCreateDto dto);
    Task<CategoryUpdateDto> UpdateAsync(CategoryUpdateDto dto);
    Task RemoveAsync(int id);
}
