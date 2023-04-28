using JobTracking.Dtos.AppUserDtos;
using JobTracking.Dtos.WorkingDtos;

namespace JobTracking.WebUI.Areas.Admin.Models;

public class WorkingListViewModel
{
    public WorkingListDto? WorkingListDto { get; set; }
    public List<AppUserListDto>? AppUserListDto { get; set; }
}
