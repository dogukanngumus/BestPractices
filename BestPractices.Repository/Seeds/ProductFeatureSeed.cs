using BestPractices.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Repository.Seeds;

public class ProductFeatureSeed:IEntityTypeConfiguration<ProductFeature>
{
    public void Configure(EntityTypeBuilder<ProductFeature> builder)
    {
        builder.HasData(
                new ProductFeature(){Id = 1, Color = "Kırmızı", Height = 100, Width = 200, ProductId = 1},
                new ProductFeature(){Id = 2, Color = "Mavi", Height = 50, Width = 200, ProductId = 1}
            );
    }
}