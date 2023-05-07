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
                Description = "La en de ja kaj ni eraris haveno kun la diris tiel estus mi havu kaj hejmon lasi kun kuragxis",
                Color = "danger",
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted = false,
            },
            new Category
            {
                Id = 2,
                Definition = "Bu hafta",
                Description = "Terbordo la mi la de tiuj kiu al sxipon al lingvo havis aux ne mi de povinta hejmon tukoj la",
                Color = "success",
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted = false,
            },
            new Category
            {
                Id = 3,
                Definition = "Bugün",
                Description = "La trinki farigis maron sed estas mi tion turko kompreni direktilon kaj la sian tro ni se cxefo por kiu",
                Color = "info",
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted = false,
            });
    }
}
