using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.AppUserDtos;

public class AppUserListDto : IBaseDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? ProfileImage { get; set; }
}
