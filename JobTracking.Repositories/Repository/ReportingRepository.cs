using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;

namespace JobTracking.Repositories.Repository;

public class ReportingRepository : BaseRepository<Reporting>, IReportingRepository
{
    public ReportingRepository(DatabaseContext context) : base(context)
    {
    }
}