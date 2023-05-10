using AspNetCoreHero.ToastNotification.Abstractions;
using JobTracking.Common.ComplexTypes;
using JobTracking.Entities.Models;
using JobTracking.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;
    private readonly UserManager<AppUser> _userManager;
    private readonly INotyfService _notifyService;

    public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, INotyfService notifyService)
    {
        _notificationService = notificationService;
        _userManager = userManager;
        _notifyService = notifyService;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = "Notification";

        var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
        var result = await _notificationService.GetAllAsync(currentUser.Id);
        if (result.ResponseType == ResponseType.Success)
            return View(result.Data);
        return View(result.Message);
    }

    public async Task<IActionResult> DoneNotification(int id)
    {
        var result = await _notificationService.DoneNotificationAsync(id);
        if (result.ResponseType == ResponseType.Success)
        {
            _notifyService.Success("Okundu");
            return RedirectToAction("List");
        }
        _notifyService.Error("Hata oluştu.");
        return View();
    }
}
