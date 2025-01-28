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


        public async Task AddAsync(ClientEntity client)
        {
            await _dbContext.Clients.AddAsync(client);
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
        public async Task UpdateAsync(ClientEntity client)
        {
            var existingClient = await _dbContext.Clients
                                                      .SingleOrDefaultAsync(p => p.Id == client.Id);
            if (existingClient != null)
            {
                existingClient.Name = client.Name;
                existingClient.CPF = client.CPF;
                existingClient.Address = client.Address;
                existingClient.Telephone = client.Telephone;
                existingClient.Email = client.Email;

                _dbContext.Clients.Update(existingClient);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Client not found.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _dbContext.Clients.SingleOrDefaultAsync(p => p.Id == id);

            if (client == null)
            {
                throw new InvalidOperationException("Client not found.");
            }

            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
        }

    }
}
