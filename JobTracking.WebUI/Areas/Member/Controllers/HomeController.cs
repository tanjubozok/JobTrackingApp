using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area("Member")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
