using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Repositories.Repository;

public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
{
    public AppUserRepository(DatabaseContext context) 
        : base(context)
    {
    }

    public async Task<List<AppUser>> NonAdminUsersAsync()
    {
        var result = from u in _context.Users
                     join ur in _context.UserRoles on u.Id equals ur.UserId
                     join r in _context.Roles on ur.RoleId equals r.Id
                     where r.Name == "Member"
                     select new AppUser
                     {
                         Id = u.Id,
                         Name = u.Name,
                         Surname = u.Surname,
                         UserName = u.UserName,
                         Email = u.Email,
                         ProfileImage = u.ProfileImage
                     };

        return await result
            .AsNoTracking()
            .ToListAsync();
    }

    public List<AppUser> NonAdminUsers(out int totalPage, string search, int activePage = 1, int pageCount = 10)
    {
        var result = from u in _context.Users
                     join ur in _context.UserRoles on u.Id equals ur.UserId
                     join r in _context.Roles on ur.RoleId equals r.Id
                     where r.Name == "Member"
                     select new AppUser
                     {
                         Id = u.Id,
                         Name = u.Name,
                         Surname = u.Surname,
                         UserName = u.UserName,
                         Email = u.Email,
                         ProfileImage = u.ProfileImage
                     };

        totalPage = (int)Math.Ceiling((double)result.Count() / pageCount);

        if (!string.IsNullOrWhiteSpace(search))
        {
            result = result.Where(x => x.Name!.ToLower().Contains(search.ToLower()) || x.Surname!.ToLower().Contains(search.ToLower()));
            totalPage = (int)Math.Ceiling((double)result.Count() / pageCount);
        }
        result = result.Skip((activePage - 1) * pageCount).Take(pageCount);

        return result
            .AsNoTracking()
            .ToList();
    }
}
