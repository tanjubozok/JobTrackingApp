using AspNetCoreHero.ToastNotification.Abstractions;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area("Member")]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly INotyfService _notifyService;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, INotyfService notifyService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _notifyService = notifyService;
    }

    public IActionResult Login()
    {
        return View(new AppUserLoginDto());
    }

    [HttpPost]
    public async Task<IActionResult> Login(AppUserLoginDto dto)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user is not null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, false);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    return RedirectToAction("Index", "Profile", new { area = "Member" });
                }
            }
            _notifyService.Error("Kullanıcı adı veya şifre hatalıdır");
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalıdır");
        }
        return View(dto);
    }

    public IActionResult Register()
    {
        return View(new AppUserRegisterDto());
    }

    [HttpPost]
    public async Task<IActionResult> Register(AppUserRegisterDto dto)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = new()
            {
                UserName = dto.Username,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
            };

            var result = await _userManager.CreateAsync(appUser, dto.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "Member");
                if (roleResult.Succeeded)
                    return RedirectToAction("Login");

                foreach (var item in roleResult.Errors)
                {
                    _notifyService.Error(item.Description);
                    ModelState.AddModelError("", item.Description);
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    _notifyService.Error(item.Description);
                    ModelState.AddModelError("", item.Description);
                }
            }
        }
        return View(dto);
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
