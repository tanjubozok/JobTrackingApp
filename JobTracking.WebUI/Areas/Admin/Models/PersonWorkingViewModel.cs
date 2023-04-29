using JobTracking.Dtos.WorkingDtos;
using JobTracking.Entities.Models;

namespace JobTracking.WebUI.Areas.Admin.Models;

public class PersonWorkingViewModel
{
    public WorkingUpdateDto? Work { get; set; }
    public AppUser? AppUser { get; set; }
    public bool CheckTask { get; set; }
}
