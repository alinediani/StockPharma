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
        public async Task UpdateAsync(RawMaterialEntity rawMaterial)
        {
            var existingRawMaterial = await _dbContext.RawMaterials
                                                      .SingleOrDefaultAsync(p => p.Id == rawMaterial.Id);
            if (existingRawMaterial != null)
            {
                existingRawMaterial.Name = rawMaterial.Name;
                existingRawMaterial.Description = rawMaterial.Description;
                existingRawMaterial.SupplierId = rawMaterial.SupplierId;
                existingRawMaterial.Amount = rawMaterial.Amount;
                existingRawMaterial.UoM = rawMaterial.UoM;
                existingRawMaterial.Expiration = rawMaterial.Expiration;

                _dbContext.RawMaterials.Update(existingRawMaterial);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Raw material not found.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var rawMaterial = await _dbContext.RawMaterials.SingleOrDefaultAsync(p => p.Id == id);

            if (rawMaterial == null)
            {
                throw new InvalidOperationException("Raw material not found.");
            }

            _dbContext.RawMaterials.Remove(rawMaterial);
            await _dbContext.SaveChangesAsync();
        }

    }
}
