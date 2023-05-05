using JobTracking.Entities.Models;

namespace JobTracking.Repositories.Abstract;

public interface IWorkingRepository : IBaseRepository<Working>
{
    Task<List<Working>> GetAllWithCategoryAsync();
    Task<List<Working>> GetAllTableAsync();
    Task<List<Working>> GetAllTableAsync(int appUserId);
    Task<Working?> GetByIdWithCategoryAsync(int id);
    Task<List<Working>> GetAllByAppUserId(int appUserId);
}
