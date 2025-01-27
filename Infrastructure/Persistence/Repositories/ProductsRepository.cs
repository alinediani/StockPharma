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
    public class ProductRepository : IProductRepository
    {
        private readonly StockPharmaDbContext _dbContext;
        private readonly string _connectionString;
        public ProductRepository(StockPharmaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("StockPharmaCs");
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }


        public async Task AddAsync(ProductEntity rawMaterial)
        {
            await _dbContext.Products.AddAsync(rawMaterial);
            await _dbContext.SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateAsync(ProductEntity rawMaterial)
        {
            var existingProduct = await _dbContext.Products
                                                      .SingleOrDefaultAsync(p => p.Id == rawMaterial.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = rawMaterial.Name;
                existingProduct.Description = rawMaterial.Description;
                existingProduct.SupplierId = rawMaterial.SupplierId;
                existingProduct.Amount = rawMaterial.Amount;
                existingProduct.UoM = rawMaterial.UoM;
                existingProduct.Expiration = rawMaterial.Expiration;

                _dbContext.Products.Update(existingProduct);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Raw material not found.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var rawMaterial = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (rawMaterial == null)
            {
                throw new InvalidOperationException("Raw material not found.");
            }

            _dbContext.Products.Remove(rawMaterial);
            await _dbContext.SaveChangesAsync();
        }

    }
}
