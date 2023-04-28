using AutoMapper;
using JobTracking.Common.Abstract;
using JobTracking.Common.ComplextTypes;
using JobTracking.Common.ResponseObjects;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Repositories.Abstract;
using JobTracking.Servives.Abstract;

namespace JobTracking.Servives.Manager;

public class AppUserManager : IAppUserService
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly IMapper _mapper;

    public AppUserManager(IAppUserRepository appUserRepository, IMapper mapper)
    {
        _appUserRepository = appUserRepository;
        _mapper = mapper;
    }

    public async Task<IResponse<List<AppUserListDto>>> NonAdminUsersAsync()
    {
        var appUser = await _appUserRepository.NonAdminUsersAsync();
        var appUserDto = _mapper.Map<List<AppUserListDto>>(appUser);

        return new Response<List<AppUserListDto>>(ResponseType.Success, appUserDto);
    }

    public IResponse<List<AppUserListDto>> NonAdminUsers(out int totalPage, string search, int activePage = 1, int pageCount = 10)
    {
        var appUser = _appUserRepository.NonAdminUsers(out totalPage, search, activePage, pageCount);
        var appUserDto = _mapper.Map<List<AppUserListDto>>(appUser);

        return new Response<List<AppUserListDto>>(ResponseType.Success, appUserDto);
    }
}
