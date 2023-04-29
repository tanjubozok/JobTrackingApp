using JobTracking.Entities.Models;

namespace JobTracking.Repositories.Abstract;

public interface IWorkingRepository : IBaseRepository<Working>
{
    Task<List<Working>> GetAllWithCategoryAsync();
    Task<List<Working>> GetAllTableAsync();
    Task<Working?> GetByIdWithCategoryAsync(int id);
    Task<List<Working>> GetAllByAppUserId(int appUserId);
}
