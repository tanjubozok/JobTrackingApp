using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.ReportingDtos;

public class ReportingCreateDto : IBaseDto
{
    public string? Definition { get; set; }
    public string? Detail { get; set; }
    public int WorkingId { get; set; }
    public string? WorkingName { get; set; }
    public string? CategoryName { get; set; }
    public string? Color { get; set; }
}
