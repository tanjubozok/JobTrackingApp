using JobTracking.Common.Abstract;
using JobTracking.Dtos.AppUserDtos;

namespace JobTracking.Services.Abstract;

public interface IAppUserService
{
    Task<IResponse<List<AppUserListDto>>> NonAdminUsersAsync();
    IResponse<List<AppUserListDto>> NonAdminUsers(out int totalPage, string search, int activePage = 1, int pageCount = 10);
}
