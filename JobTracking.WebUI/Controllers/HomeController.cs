using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
