﻿using JobTracking.Entities.Models;
using JobTracking.Services.Abstract;
using JobTracking.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Authorize(Roles = "Member")]
public class HomeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly INotificationService _notificationService;
    private readonly IWorkingService _workingService;

    public HomeController(UserManager<AppUser> userManager, INotificationService notificationService, IWorkingService workingService)
    {
        _userManager = userManager;
        _notificationService = notificationService;
        _workingService = workingService;
    }

    public async Task<IActionResult> Index()
    {
        TempData["MenuActive"] = "Dashboard";

        var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
        HomeIndexModel model = new()
        {
            GetNumberOfUnreadNotificationAsync = await _notificationService.GetNumberOfUnreadNotificationAsync(currentUser.Id),
            GetNumberOfReportsWrittenAsync = await _workingService.GetNumberOfReportsWrittenAsync(currentUser.Id),
            GetNumberOfTasksCompletedAsync = await _workingService.GetNumberOfTasksCompletedAsync(currentUser.Id),
            GetNumberOfTaskToCompleteAsync = await _workingService.GetNumberOfTaskToCompleteAsync(currentUser.Id)
        };
        return View(model);
    }
}
