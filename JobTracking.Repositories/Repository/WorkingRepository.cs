using JobTracking.Dtos.GraphicDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Repositories.Repository;

public class WorkingRepository : BaseRepository<Working>, IWorkingRepository
{
    public WorkingRepository(DatabaseContext context)
        : base(context)
    {
    }

    public async Task<List<Working>> GetAllTableAsync()
    {
        //var result = (from work in _context.Workings
        //              join category in _context.Categories! on work.CategoryId equals category.Id
        //                into workCategory
        //              from category in workCategory.DefaultIfEmpty()
        //              join user in _context.Users on work.AppUserId equals user.Id
        //                into workUser
        //              from user in workUser.DefaultIfEmpty()
        //              join report in _context.Reportings! on work.Id equals report.WorkingId
        //                into workReport
        //              from report in workReport.DefaultIfEmpty()
        //              select new Working
        //              {
        //                  Id = work.Id,
        //                  CreatedDate = work.CreatedDate,
        //                  Definition = work.Definition,
        //                  Description = work.Description,
        //                  Status = work.Status,
        //                  Category = category,
        //                  AppUser = user,
        //                  Reportings = work.Reportings
        //              })
        //              .OrderByDescending(x => x.CreatedDate);

        var result = _context.Workings!
            .Include(x => x.AppUser)
            .Include(x => x.Category)
            .Include(x => x.Reportings)
            .Select(work => new Working
            {
                Id = work.Id,
                CreatedDate = work.CreatedDate,
                Definition = work.Definition,
                Description = work.Description,
                Status = work.Status,
                Category = work.Category,
                AppUser = work.AppUser,
                Reportings = work.Reportings
            });

        return await result
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Working>> GetAllTableAsync(int appUserId)
    {
        var result = _context.Workings!
            .Include(x => x.AppUser)
            .Include(x => x.Category)
            .Include(x => x.Reportings)
            .Where(x => x.AppUserId == appUserId && !x.Status);

        return await result
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Working>> GetAllTableCompleteAsync(int appUserId)
    {
        var result = _context.Workings!
            .Include(x => x.AppUser)
            .Include(x => x.Category)
            .Include(x => x.Reportings)
            .Where(x => x.AppUserId == appUserId && x.Status);

        return await result
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Working?> GetByIdWithCategoryAsync(int id)
    {
        var result = from work in _context.Workings
                     join category in _context.Categories! on work.CategoryId equals category.Id
                     where (!category.IsDeleted && category.IsActive && work.Id == id)
                     select new Working
                     {
                         Id = work.Id,
                         CategoryId = work.CategoryId,
                         CreatedDate = work.CreatedDate,
                         Definition = work.Definition,
                         Description = work.Description,
                         Status = work.Status,
                         Category = category
                     };

        return await result
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<List<Working>> GetAllWithCategoryAsync()
    {
        var result = (from work in _context.Workings
                      join category in _context.Categories! on work.CategoryId equals category.Id
                      where (!category.IsDeleted && category.IsActive)
                      select new Working
                      {
                          Id = work.Id,
                          CategoryId = work.CategoryId,
                          CreatedDate = work.CreatedDate,
                          Definition = work.Definition,
                          Description = work.Description,
                          Status = work.Status,
                          Category = category
                      })
                      .OrderByDescending(x => x.CreatedDate);

        return await result
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Working>> GetAllByAppUserId(int appUserId)
    {
        var result = from work in _context.Workings
                     where (work.AppUserId == appUserId)
                     select new Working
                     {
                         Id = work.Id,
                         AppUserId = work.AppUserId,
                         CategoryId = work.CategoryId,
                         CreatedDate = work.CreatedDate,
                         Definition = work.Definition,
                         Description = work.Description,
                         Status = work.Status
                     };

        return await result
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> GetNumberOfReportsWrittenAsync(int appUserId)
    {
        var result = _context.Workings!
            .Include(x => x.Reportings)
            .Where(x => x.AppUserId == appUserId);

        return await result
            .AsNoTracking()
            .CountAsync();
    }

    public async Task<int> GetNumberOfTasksCompletedAsync(int appUserId)
    {
        var result = _context.Workings!
            .Where(x => x.AppUserId == appUserId && x.Status);

        return await result
            .AsNoTracking()
            .CountAsync();
    }

    public async Task<int> GetNumberOfTaskToCompleteAsync(int appUserId)
    {
        var result = _context.Workings!
            .Where(x => x.AppUserId == appUserId && !x.Status);

        return await result
            .AsNoTracking()
            .CountAsync();
    }

    public async Task<List<GraphicListDto>> MostCompletedStaffAsync()
    {
        var result = _context.Workings!
            .Include(x => x.AppUser)
            .Where(x => x.Status)
            .GroupBy(x => x.AppUser!.UserName)
            .OrderByDescending(x => x.Count())
            .Take(5)
            .Select(x => new GraphicListDto
            {
                Username = x.Key,
                TaskCount = x.Count(),
            });

        return await result
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<GraphicListDto>> MostEmployedStaffAsync()
    {
        var result = _context.Workings!
            .Include(x => x.AppUser)
            .Where(x => !x.Status && x.AppUser != null)
            .GroupBy(x => x.AppUser!.UserName)
            .OrderByDescending(x => x.Count())
            .Take(5)
            .Select(x => new GraphicListDto
            {
                Username = x.Key,
                TaskCount = x.Count(),
            });

        return await result
            .AsNoTracking()
            .ToListAsync();
    }
}
