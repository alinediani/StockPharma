using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Core.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class RawMaterialRepository : IRawMaterialRepository
    {
        private readonly StockPharmaDbContext _dbContext;
        private readonly string _connectionString;
        public RawMaterialRepository(StockPharmaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("StockPharmaCs");
        }

        public async Task<List<RawMaterialEntity>> GetAllAsync()
        {
            return await _dbContext.RawMaterials.ToListAsync();
        }


        public async Task AddAsync(RawMaterialEntity rawMaterial)
        {
            await _dbContext.RawMaterials.AddAsync(rawMaterial);
            await _dbContext.SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RawMaterialEntity> GetByIdAsync(int id)
        {
            return await _dbContext.RawMaterials.SingleOrDefaultAsync(p => p.Id == id);
        }

    }
}
