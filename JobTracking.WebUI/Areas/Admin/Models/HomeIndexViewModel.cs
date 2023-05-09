namespace JobTracking.WebUI.Areas.Admin.Models;

public class HomeIndexViewModel
{
    public int NumberOfTaskPendingAssignment { get; set; }
    public int NumberOfCompletedTask { get; set; }
    public int NumberOfUnreadNotification { get; set; }
    public int TotalNumberOfWrittenReport { get; set; }
}
