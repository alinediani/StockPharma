using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRawMaterialRepository
    {
        Task<List<RawMaterialEntity>> GetAllAsync();
        Task AddAsync(RawMaterialEntity entity);
        Task<RawMaterialEntity> GetByIdAsync(int id);
    }
}
