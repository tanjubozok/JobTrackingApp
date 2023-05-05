using JobTracking.Common.Abstract;
using JobTracking.Dtos.WorkingDtos;

namespace JobTracking.Services.Abstract;

public interface IWorkingService
{
    Task<IResponse<List<WorkingListDto>>> GetAllAsync();
    Task<IResponse<List<WorkingTableListDto>>> GetAllTableAsync();
    Task<IResponse<List<WorkingTableListDto>>> GetAllTableAsync(int appUserId);
    Task<IResponse<List<WorkingListDto>>> GetAllWithCategoryAsync();
    Task<IResponse<List<WorkingListDto>>> GetAllByAppUserId(int appUserId);
    Task<IResponse<WorkingListDto>> GetAllByIdWithCategoryAsync(int id);
    Task<IResponse<WorkingUpdateDto>> GetByIdAsync(int id);
    Task<IResponse<WorkingCreateDto>> CreateAsync(WorkingCreateDto dto);
    Task<IResponse<WorkingUpdateDto>> UpdateAsync(WorkingUpdateDto dto);
}