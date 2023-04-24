using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation.AspNetCore;
using JobTracking.Servives.DependencyResolvers;
using JobTracking.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews()
    .AddFluentValidation();

builder.Services.AddDependencies(builder.Configuration);
builder.Services.ToastrExtension();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.UseNotyf();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();