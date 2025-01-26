using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Persistence
{
    public class StockPharmaDbContext : DbContext
    {
        public StockPharmaDbContext(DbContextOptions<StockPharmaDbContext> options) : base(options)
        {

        }
        public DbSet<RawMaterialEntity> RawMaterials { get; set; }
    }
}
