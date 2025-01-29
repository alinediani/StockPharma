using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProductEntity>
    {
        public void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.HasKey(op => op.Id); // Define 'Id' como chave primária

            builder.Property(op => op.Id)
                   .ValueGeneratedOnAdd(); // Auto-incremento para SQL Server

            builder.HasOne(op => op.Order)
                   .WithMany(o => o.OrderProducts)
                   .HasForeignKey(op => op.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(op => op.Product)
                   .WithMany(p => p.OrderProducts)
                   .HasForeignKey(op => op.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(op => new { op.OrderId, op.ProductId }).IsUnique();
        }
    }
}
