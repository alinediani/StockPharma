using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderEntity>> GetAllAsync();
        Task AddAsync(OrderEntity entity);
        Task<OrderEntity> GetByIdAsync(int id);
        Task UpdateAsync(OrderEntity rawMaterial);
        Task DeleteAsync(int id);
    }
}
