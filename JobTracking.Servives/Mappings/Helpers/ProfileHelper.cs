using AutoMapper;
using JobTracking.Servives.Mappings.AutoMapper;

namespace JobTracking.Servives.Mappings.Helpers;

public static class ProfileHelper
{
    public static List<Profile> GetProfiles()
    {
        return new List<Profile>
        {
            new CategoryProfile(),
            new WorkingProfile()
        };
    }
}