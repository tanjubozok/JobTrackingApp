namespace JobTracking.WebUI.Areas.Member.Models;

public class HomeIndexModel
{
    public int GetNumberOfReportsWrittenAsync { get; set; }
    public int GetNumberOfTasksCompletedAsync { get; set; }
    public int GetNumberOfTaskToCompleteAsync { get; set; }
    public int GetNumberOfUnreadNotificationAsync { get; set; }
}
