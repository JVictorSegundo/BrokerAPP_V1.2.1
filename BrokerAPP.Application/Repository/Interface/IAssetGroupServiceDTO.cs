using BrokerAPP.Application.DTOs;
using BrokerAPP.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerAPP.Application.Repository.Interface
{
    public interface IAssetGroupServiceDTO
    {
        Task<IEnumerable<AssetGroupDTO>> GetAllAsync();
        Task<AssetGroupDTO> GetByIdAsync(int id);
        Task<IEnumerable<AssetDTO>> GetAssetByAssetGroupId(int assetGroupDTOId);
        Task CreateAsync(AssetGroupDTO assetDTO);
        Task DeleteAsync(int id);
        Task UpdateAsync(AssetGroupDTO assetDTO);
    }
}
