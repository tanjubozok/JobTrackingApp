namespace JobTracking.WebUI.Areas.Admin.Controllers;

[Area(AreaInfo.Admin)]
[Authorize(Roles = RoleInfo.Admin)]
public class WorkingController : Controller
{
    private readonly IWorkingService _workingService;
    private readonly ICategoryService _categoryService;
    private readonly IAppUserService _appUserService;
    private readonly UserManager<AppUser> _userManager;
    private readonly INotyfService _notifyService;
    private readonly INotificationService _notificationService;

    public WorkingController(IWorkingService workingService, INotyfService notifyService, ICategoryService categoryService, IAppUserService appUserService, UserManager<AppUser> userManager, INotificationService notificationService)
    {
        _workingService = workingService;
        _notifyService = notifyService;
        _categoryService = categoryService;
        _appUserService = appUserService;
        _userManager = userManager;
        _notificationService = notificationService;
    }

    public async Task<IActionResult> List()
    {
        TempData["MenuActive"] = TempDataInfo.Working;

        var list = await _workingService.GetAllWithCategoryAsync();
        return View(list.Data);
    }

    public async Task<IActionResult> GetAllTable()
    {
        TempData["MenuActive"] = TempDataInfo.WorkOrder;

        var list = await _workingService.GetAllTableAsync();
        return View(list.Data);
    }

    [HttpGet]
    public async Task<IActionResult> SetPersonnel2(int id, string s, int activePage = 1, int pageCount = 10)
    {
        TempData["MenuActive"] = TempDataInfo.WorkOrder;

        var appUsers = _appUserService.NonAdminUsers(out int totalPage, s, activePage, pageCount);
        var work = await _workingService.GetAllByIdWithCategoryAsync(id);

        ViewBag.Search = s;
        ViewBag.TotalPage = totalPage;
        ViewBag.ActivePage = activePage;

        WorkingListViewModel model = new()
        {
            AppUser = appUsers.Data,
            WorkList = work.Data
        };
        return View(model);
    }

    public async Task<IActionResult> AssignTask(int appUserId, int workId)
    {
        TempData["MenuActive"] = TempDataInfo.WorkOrder;

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == appUserId);
        var work = await _workingService.GetByIdAsync(workId);

        if (user is null || work is null)
        {
            _notifyService.Error("Eşleşen task bulunamadı.");
            return RedirectToAction("SetPersonnel2", "Working", new { area = "Admin" });
        }

        PersonWorkingViewModel model = new()
        {
            AppUser = user,
            Work = work.Data
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AssignTask(PersonWorkingViewModel model)
    {
        if (!model.CheckTask)
        {
            _notifyService.Error("Onay kutucuğunu işaretleyiniz.");
            return View(model);
        }

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == model.AppUser!.Id);
        var work = await _workingService.GetByIdAsync(model.Work!.Id);
        work.Data!.AppUserId = user!.Id;

        if (user is null || work is null)
        {
            _notifyService.Error("Eşleşen task bulunamadı.");
            return View(model);
        }

        var result = await _workingService.UpdateAsync(work.Data!);
        if (result.ResponseType == ResponseType.Success)
        {
            var notify = $"{user.UserName} {work.Data!.Definition} gorevi atandı.";
            _notifyService.Success(notify);
            _ = await _notificationService.CreateAsync(user.Id, notify);

            return RedirectToAction("GetAllTable");
        }
        _notifyService.Error(result.Message);

        return View();
    }

    public async Task<IActionResult> Create()
    {
        TempData["MenuActive"] = TempDataInfo.Working;

        var categories = await _categoryService.GetAllAsync();
        ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition");

        return View(new WorkingCreateDto());
    }

    [HttpPost]
    [ValidModel]
    public async Task<IActionResult> Create(WorkingCreateDto dto)
    {
        TempData["MenuActive"] = TempDataInfo.Working;

        var result = await _workingService.CreateAsync(dto);
        if (result.ResponseType == ResponseType.Success)
        {
            _notifyService.Success($"{dto.Definition} eklendi.");
            return RedirectToAction("List");
        }
        _notifyService.Error(result.Message);

        var categories = await _categoryService.GetAllAsync();
        ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition", dto.CategoryId);

        return View(dto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        TempData["MenuActive"] = TempDataInfo.Working;

        var result = await _workingService.GetByIdAsync(id);
        if (result.ResponseType == ResponseType.Success)
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition", result.Data?.CategoryId);

            return View(result.Data);
        }
        _notifyService.Error(result.Message);
        return RedirectToAction("List");
    }

    [HttpPost]
    [ValidModel]
    public async Task<IActionResult> Edit(WorkingUpdateDto dto)
    {
        TempData["MenuActive"] = TempDataInfo.Working;

        var result = await _workingService.UpdateAsync(dto);
        if (result.ResponseType == ResponseType.Success)
        {
            _notifyService.Success($"{dto.Definition} güncellendi.");
            return RedirectToAction("List");
        }
        _notifyService.Error(result.Message);

        var categories = await _categoryService.GetAllAsync();
        ViewBag.Categories = new SelectList(categories.Data, "Id", "Definition", dto.CategoryId);

        return View(dto);
    }

    public IActionResult Delete(int id)
    {
        return Json(null);
    }
}