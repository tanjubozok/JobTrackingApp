using JobTracking.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracking.Repositories.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers");

        builder.Property(x => x.Name)
            .HasMaxLength(50);

        builder.Property(x => x.Surname)
            .HasMaxLength(50);

        builder.HasMany(x => x.Workings)
            .WithOne(x => x.AppUser)
            .HasForeignKey(x => x.AppUserId);
    }
}