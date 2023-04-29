using JobTracking.Dtos.AppUserDtos;
using JobTracking.Dtos.WorkingDtos;

namespace JobTracking.WebUI.Areas.Admin.Models;

public class WorkingListViewModel
{
    public WorkingListDto? WorkList { get; set; }
    public List<AppUserListDto>? AppUser { get; set; }
}
