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
    public INotyfService _notifyService { get; }

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
}