using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductRawMaterialConfiguration : IEntityTypeConfiguration<ProductRawMaterialEntity>
    {
        public void Configure(EntityTypeBuilder<ProductRawMaterialEntity> builder)
        {
            builder.HasKey(pr => pr.Id);

            builder.Property(pr => pr.Id)
                   .ValueGeneratedOnAdd(); 

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
