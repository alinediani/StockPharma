using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.OrderProducts)
                   .WithOne(op => op.Product)
                   .HasForeignKey(op => op.ProductId);

            builder.HasMany(p => p.ProductRawMaterials)
                   .WithOne(pr => pr.Product)
                   .HasForeignKey(pr => pr.ProductId);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
        }
    }
}
