using JobTracking.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracking.Repositories.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Definition)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasColumnType("text");

        builder.HasMany(x => x.Workings)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}