using AspNetCoreHero.ToastNotification.Abstractions;
using JobTracking.Common.ComplextTypes;
using JobTracking.Dtos.CategoryDtos;
using JobTracking.Servives.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    public INotyfService _notifyService { get; }

    public CategoryController(ICategoryService categoryService, INotyfService notyfService)
    {
        _categoryService = categoryService;
        _notifyService = notyfService;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = "Categories";

        var list = await _categoryService.GetAllAsync();
        return View(list.Data);
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
    public async Task<IActionResult> Edit(CategoryUpdateDto dto)
    {
        TempData["MenuActive"] = "Categories";

        if (ModelState.IsValid)
        {
            var result = await _categoryService.UpdateAsync(dto);
            if (result.ResponseType == ResponseType.Success)
            {
                _notifyService.Success($"{dto.Definition} güncellendi.");
                return RedirectToAction("List");
            }

            _notifyService.Error(result.Message);
        }
        return View(dto);
    }
}
