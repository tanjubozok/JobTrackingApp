using JobTracking.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace JobTracking.Entities.Models;

public class AppRole : IdentityRole<int>, IBaseEntity
{
}
