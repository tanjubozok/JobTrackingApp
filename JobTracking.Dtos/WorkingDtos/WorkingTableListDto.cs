using JobTracking.Dtos.Abstract;
using JobTracking.Entities.Models;

namespace JobTracking.Dtos.WorkingDtos;

public class WorkingTableListDto : IBaseDto
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public AppUser? AppUser { get; set; }
    public Category? Category { get; set; }
    public List<Reporting>? Reportings { get; set; }
}