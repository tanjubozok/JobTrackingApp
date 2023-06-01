using Newtonsoft.Json;

namespace JobTracking.WebUI.Areas.Member.Controllers;

[Area(AreaInfo.Member)]
[Authorize(Roles = RoleInfo.Member)]
public class GraphicController : Controller
{
    private readonly IWorkingService _workingService;

    public GraphicController(IWorkingService workingService)
    {
        _workingService = workingService;
    }

    public async Task<JsonResult> MostCompletedJob()
    {
        var result = await _workingService.MostCompletedStaffAsync();
        var jsonData = JsonConvert.SerializeObject(result.Data);
        return Json(jsonData);
    }

    public async Task<JsonResult> MostEmployedStaff()
    {
        var result = await _workingService.MostEmployedStaffAsync();
        var jsonData = JsonConvert.SerializeObject(result.Data);
        return Json(jsonData);
    }
}
