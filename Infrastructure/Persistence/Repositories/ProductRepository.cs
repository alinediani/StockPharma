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


        public async Task AddAsync(ProductEntity product)
        {
            await _dbContext.Products.AddAsync(product);
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
        public async Task UpdateAsync(ProductEntity product)
        {
            var existingProduct = await _dbContext.Products
                                                      .SingleOrDefaultAsync(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.RawMaterial = product.RawMaterial;
                existingProduct.Price = product.Price;
                existingProduct.Amount = product.Amount;

                _dbContext.Products.Update(existingProduct);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Product not found.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

    }
}
