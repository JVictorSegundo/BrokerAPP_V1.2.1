using BrokerAPP.Domain;
using BrokerAPP.Domain.EntitiesRelationship;
using BrokerAPP.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAPP.Infra.Repository.Classes
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ClientRepository (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Client> CreateAsync(Client asset)
        {
            _dbContext.Clients.Add(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<Client> DeleteAsync(Client asset)
        {
            _dbContext.Clients.Remove(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            List<Client> clientList = await _dbContext.Clients.ToListAsync();
            return clientList;
        }

        public async Task<IEnumerable<ClientAsset>> GetAssetsByClientId (int clientId)
        {
            List<ClientAsset> assetList = await _dbContext.ClientsAssets.Where(x => x.ClientId == clientId).ToListAsync();
            return assetList;
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            Client client = await _dbContext.Clients.FindAsync(id);
            return client;
        }

        public async Task<Client> UpdateAsync(Client asset)
        {
            _dbContext.Update(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }
    }
}
