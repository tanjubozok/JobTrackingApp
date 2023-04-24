using JobTracking.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracking.Repositories.Configurations;

public class WorkingConfiguration : IEntityTypeConfiguration<Working>
{
    public void Configure(EntityTypeBuilder<Working> builder)
    {
        builder.ToTable("Workings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Definition)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Description)
            .HasColumnType("ntext");

        builder.HasMany(x => x.Reportings)
            .WithOne(x => x.Working)
            .HasForeignKey(x => x.WorkingId);
    }
}