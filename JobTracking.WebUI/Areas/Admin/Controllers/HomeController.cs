using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        TempData["MenuActive"] = "Dashboard";

        return View();
    }
}
