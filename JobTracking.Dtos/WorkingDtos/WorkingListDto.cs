using JobTracking.Dtos.Abstract;
using JobTracking.Entities.Models;

namespace JobTracking.Dtos.WorkingDtos;

public class WorkingListDto : IBaseDto
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? AppUserId { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}