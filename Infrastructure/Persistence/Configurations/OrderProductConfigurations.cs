using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProductEntity>
    {
        public void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.HasKey(op => op.Id);

            builder.Property(op => op.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(op => op.Order)
                   .WithMany(o => o.OrderProducts)
                   .HasForeignKey(op => op.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(op => op.Product)
                   .WithMany(p => p.OrderProducts)
                   .HasForeignKey(op => op.ProductId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
