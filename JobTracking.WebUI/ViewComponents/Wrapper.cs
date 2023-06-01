namespace JobTracking.WebUI.ViewComponents;

public class Wrapper : ViewComponent
{
    private readonly INotificationService _notificationService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public Wrapper(UserManager<AppUser> userManager, IMapper mapper, INotificationService notificationService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _notificationService = notificationService;
    }

    public IViewComponentResult Invoke()
    {
        var user = _userManager.FindByNameAsync(User.Identity!.Name).Result;
        var userDto = _mapper.Map<AppUserProfileDto>(user);

        int userNotificationCount = _notificationService.NotificationCount(user.Id);
        ViewBag.UserNotificationCount = userNotificationCount;

        var userRole = _userManager.GetRolesAsync(user).Result;
        if (userRole.Contains("Admin"))
            return View(userDto);
        return View("Member", userDto);
    }
}
