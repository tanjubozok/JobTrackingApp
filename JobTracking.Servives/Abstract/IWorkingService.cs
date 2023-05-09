using JobTracking.Common.Abstract;
using JobTracking.Dtos.GraphicDtos;
using JobTracking.Dtos.WorkingDtos;

namespace JobTracking.Services.Abstract;

public interface IWorkingService
{
    Task<IResponse<List<WorkingListDto>>> GetAllAsync();
    Task<IResponse<List<WorkingTableListDto>>> GetAllTableAsync();
    Task<IResponse<List<WorkingTableListDto>>> GetAllTableAsync(int appUserId);
    Task<IResponse<List<WorkingTableListDto>>> GetAllTableCompleteAsync(int appUserId);
    Task<IResponse<List<WorkingListDto>>> GetAllWithCategoryAsync();
    Task<IResponse<List<WorkingListDto>>> GetAllByAppUserId(int appUserId);
    Task<IResponse<WorkingListDto>> GetAllByIdWithCategoryAsync(int id);
    Task<IResponse<WorkingUpdateDto>> GetByIdAsync(int id);
    Task<IResponse<WorkingCreateDto>> CreateAsync(WorkingCreateDto dto);
    Task<IResponse<WorkingUpdateDto>> UpdateAsync(WorkingUpdateDto dto);
    Task<IResponse<WorkingUpdateDto>> DoneWorking(int workingId);
    Task<int> GetNumberOfReportsWrittenAsync(int appUserId);
    Task<int> GetNumberOfTasksCompletedAsync(int appUserId);
    Task<int> GetNumberOfTaskToCompleteAsync(int appUserId);
    Task<IResponse<List<GraphicListDto>>> MostCompletedStaffAsync();
    Task<IResponse<List<GraphicListDto>>> MostEmployedStaffAsync();
    Task<int> GetNumberOfTaskPendingAssignmentAsync();
    Task<int> GetNumberOfCompletedTaskAsync();
}