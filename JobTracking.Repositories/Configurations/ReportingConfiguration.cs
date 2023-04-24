using JobTracking.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracking.Repositories.Configurations;

public class ReportingConfiguration : IEntityTypeConfiguration<Reporting>
{
    public void Configure(EntityTypeBuilder<Reporting> builder)
    {
        builder.ToTable("Reports");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Definition)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Detail)
            .HasColumnType("ntext");
    }
}