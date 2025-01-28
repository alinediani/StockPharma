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
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly string _connectionString;
        public OrderRepository(StockPharmaDbContext dbContext, IConfiguration configuration, IOrderProductRepository orderProductRepository)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("StockPharmaCs");
            _orderProductRepository = orderProductRepository;
        }

        public async Task<List<OrderEntity>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }


        public async Task AddAsync(OrderEntity order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync(); 


            foreach (var orderProduct in order.OrderProducts) 
            {
                await _orderProductRepository.AddOrderProductAsync(orderProduct);
            }

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
        public async Task UpdateAsync(OrderEntity order)
        {
            var existingOrder = await _dbContext.Orders
                                                      .SingleOrDefaultAsync(p => p.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.Client = order.Client;
                existingOrder.OrderProducts = order.OrderProducts;
                existingOrder.Amount = order.Amount;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.TotalCoast = order.TotalCoast;

                _dbContext.Orders.Update(existingOrder);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Order not found.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _dbContext.Orders.SingleOrDefaultAsync(p => p.Id == id);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }

    }
}
