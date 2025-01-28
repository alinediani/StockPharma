using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class StockPharmaDbContext : DbContext
    {
        public StockPharmaDbContext(DbContextOptions<StockPharmaDbContext> options) : base(options)
        {

        }
        public DbSet<RawMaterialEntity> RawMaterials { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderProductEntity> OrderProducts { get; set; }
        public DbSet<ProductRawMaterialEntity> ProductRawMaterials { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
