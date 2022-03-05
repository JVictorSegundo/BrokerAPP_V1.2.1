using BrokerAPP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAPP.Infra.Repository
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset> GetByIdAsync (int id);
        Task<Asset> CreateAsync (Asset asset);
        Task<Asset> DeleteAsync (Asset id);
        Task<Asset> UpdateAsync (Asset asset);

    }
}
