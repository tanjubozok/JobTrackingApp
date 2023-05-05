using AspNetCoreHero.ToastNotification.Abstractions;
using JobTracking.Common.ComplextTypes;
using JobTracking.Dtos.ReportingDtos;
using JobTracking.Entities.Models;
using JobTracking.Servives.Abstract;
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

    public WorkingController(IWorkingService workingService, UserManager<AppUser> userManager, IReportingService reportingService, INotyfService notifyService)
    {
        _workingService = workingService;
        _userManager = userManager;
        _reportingService = reportingService;
        _notifyService = notifyService;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = "Working";

        var activeUser = await _userManager.FindByNameAsync(User.Identity!.Name);
        var appUserWorkingList = await _workingService.GetAllTableAsync(activeUser.Id);
        return View(appUserWorkingList.Data);
    }

    public async Task<IActionResult> ReportList(int id)
    {
        TempData["MenuActive"] = "Working";

        var list = await _reportingService.GetAllByWorkingIdAsync(id);

        ViewBag.WorkingId = id;
        return View(list.Data);
    }

    public async Task<IActionResult> ReportWrite(int id)
    {
        TempData["MenuActive"] = "Working";

        var working = await _workingService.GetAllByIdWithCategoryAsync(id);

        var categoriName = working.Data.Category!.Definition;
        var categoriColor = working.Data.Category.Color;
        var workingName = working.Data.Definition;

        ReportingCreateDto dto = new()
        {
            WorkingId = id,
            CategoryName = categoriName,
            Color = categoriColor,
            WorkingName = workingName
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
                _notifyService.Success($"{dto.Definition} eklendi.");
                return RedirectToAction("List");
            }
            _notifyService.Error(result.Message);
        }
        return View(dto);
    }
}

