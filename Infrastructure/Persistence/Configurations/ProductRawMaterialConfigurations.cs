using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductRawMaterialConfiguration : IEntityTypeConfiguration<ProductRawMaterialEntity>
    {
        public void Configure(EntityTypeBuilder<ProductRawMaterialEntity> builder)
        {
            builder.HasKey(pr => new { pr.ProductId, pr.RawMaterialId });

        }
    }
}
