using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.CategoryDtos;

public class CategoryListDto : IBaseDto
{
    public int Id { get; set; }
    public string? Definition { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
