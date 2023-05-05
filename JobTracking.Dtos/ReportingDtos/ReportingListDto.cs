using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.ReportingDtos;

public class ReportingListDto : IBaseDto
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Detail { get; set; }
    public int WorkingId { get; set; }
}
