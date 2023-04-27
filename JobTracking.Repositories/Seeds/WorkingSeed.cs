using JobTracking.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracking.Repositories.Seeds;

public class WorkingSeed : IEntityTypeConfiguration<Working>
{
    public void Configure(EntityTypeBuilder<Working> builder)
    {
        builder.HasData(new Working[]
        {
            new()
            {
                Id = 1,
                Definition="Footer düzenleme",
                Description="localhost.com sitesindeki footerdaki telefon numarası değiştirilmesi gerekiyor",
                CategoryId=1,
                CreatedDate= DateTime.Now,
                Status=false
            },
            new()
            {
                Id = 2,
                Definition="Logo düzenleme",
                Description="localhost.com sitesindeki logo değiştirilmesi gerekiyor",
                CategoryId=3,
                CreatedDate= DateTime.Now,
                Status=false
            },
            new()
            {
                Id = 3,
                Definition="Hakkımızda düzenleme",
                Description="localhost.com sitesindeki hakkımızda değiştirilmesi gerekiyor",
                CategoryId=2,
                CreatedDate= DateTime.Now,
                Status=false
            },
            new()
            {
                Id = 4,
                Definition="Adres düzenleme",
                Description="localhost.com sitesindeki adres değiştirilmesi gerekiyor",
                CategoryId=3,
                CreatedDate= DateTime.Now,
                Status=false
            },
        });
    }
}
