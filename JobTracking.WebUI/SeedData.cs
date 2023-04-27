using JobTracking.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace JobTracking.WebUI;

public class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        await CreateRolesAsync(roleManager);
        await CreateUsersAsync(userManager);
    }

    private static async Task CreateRolesAsync(RoleManager<AppRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            AppRole adminRole = new()
            {
                Name = "Admin"
            };
            await roleManager.CreateAsync(adminRole);
        }

        if (!await roleManager.RoleExistsAsync("Member"))
        {
            AppRole memberRole = new()
            {
                Name = "Member"
            };
            await roleManager.CreateAsync(memberRole);
        }
    }

    private static async Task CreateUsersAsync(UserManager<AppUser> userManager)
    {
        AppUser adminUser = new()
        {
            UserName = "admin",
            Email = "admin@example.com",
            EmailConfirmed = true,
            Name = "Admin",
            Surname = "User"
        };

        if (await userManager.FindByEmailAsync(adminUser.Email) is null)
        {
            var result = await userManager.CreateAsync(adminUser, "123456");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        AppUser memberUser = new()
        {
            UserName = "member",
            Email = "member@example.com",
            EmailConfirmed = true,
            Name = "Member",
            Surname = "User"
        };

        if (await userManager.FindByEmailAsync(memberUser.Email) is null)
        {
            var result = await userManager.CreateAsync(memberUser, "123456");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(memberUser, "Member");
        }
    }
}