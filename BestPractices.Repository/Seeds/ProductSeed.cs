using BestPractices.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Repository.Seeds;

public class ProductSeed:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product() { Id = 1, CreatedDate = DateTime.Now, CategoryId = 1, Name = "Kalem 1", Price = 100, Stock = 200 },
            new Product() { Id = 2, CreatedDate = DateTime.Now, CategoryId = 1, Name = "Kalem 2", Price = 200, Stock = 30 },
            new Product() { Id = 3, CreatedDate = DateTime.Now, CategoryId = 2, Name = "Kitaplar 1", Price = 20, Stock = 40 },
            new Product() { Id = 4, CreatedDate = DateTime.Now, CategoryId = 3, Name = "Defterler 1", Price = 20, Stock = 40 }
        );
    }
}