using JobTracking.Dtos.GraphicDtos;
using JobTracking.Entities.Models;

namespace JobTracking.Repositories.Abstract;

public interface IWorkingRepository : IBaseRepository<Working>
{
    Task<List<Working>> GetAllWithCategoryAsync();
    Task<List<Working>> GetAllTableAsync();
    Task<List<Working>> GetAllTableAsync(int appUserId);
    Task<Working?> GetByIdWithCategoryAsync(int id);
    Task<List<Working>> GetAllByAppUserId(int appUserId);
    Task<List<Working>> GetAllTableCompleteAsync(int appUserId);
    Task<int> GetNumberOfReportsWrittenAsync(int appUserId);
    Task<int> GetNumberOfTasksCompletedAsync(int appUserId);
    Task<int> GetNumberOfTaskToCompleteAsync(int appUserId);
    Task<List<GraphicListDto>> MostCompletedStaffAsync();
    Task<List<GraphicListDto>> MostEmployedStaffAsync();
}
