using AutoMapper;
using FluentValidation;
using JobTracking.Dtos.AppUserDtos;
using JobTracking.Dtos.CategoryDtos;
using JobTracking.Dtos.ReportingDtos;
using JobTracking.Dtos.WorkingDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using JobTracking.Repositories.Repository;
using JobTracking.Repositories.UnitOfWorks;
using JobTracking.Services.Abstract;
using JobTracking.Services.Manager;
using JobTracking.Services.Mappings.Helpers;
using JobTracking.Services.ValidationRules.AppUserValidators;
using JobTracking.Services.ValidationRules.CategoryValidators;
using JobTracking.Services.ValidationRules.ReportingValidators;
using JobTracking.Services.ValidationRules.WorkingValidators;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobTracking.Services.DependencyResolvers;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Database connection string

        services.AddDbContext<DatabaseContext>(opt =>
        {
            //opt.UseNpgsql(configuration.GetConnectionString("LocalPostgreSql"));
            opt.UseSqlServer(configuration.GetConnectionString("LocalSqlServer"));
        });

        #endregion

        #region Identity Configurations

        services.AddIdentity<AppUser, AppRole>(opt =>
        {
            // Password settings
            opt.Password.RequireDigit = true;
            opt.Password.RequiredLength = 4;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequiredUniqueChars = 0;
        })
           .AddEntityFrameworkStores<DatabaseContext>();

        services.ConfigureApplicationCookie(opt =>
        {
            opt.Cookie.Name = "JobTrackingApp";
            opt.Cookie.SameSite = SameSiteMode.Strict;
            opt.Cookie.HttpOnly = true;
            opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

            opt.ExpireTimeSpan = TimeSpan.FromDays(20);

            opt.LoginPath = "/Member/Account/Login";
            opt.LogoutPath = "/Member/Account/Logout";
            opt.AccessDeniedPath = "/Member/Account/AccessDenied";
        });

        #endregion

        #region Validation

        services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
        services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();

        services.AddTransient<IValidator<WorkingCreateDto>, WorkingCreateDtoValidator>();
        services.AddTransient<IValidator<WorkingUpdateDto>, WorkingUpdateDtoValidator>();

        services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
        services.AddTransient<IValidator<AppUserRegisterDto>, AppUserRegisterDtoValidator>();
        services.AddTransient<IValidator<AppUserProfileDto>, AppUserProfileDtoValidator>();

        services.AddTransient<IValidator<ReportingCreateDto>, ReportingCreateDtoValidator>();

        #endregion

        #region Di

        // repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IWorkingRepository, WorkingRepository>();
        services.AddScoped<IReportingRepository, ReportingRepository>();
        services.AddScoped<IAppUserRepository, AppUserRepository>();


        // services
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IWorkingService, WorkingManager>();
        services.AddScoped<IReportingService, ReportingManager>();
        services.AddScoped<IAppUserService, AppUserManager>();
        services.AddScoped<IAppUserService, AppUserManager>();
        services.AddScoped<IFileService, FileManager>();


        #endregion

        #region Mapper

        var profiles = ProfileHelper.GetProfiles();
        var conf = new MapperConfiguration(opt =>
        {
            opt.AddProfiles(profiles);
        });
        var mapper = conf.CreateMapper();
        services.AddSingleton(mapper);

        #endregion
    }
}
