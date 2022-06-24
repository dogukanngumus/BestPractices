using BestPractices.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractices.Repository.Configurations;

public class ProductFeatureConfiguration:IEntityTypeConfiguration<ProductFeature>
{
    public void Configure(EntityTypeBuilder<ProductFeature> builder)
    {
        builder.HasKey(pf => pf.Id);
        builder.Property(pf => pf.Id).UseIdentityColumn();

        builder.HasOne(pf => pf.Product).WithOne(p => p.ProductFeature)
               .HasForeignKey<ProductFeature>(p=> p.ProductId);
    }
}