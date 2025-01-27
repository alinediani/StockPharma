using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAllAsync();
        Task AddAsync(ProductEntity entity);
        Task<ProductEntity> GetByIdAsync(int id);
        Task UpdateAsync(ProductEntity rawMaterial);
        Task DeleteAsync(int id);
    }
}
