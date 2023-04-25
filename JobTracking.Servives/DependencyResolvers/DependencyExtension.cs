using AutoMapper;
using FluentValidation;
using JobTracking.Dtos.CategoryDtos;
using JobTracking.Dtos.WorkingDtos;
using JobTracking.Entities.Models;
using JobTracking.Repositories.Abstract;
using JobTracking.Repositories.Context;
using JobTracking.Repositories.Repository;
using JobTracking.Repositories.UnitOfWorks;
using JobTracking.Servives.Abstract;
using JobTracking.Servives.Manager;
using JobTracking.Servives.Mappings.Helpers;
using JobTracking.Servives.ValidationRules.CategoryValidators;
using JobTracking.Servives.ValidationRules.WorkingValidators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobTracking.Servives.DependencyResolvers;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Database connection string

        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("LocalPostgreSql"));
        });

        #endregion    

        #region Identity configuration

        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<DatabaseContext>();

        #endregion

        #region Validation

        services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
        services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();

        services.AddTransient<IValidator<WorkingCreateDto>, WorkingCreateDtoValidator>();
        services.AddTransient<IValidator<WorkingUpdateDto>, WorkingUpdateDtoValidator>();

        #endregion

        #region Di

        // repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IWorkingRepository, WorkingRepository>();
        services.AddScoped<IReportingRepository, ReportingRepository>();


        // services
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IWorkingService, WorkingManager>();


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
