using BrokerAPP.Domain;
using BrokerAPP.Domain.EntitiesRelationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAPP.Infra.Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<IEnumerable<ClientAsset>> GetAssetsByClientId (int clientId);
        Task<Client> CreateAsync(Client asset);
        Task<Client> DeleteAsync(Client asset);
        Task<Client> UpdateAsync(Client asset);
    }
}
