using Microsoft.Extensions.Configuration;
using Core.Repositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly StockPharmaDbContext _dbContext;
        private readonly string _connectionString;

        public OrderProductRepository(StockPharmaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("StockPharmaCs");
        }

        public async Task AddOrderProductAsync(OrderProductEntity orderProduct)
        {
            orderProduct.Id = 0;
            await _dbContext.OrderProducts.AddAsync(orderProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<OrderProductEntity>> GetByOrderIdAsync(int orderId)
        {
            return await _dbContext.OrderProducts
                .Where(op => op.OrderId == orderId)
                .ToListAsync();
        }

        public async Task DeleteByOrderIdAsync(int orderId)
        {
            var orderProducts = await _dbContext.OrderProducts
                .Where(op => op.OrderId == orderId)
                .ToListAsync();

            _dbContext.OrderProducts.RemoveRange(orderProducts);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteOrderProductAsync(int orderId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
