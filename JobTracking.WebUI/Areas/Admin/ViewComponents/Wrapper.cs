using AutoMapper;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Admin.ViewComponents;

public class Wrapper : ViewComponent
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public Wrapper(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public IViewComponentResult Invoke()
    {
        var user = _userManager.FindByNameAsync(User.Identity!.Name).Result;
        var userDto = _mapper.Map<AppUserProfileDto>(user);
        return View(userDto);
    }
}
