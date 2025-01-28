using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class RawMaterialEntityConfiguration : IEntityTypeConfiguration<RawMaterialEntity>
    {
        public void Configure(EntityTypeBuilder<RawMaterialEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.ProductRawMaterials)
                   .WithOne(pr => pr.RawMaterial)
                   .HasForeignKey(pr => pr.RawMaterialId);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
            builder.Property(r => r.Description).HasMaxLength(500);
            builder.Property(r => r.SupplierId).IsRequired().HasMaxLength(50);
            builder.Property(r => r.Amount).IsRequired();
            builder.Property(r => r.Expiration).IsRequired();
        }
    }
}
