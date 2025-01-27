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
    public class OrderRepository : IOrderRepository
    {
        private readonly StockPharmaDbContext _dbContext;
        private readonly string _connectionString;
        public OrderRepository(StockPharmaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("StockPharmaCs");
        }

        public async Task<List<OrderEntity>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }


        public async Task AddAsync(OrderEntity rawMaterial)
        {
            await _dbContext.Orders.AddAsync(rawMaterial);
            await _dbContext.SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateAsync(OrderEntity rawMaterial)
        {
            var existingOrder = await _dbContext.Orders
                                                      .SingleOrDefaultAsync(p => p.Id == rawMaterial.Id);
            if (existingOrder != null)
            {
                existingOrder.Name = rawMaterial.Name;
                existingOrder.Description = rawMaterial.Description;
                existingOrder.SupplierId = rawMaterial.SupplierId;
                existingOrder.Amount = rawMaterial.Amount;
                existingOrder.UoM = rawMaterial.UoM;
                existingOrder.Expiration = rawMaterial.Expiration;

                _dbContext.Orders.Update(existingOrder);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Raw material not found.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var rawMaterial = await _dbContext.Orders.SingleOrDefaultAsync(p => p.Id == id);

            if (rawMaterial == null)
            {
                throw new InvalidOperationException("Raw material not found.");
            }

            _dbContext.Orders.Remove(rawMaterial);
            await _dbContext.SaveChangesAsync();
        }

    }
}
