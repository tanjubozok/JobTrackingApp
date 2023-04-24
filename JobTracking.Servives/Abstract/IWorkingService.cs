using JobTracking.Dtos.WorkingDtos;

namespace JobTracking.Servives.Abstract;

public interface IWorkingService
{
    Task<List<WorkingListDto>> GetAllAsync();
    Task<List<WorkingListDto>> GetAllWithCategoryAsync();
    Task<WorkingListDto> GetByIdAsync(int id);
    Task<WorkingCreateDto> CreateAsync(WorkingCreateDto dto);
    Task<WorkingUpdateDto> UpdateAsync(WorkingUpdateDto dto);
}
