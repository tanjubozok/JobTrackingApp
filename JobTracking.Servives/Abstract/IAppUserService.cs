using JobTracking.Common.Abstract;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Entities.Models;

namespace JobTracking.Servives.Abstract;

public interface IAppUserService
{
    Task<IResponse<List<AppUserListDto>>> NonAdminUsersAsync();
    IResponse<List<AppUserListDto>> NonAdminUsers(out int totalPage, string search, int activePage = 1, int pageCount = 10);
}
