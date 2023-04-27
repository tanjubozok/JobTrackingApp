using JobTracking.Entities.Models;
using JobTracking.Repositories.Configurations;
using JobTracking.Repositories.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Repositories.Context;

public class DatabaseContext : IdentityDbContext<AppUser, AppRole, int>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Configurations

        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new WorkingConfiguration());
        builder.ApplyConfiguration(new ReportingConfiguration());
        builder.ApplyConfiguration(new AppUserConfiguration());

        #endregion

        #region Seeds

        builder.ApplyConfiguration(new CategorySeed());
        builder.ApplyConfiguration(new WorkingSeed());

        #endregion

        base.OnModelCreating(builder);
    }

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Working>? Workings { get; set; }
    public DbSet<Reporting>? Reportings { get; set; }
}
