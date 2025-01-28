using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderEntity>> GetAllAsync();
        Task AddAsync(OrderEntity order);
        Task SaveChangesAsync();
        Task<OrderEntity> GetByIdAsync(int id);
        Task UpdateAsync(OrderEntity order);
        Task DeleteAsync(int id);
    }
}
