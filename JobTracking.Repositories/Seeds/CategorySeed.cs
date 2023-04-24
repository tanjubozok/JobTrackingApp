using JobTracking.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracking.Repositories.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                Id = 1,
                Definition = "Acil",
                Description = "Öncelik verilecek iş",
                CreatedDate = DateTime.Now,
                ModifiedDate = default,
                IsActive = true,
                IsDeleted = false,
            },
            new Category
            {
                Id = 2,
                Definition = "Bu hafta",
                Description = "Öncelik verilecek iş",
                CreatedDate = DateTime.Now,
                ModifiedDate = default,
                IsActive = true,
                IsDeleted = false,
            },
            new Category
            {
                Id = 3,
                Definition = "Bugün",
                Description = "Öncelik verilecek iş",
                CreatedDate = DateTime.Now,
                ModifiedDate = default,
                IsActive = true,
                IsDeleted = false,
            });
    }
}
