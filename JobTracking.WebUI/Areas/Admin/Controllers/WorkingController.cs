using AspNetCoreHero.ToastNotification.Abstractions;
using JobTracking.Common.ComplextTypes;
using JobTracking.Dtos.WorkingDtos;
using JobTracking.Entities.Models;
using JobTracking.Servives.Abstract;
using JobTracking.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class WorkingController : Controller
{
    private readonly IWorkingService _workingService;
    private readonly ICategoryService _categoryService;
    private readonly IAppUserService _appUserService;
    private readonly UserManager<AppUser> _userManager;
    private readonly INotyfService _notifyService;

    public WorkingController(IWorkingService workingService, INotyfService notifyService, ICategoryService categoryService, IAppUserService appUserService, UserManager<AppUser> userManager)
    {
        _workingService = workingService;
        _notifyService = notifyService;
        _categoryService = categoryService;
        _appUserService = appUserService;
        _userManager = userManager;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = "Working";

        var list = await _workingService.GetAllWithCategoryAsync();
        return View(list.Data);
    }

    public async Task<IActionResult> GetAllTable()
    {
        TempData["MenuActive"] = "WorkOrder";

        var list = await _workingService.GetAllTableAsync();
        return View(list.Data);
    }

    [HttpGet]
    public async Task<IActionResult> SetPersonel2(int id, string s, int activePage = 1, int pageCount = 10)
    {
        TempData["MenuActive"] = "WorkOrder";

        var appUsers = _appUserService.NonAdminUsers(out int totalPage, s, activePage, pageCount);
        var work = await _workingService.GetAllByIdWithCategoryAsync(id);

        ViewBag.Search = s;
        ViewBag.TotalPage = totalPage;
        ViewBag.ActivePage = activePage;

        WorkingListViewModel model = new()
        {
            AppUser = appUsers.Data,
            WorkList = work.Data
        };
        return View(model);
    }

    public async Task<IActionResult> AssignTask(int appUserId, int workId)
    {
        TempData["MenuActive"] = "WorkOrder";

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == appUserId);
        var work = await _workingService.GetByIdAsync(workId);

        if (user is null || work is null)
        {
            _notifyService.Error("Eşleşen task bulunamadı.");
            return RedirectToAction("SetPersonel2", "Working", new { area = "Admin" });
        }

        PersonWorkingViewModel model = new()
        {
            AppUser = user,
            Work = work.Data
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AssignTask(PersonWorkingViewModel model)
    {
        if (!model.CheckTask)
        {
            _notifyService.Error("Onay kutucuğunu işaretleyiniz.");
            return View(model);
        }

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == model.AppUser!.Id);
        var work = await _workingService.GetByIdAsync(model.Work!.Id);
        work.Data!.AppUserId = user!.Id;

        if (user is null || work is null)
        {
            _notifyService.Error("Eşleşen task bulunamadı.");
            return View(model);
        }

        var result = await _workingService.UpdateAsync(work.Data!);
        if (result.ResponseType == ResponseType.Success)
        {
            _notifyService.Success($"{user.UserName} {work.Data!.Definition} görevi atandı.");
            return RedirectToAction("GetAllTable");
        }
        _notifyService.Error(result.Message);

        return View();
    }

    public async Task<IActionResult> Create()
    {
        TempData["MenuActive"] = "Working";

        var categories = await _categoryService.GetAllAsync();
        ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition");

        return View(new WorkingCreateDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkingCreateDto dto)
    {
        TempData["MenuActive"] = "Working";

        if (ModelState.IsValid)
        {
            var result = await _workingService.CreateAsync(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                _notifyService.Success($"{dto.Definition} eklendi.");
                return RedirectToAction("List");
            }
            _notifyService.Error(result.Message);
        }

        var categories = await _categoryService.GetAllAsync();
        ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition", dto.CategoryId);

        return View(dto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        TempData["MenuActive"] = "Working";

        var result = await _workingService.GetByIdAsync(id);
        if (result.ResponseType == ResponseType.Success)
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition", result.Data?.CategoryId);

            return View(result.Data);
        }
        _notifyService.Error(result.Message);
        return RedirectToAction("List");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(WorkingUpdateDto dto)
    {
        TempData["MenuActive"] = "Working";

        if (ModelState.IsValid)
        {
            var result = await _workingService.UpdateAsync(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                _notifyService.Success($"{dto.Definition} güncellendi.");
                return RedirectToAction("List");
            }
            _notifyService.Error(result.Message);
        }
        var categories = await _categoryService.GetAllAsync();
        ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition", dto.CategoryId);

        return View(dto);
    }

    public IActionResult Delete(int id)
    {
        return Json(null);
    }
}