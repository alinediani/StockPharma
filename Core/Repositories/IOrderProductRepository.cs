using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IOrderProductRepository
    {
        Task AddOrderProductAsync(OrderProductEntity orderProduct);
        Task DeleteOrderProductAsync(int orderId, int productId);
    }
}
