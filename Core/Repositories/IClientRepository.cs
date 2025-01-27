using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IClientRepository
    {
        Task<List<ClientEntity>> GetAllAsync();
        Task AddAsync(ClientEntity entity);
        Task<ClientEntity> GetByIdAsync(int id);
        Task UpdateAsync(ClientEntity rawMaterial);
        Task DeleteAsync(int id);
    }
}
