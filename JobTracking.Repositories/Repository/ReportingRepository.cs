using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Repositories.Repository;

public class ReportingRepository : BaseRepository<Reporting>, IReportingRepository
{
    public ReportingRepository(DatabaseContext context)
        : base(context)
    {
    }

    public async Task<List<Reporting>> GetAllByWorkingIdAsync(int workingId)
    {
        var list = _context.Reportings!
            .Include(x => x.Working)
            .Where(x => x.WorkingId == workingId)
            .AsQueryable();

        return await list
            .AsNoTracking()
            .OrderByDescending(x => x.Id)
            .ToListAsync();
    }
}