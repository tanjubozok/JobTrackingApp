﻿namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly INotyfService _notifyService;

    public CategoryController(ICategoryService categoryService, INotyfService notifyService)
    {
        _categoryService = categoryService;
        _notifyService = notifyService;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = "Categories";

        var list = await _categoryService.GetAllAsync();
        return View(list.Data);
    }

    public IActionResult Create()
    {
        TempData["MenuActive"] = "Categories";

        return View(new CategoryCreateDto());
    }

    [HttpPost]
    [ValidModel]
    public async Task<IActionResult> Create(CategoryCreateDto dto)
    {
        TempData["MenuActive"] = "Categories";

        var result = await _categoryService.CreateAsync(dto);
        if (result.ResponseType == ResponseType.Success)
        {
            _notifyService.Success($"{dto.Definition} eklendi.");
            return RedirectToAction("List");
        }
        _notifyService.Error(result.Message);

        return View(dto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        TempData["MenuActive"] = "Categories";

        var result = await _categoryService.GetByIdAsync(id);
        if (result.ResponseType == ResponseType.Success)
            return View(result.Data);
        _notifyService.Error(result.Message);
        return RedirectToAction("List");
    }

    [HttpPost]
    [ValidModel]
    public async Task<IActionResult> Edit(CategoryUpdateDto dto)
    {
        TempData["MenuActive"] = "Categories";

        var result = await _categoryService.UpdateAsync(dto);
        if (result.ResponseType == ResponseType.Success)
        {
            _notifyService.Success($"{dto.Definition} güncellendi.");
            return RedirectToAction("List");
        }
        _notifyService.Error(result.Message);

        return View(dto);
    }
}
