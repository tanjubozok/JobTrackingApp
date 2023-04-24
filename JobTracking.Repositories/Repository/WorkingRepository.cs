using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Repositories.Repository;

public class WorkingRepository : BaseRepository<Working>, IWorkingRepository
{
    private readonly DatabaseContext _databaseContext;

    public WorkingRepository(DatabaseContext context) : base(context)
    {
        _databaseContext = context;
    }

    public async Task<List<Working>> GetAllWithCategoryAsync()
    {
        return await (from i in _databaseContext.Workings
                      join c in _databaseContext.Categories! on i.CategoryId equals c.Id
                      where (!c.IsDeleted && c.IsActive)
                      select new Working
                      {
                          Id = i.Id,
                          CategoryId = i.CategoryId,
                          CreatedDate = i.CreatedDate,
                          Definition = i.Definition,
                          Description = i.Description,
                          Status = i.Status,
                          Category = c
                      }).ToListAsync();
    }
}
