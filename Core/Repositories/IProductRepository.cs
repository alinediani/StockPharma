using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAllAsync();
        Task AddAsync(ProductEntity product);
        Task SaveChangesAsync();
        Task<ProductEntity> GetByIdAsync(int id);
        Task UpdateAsync(ProductEntity product);
        Task DeleteAsync(int id);
    }
}
