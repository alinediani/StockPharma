using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StockPharmaDbContext _dbContext;
        private readonly IProductRawMaterialRepository _productRawMaterialRepository;

        public ProductRepository(StockPharmaDbContext dbContext, IProductRawMaterialRepository productRawMaterialRepository)
        {
            _dbContext = dbContext;
            _productRawMaterialRepository = productRawMaterialRepository;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _dbContext.Products
                           .Include(p => p.ProductRawMaterials)
                               .ThenInclude(prm => prm.RawMaterial) // Inclui o RawMaterial relacionado
                           .ToListAsync();
        }

        public async Task AddAsync(ProductEntity product)
        {
            // Adiciona o produto
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            // Adiciona as relações de matérias-primas
            foreach (var productRawMaterial in product.ProductRawMaterials)
            {
                productRawMaterial.ProductId = product.Id; // Atualiza o ProductId
                await _productRawMaterialRepository.AddProductRawMaterialAsync(productRawMaterial);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Products
                                   .Include(p => p.ProductRawMaterials) // Inclui as relações de matérias-primas
                                   .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            var existingProduct = await _dbContext.Products
                                                  .Include(p => p.ProductRawMaterials) // Inclui as relações existentes
                                                  .SingleOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                // Atualiza os campos do produto
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Amount = product.Amount;

                // Atualiza as relações de matérias-primas
                _dbContext.ProductRawMaterials.RemoveRange(existingProduct.ProductRawMaterials); // Remove as existentes
                foreach (var productRawMaterial in product.ProductRawMaterials)
                {
                    productRawMaterial.ProductId = product.Id; // Atualiza o ProductId
                    await _productRawMaterialRepository.AddProductRawMaterialAsync(productRawMaterial);
                }

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
            var product = await _dbContext.Products
                                           .Include(p => p.ProductRawMaterials) // Inclui as relações
                                           .SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            // Remove as relações de matérias-primas
            _dbContext.ProductRawMaterials.RemoveRange(product.ProductRawMaterials);

            // Remove o produto
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
