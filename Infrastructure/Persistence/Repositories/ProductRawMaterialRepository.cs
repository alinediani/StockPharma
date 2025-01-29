using Microsoft.Extensions.Configuration;
using Core.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRawMaterialRepository : IProductRawMaterialRepository
    {
        private readonly StockPharmaDbContext _dbContext;
        private readonly string _connectionString;

        public ProductRawMaterialRepository(StockPharmaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("StockPharmaCs");
        }

        public async Task AddProductRawMaterialAsync(ProductRawMaterialEntity productRawMaterial)
        {
            productRawMaterial.ProductRawMaterialId = 0;
            await _dbContext.ProductRawMaterials.AddAsync(productRawMaterial);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProductRawMaterialEntity>> GetByProductIdAsync(int productId)
        {
            return await _dbContext.ProductRawMaterials
                .Where(prm => prm.ProductId == productId)
                .ToListAsync();
        }

        public async Task DeleteByProductIdAsync(int productId)
        {
            var productRawMaterials = await _dbContext.ProductRawMaterials
                .Where(prm => prm.ProductId == productId)
                .ToListAsync();

            _dbContext.ProductRawMaterials.RemoveRange(productRawMaterials);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteProductRawMaterialAsync(int productId, int rawMaterialId)
        {
            throw new NotImplementedException();
        }
    }
}
