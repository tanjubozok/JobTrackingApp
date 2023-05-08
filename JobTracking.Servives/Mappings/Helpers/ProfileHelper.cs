using AutoMapper;
using JobTracking.Services.Mappings.AutoMapper;

namespace JobTracking.Services.Mappings.Helpers;

public static class ProfileHelper
{
    public static List<Profile> GetProfiles()
    {
        return new List<Profile>
        {
            new CategoryProfile(),
            new WorkingProfile(),
            new AppUserProfile(),
            new ReportingProfiles(),
            new NotificationProfile()
        };
    }
}