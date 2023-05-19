using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using JobTracking.Common.InfoMessages;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Entities.Models;
using JobTracking.WebUI.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area(AreaInfo.Member)]
[Authorize(Roles = RoleInfo.AdminMember)]
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
        TempData["MenuActive"] = TempDataInfo.Profile;

        var appUser = await _userManager.FindByNameAsync(User.Identity!.Name);
        var appUserDto = _mapper.Map<AppUserProfileDto>(appUser);
        return View(appUserDto);
    }

    [HttpPost]
    [ValidModel]
    public async Task<IActionResult> Index(AppUserProfileDto dto, IFormFile? uploadImage)
    {
        var updatedUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (uploadImage is not null)
        {
            // Save uploaded image to server
            string fileNameExtension = Path.GetExtension(uploadImage.FileName);
            string fileName = Guid.NewGuid().ToString() + fileNameExtension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "profiles", fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await uploadImage.CopyToAsync(stream);

            // Delete old profile image from server
            if (!string.IsNullOrEmpty(updatedUser.ProfileImage))
            {
                string oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "profiles", updatedUser.ProfileImage);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }

            // Update user's profile image
            updatedUser.ProfileImage = fileName;
        }

        // Update user's other information
        updatedUser.Name = dto.Name;
        updatedUser.Surname = dto.Surname;
        updatedUser.Email = dto.Email;

        // Save changes to database
        var result = await _userManager.UpdateAsync(updatedUser);
        if (result.Succeeded)
        {
            _notifyService.Success("Updated");
            return RedirectToAction("Index");
        }
        else
        {
            // Display error messages if update failed
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(dto);
    }
}