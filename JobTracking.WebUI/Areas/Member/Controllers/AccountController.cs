using JobTracking.Dtos.AppUserDtos;
using JobTracking.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area("Account")]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public AccountController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Login()
    {
        return View(new AppUserLoginDto());
    }

    [HttpPost]
    public IActionResult Login(AppUserLoginDto dto)
    {
        return View();
    }

    public IActionResult Register()
    {
        return View(new AppUserRegisterDto());
    }

    [HttpPost]
    public IActionResult Register(AppUserRegisterDto dto)
    {
        return View();
    }

    public IActionResult Logout()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
