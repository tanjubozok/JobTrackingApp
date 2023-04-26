using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.AppUserDtos;

public class AppUserLoginDto : IBaseDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool RememberMe { get; set; }
}
