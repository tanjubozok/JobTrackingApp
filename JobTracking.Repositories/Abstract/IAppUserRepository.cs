using JobTracking.Entities.Models;

namespace JobTracking.Repositories.Abstract;

public interface IAppUserRepository : IBaseRepository<AppUser>
{
    Task<List<AppUser>> NonAdminUsersAsync();
    List<AppUser> NonAdminUsers(out int totalPage, string search, int activePage = 1, int pageCount = 10);
}
