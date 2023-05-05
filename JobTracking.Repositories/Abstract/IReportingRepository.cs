using JobTracking.Entities.Models;

namespace JobTracking.Repositories.Abstract;

public interface IReportingRepository : IBaseRepository<Reporting>
{
    Task<List<Reporting>> GetAllByWorkingIdAsync(int workingId);
}