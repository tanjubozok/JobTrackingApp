using JobTracking.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Member")]
public class FileController : Controller
{
    private readonly IFileService _fileService;
    private readonly ICategoryService _categoryService;

    public FileController(ICategoryService categoryService, IFileService fileService)
    {
        _categoryService = categoryService;
        _fileService = fileService;
    }

    public async Task<IActionResult> ExportExcel()
    {
        var list = await _categoryService.GetAllAsync();
        byte[] fileContent = await _fileService.ExportExcel(list.Data!);

        string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        string fileName = Guid.NewGuid() + ".xlsx";

        return File(fileContent, contentType, fileName);
    }
}
