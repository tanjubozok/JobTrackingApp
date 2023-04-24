using AspNetCoreHero.ToastNotification;

namespace JobTracking.WebUI.Extensions;

public static class ServicesExtensions
{
    public static void ToastrExtension(this IServiceCollection services)
    {
        services.AddNotyf(opt =>
        {
            opt.DurationInSeconds = 10;
            opt.IsDismissable = true;
            opt.Position = NotyfPosition.BottomRight;
        });
    }
}
