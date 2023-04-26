using AspNetCoreHero.ToastNotification.Abstractions;
using JobTracking.Common.ComplextTypes;
using JobTracking.Dtos.WorkingDtos;
using JobTracking.Servives.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class WorkingController : Controller
{
    private readonly IWorkingService _workingService;
    private readonly ICategoryService _categoryService;
    private readonly INotyfService _notifyService;

    public WorkingController(IWorkingService workingService, INotyfService notifyService, ICategoryService categoryService)
    {
        _workingService = workingService;
        _notifyService = notifyService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = "Working";

        var list = await _workingService.GetAllWithCategoryAsync();
        return View(list.Data);
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
            ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition", result.Data.CategoryId);

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