using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Authorize(Roles = "Member")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        TempData["MenuActive"] = "Dashboard";

        return View();
    }
}
