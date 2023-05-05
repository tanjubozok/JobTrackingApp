using AutoMapper;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.ViewComponents;

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

        var userRole = _userManager.GetRolesAsync(user).Result;
        if (userRole.Contains("Admin"))
            return View(userDto);
        return View("Member", userDto);
    }
}
