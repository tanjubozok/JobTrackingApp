namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area(AreaInfo.Admin)]
[Authorize(Roles = RoleInfo.Admin)]
public class HomeController : Controller
{
    private readonly IWorkingService _workingService;
    private readonly INotificationService _notificationService;
    private readonly IReportingService _reportingService;
    private readonly UserManager<AppUser> _userManager;

    public HomeController(IWorkingService workingService, INotificationService notificationService, IReportingService reportingService, UserManager<AppUser> userManager)
    {
        _workingService = workingService;
        _notificationService = notificationService;
        _reportingService = reportingService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        TempData["MenuActive"] = TempDataInfo.Dashboard;

        var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name);

        HomeIndexViewModel model = new()
        {
            NumberOfTaskPendingAssignment = await _workingService.GetNumberOfTaskPendingAssignmentAsync(),
            NumberOfCompletedTask = await _workingService.GetNumberOfCompletedTaskAsync(),
            NumberOfUnreadNotification = await _notificationService.GetNumberOfUnreadNotificationAsync(currentUser.Id),
            TotalNumberOfWrittenReport = await _reportingService.GetTotalNumberOfWrittenReportAsync(),
        };

        return View(model);
    }
}
