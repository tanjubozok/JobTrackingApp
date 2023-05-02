using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Authorize(Roles = "Admin,Member")]
public class ProfileController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly INotyfService _notifyService;
    private readonly IMapper _mapper;

    public ProfileController(UserManager<AppUser> userManager, INotyfService notifyService, IMapper mapper)
    {
        _userManager = userManager;
        _notifyService = notifyService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        TempData["MenuActive"] = "Profile";

        var appUser = await _userManager.FindByNameAsync(User.Identity!.Name);
        var appUserDto = _mapper.Map<AppUserProfileDto>(appUser);
        return View(appUserDto);
    }

    [HttpPost]
    public IActionResult Index(AppUserProfileDto dto)
    {
        if (ModelState.IsValid)
        {

        }
        return View(dto);
    }
}
