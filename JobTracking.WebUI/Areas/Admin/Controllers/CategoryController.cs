using JobTracking.Servives.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = "Categories";

        var list = await _categoryService.GetAllAsync();
        return View(list.Data);
    }
}
