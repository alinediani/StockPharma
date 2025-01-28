using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IRawMaterialRepository
    {
        Task<List<RawMaterialEntity>> GetAllAsync();
        Task AddAsync(RawMaterialEntity rawMaterial);
        Task SaveChangesAsync();
        Task<RawMaterialEntity> GetByIdAsync(int id);
        Task UpdateAsync(RawMaterialEntity rawMaterial);
        Task DeleteAsync(int id);
    }
}
