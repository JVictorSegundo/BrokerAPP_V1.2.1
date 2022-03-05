using BrokerAPP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAPP.Infra.Repository
{
    public interface IAssetGroupRepository
    {
        Task<IEnumerable<AssetGroup>> GetAllAsync();
        Task<AssetGroup> GetByIdAsync(int id);
        Task<IEnumerable<Asset>> GetAssetByAssetGroupId (int assetGroupId);
        Task<AssetGroup> CreateAsync(AssetGroup asset);
        Task<AssetGroup> DeleteAsync(AssetGroup asset);
        Task<AssetGroup> UpdateAsync(AssetGroup asset);
    }
}
