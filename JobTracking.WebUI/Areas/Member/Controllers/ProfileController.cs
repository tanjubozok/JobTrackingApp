using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Authorize(Roles = "Admin,Member")]
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
