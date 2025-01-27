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
    public class ClientRepository : IClientRepository
    {
        private readonly StockPharmaDbContext _dbContext;
        private readonly string _connectionString;
        public ClientRepository(StockPharmaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("StockPharmaCs");
        }

        public async Task<List<ClientEntity>> GetAllAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }


        public async Task AddAsync(ClientEntity rawMaterial)
        {
            await _dbContext.Clients.AddAsync(rawMaterial);
            await _dbContext.SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ClientEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Clients.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateAsync(ClientEntity rawMaterial)
        {
            var existingClient = await _dbContext.Clients
                                                      .SingleOrDefaultAsync(p => p.Id == rawMaterial.Id);
            if (existingClient != null)
            {
                existingClient.Name = rawMaterial.Name;
                existingClient.Description = rawMaterial.Description;
                existingClient.SupplierId = rawMaterial.SupplierId;
                existingClient.Amount = rawMaterial.Amount;
                existingClient.UoM = rawMaterial.UoM;
                existingClient.Expiration = rawMaterial.Expiration;

                _dbContext.Clients.Update(existingClient);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Raw material not found.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var rawMaterial = await _dbContext.Clients.SingleOrDefaultAsync(p => p.Id == id);

            if (rawMaterial == null)
            {
                throw new InvalidOperationException("Raw material not found.");
            }

            _dbContext.Clients.Remove(rawMaterial);
            await _dbContext.SaveChangesAsync();
        }

    }
}
