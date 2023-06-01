using JobTracking.WebUI.Areas.Member.Models;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area(AreaInfo.Member)]
[Authorize(Roles = RoleInfo.Member)]
public class HomeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly INotificationService _notificationService;
    private readonly IWorkingService _workingService;

    public HomeController(UserManager<AppUser> userManager, INotificationService notificationService, IWorkingService workingService)
    {
        _userManager = userManager;
        _notificationService = notificationService;
        _workingService = workingService;
    }

    public async Task<IActionResult> Index()
    {
        TempData["MenuActive"] = TempDataInfo.Dashboard;

        var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);
        HomeIndexModel model = new()
        {
            GetNumberOfUnreadNotificationAsync = await _notificationService.GetNumberOfUnreadNotificationAsync(currentUser.Id),
            GetNumberOfReportsWrittenAsync = await _workingService.GetNumberOfReportsWrittenAsync(currentUser.Id),
            GetNumberOfTasksCompletedAsync = await _workingService.GetNumberOfTasksCompletedAsync(currentUser.Id),
            GetNumberOfTaskToCompleteAsync = await _workingService.GetNumberOfTaskToCompleteAsync(currentUser.Id)
        };
        return View(model);
    }
}
