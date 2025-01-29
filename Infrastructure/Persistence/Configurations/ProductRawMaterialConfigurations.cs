using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductRawMaterialConfiguration : IEntityTypeConfiguration<ProductRawMaterialEntity>
    {
        public void Configure(EntityTypeBuilder<ProductRawMaterialEntity> builder)
        {
            builder.HasKey(pr => pr.ProductRawMaterialId);

            builder.Property(pr => pr.ProductRawMaterialId)
                .ValueGeneratedOnAdd(); 

            builder.HasIndex(pr => new { pr.ProductId, pr.RawMaterialId }).IsUnique();

            builder.HasOne(pr => pr.Product)
                   .WithMany(p => p.ProductRawMaterials)
                   .HasForeignKey(pr => pr.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pr => pr.RawMaterial)
                   .WithMany(rm => rm.ProductRawMaterials)
                   .HasForeignKey(pr => pr.RawMaterialId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
