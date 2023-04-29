using JobTracking.Servives.Abstract;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace JobTracking.WebUI.TagHelpers;

[HtmlTargetElement("getWorkingByAppUserId")]
public class GetWorkingByAppUserIdTagHelper : TagHelper
{
    private readonly IWorkingService _workingService;

    public GetWorkingByAppUserIdTagHelper(IWorkingService workingService)
    {
        _workingService = workingService;
    }

    public int AppUserId { get; set; }
    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var workingList = await _workingService.GetAllByAppUserId(AppUserId);
        int completedWorks = workingList.Data.Where(x => x.Status).Count();
        int unfinishedWorks = workingList.Data.Where(x => !x.Status).Count();

        string htmlString = $"Tamamlanan Task Sayısı : <strong><span class='badge bg-success'>{completedWorks}</span></strong></br>" +
            $"Tamamlanmayan Task Sayısı : <strong><span class='badge bg-info'>{unfinishedWorks}</span></strong></br>";

        output.Content.SetHtmlContent(htmlString);
    }
}
