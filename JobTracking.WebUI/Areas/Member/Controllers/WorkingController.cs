using AspNetCoreHero.ToastNotification.Abstractions;
using JobTracking.Common.ComplexTypes;
using JobTracking.Dtos.ReportingDtos;
using JobTracking.Entities.Models;
using JobTracking.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Authorize(Roles = "Member")]
public class WorkingController : Controller
{
    private readonly IWorkingService _workingService;
    private readonly IReportingService _reportingService;
    private readonly UserManager<AppUser> _userManager;
    private readonly INotyfService _notifyService;
    private readonly INotificationService _notificationService;

    public WorkingController(IWorkingService workingService, UserManager<AppUser> userManager, IReportingService reportingService, INotyfService notifyService, INotificationService notificationService)
    {
        _workingService = workingService;
        _userManager = userManager;
        _reportingService = reportingService;
        _notifyService = notifyService;
        _notificationService = notificationService;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = "Working";

        var activeUser = await _userManager.FindByNameAsync(User.Identity!.Name);
        var appUserWorkingList = await _workingService.GetAllTableAsync(activeUser.Id);
        return View(appUserWorkingList.Data);
    }

    public async Task<IActionResult> CompleteList()
    {
        TempData["MenuActive"] = "CompleteWorking";

        var activeUser = await _userManager.FindByNameAsync(User.Identity!.Name);
        var appUserWorkingList = await _workingService.GetAllTableCompleteAsync(activeUser.Id);
        return View(appUserWorkingList.Data);
    }

    public async Task<IActionResult> ReportList(int id)
    {
        TempData["MenuActive"] = "Working";

        var list = await _reportingService.GetAllByWorkingIdAsync(id);
        var working = await _workingService.GetByIdAsync(id);

        ViewBag.WorkingName = working.Data!.Definition;
        ViewBag.WorkingId = id;

        return View(list.Data);
    }

    public async Task<IActionResult> ReportWrite(int id)
    {
        TempData["MenuActive"] = "Working";

        var working = await _workingService.GetAllByIdWithCategoryAsync(id);
        ReportingCreateDto dto = new()
        {
            WorkingId = id,
            CategoryName = working.Data!.Category!.Definition,
            Color = working.Data.Category.Color,
            WorkingName = working.Data.Definition
        };
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> ReportWrite(ReportingCreateDto dto)
    {
        if (ModelState.IsValid)
        {
            var result = await _reportingService.CreateReport(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
                foreach (var item in adminUserList)
                {
                    var notify = $"{currentUser.UserName} {result.Data!.Definition} raporu yazdı.";
                    _ = await _notificationService.CreateAsync(item.Id, notify);
                }

                _notifyService.Success($"{dto.Definition} eklendi.");
                return RedirectToAction("List");
            }
            _notifyService.Error(result.Message);
        }
        return View(dto);
    }

    public async Task<IActionResult> ReportEdit(int id)
    {
        var result = await _reportingService.GetById(id);
        if (result.ResponseType == ResponseType.Success)
            return View(result.Data);
        _notifyService.Error(result.Message);
        return RedirectToAction("List");
    }

    [HttpPost]
    public async Task<IActionResult> ReportEdit(ReportingEditDto dto)
    {
        if (ModelState.IsValid)
        {
            var result = await _reportingService.EditReport(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                _notifyService.Success("Updated");
                return RedirectToAction("List");
            }
            _notifyService.Error(result.Message);
        }
        return View(dto);
    }

    public async Task<IActionResult> DoneTask(int id)
    {
        var result = await _workingService.DoneWorking(id);
        if (result.ResponseType == ResponseType.Success)
        {
            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
            foreach (var item in adminUserList)
            {
                var notify = $"{currentUser.UserName} görevi tamamladı.";
                _ = await _notificationService.CreateAsync(item.Id, notify);
            }
        };
        return Json("null");
    }
}

