using JobTracking.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace JobTracking.Entities.Models;

public class AppUser : IdentityUser<int>, IBaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? ProfileImage { get; set; }

    public List<Working>? Workings { get; set; }
}
