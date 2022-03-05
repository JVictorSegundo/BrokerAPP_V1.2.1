using BrokerAPP.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerAPP.Application.Repository.Interface
{
    public interface IAssetServiceDTO
    {
        Task<IEnumerable<AssetDTO>> GetAllAsync();
        Task<AssetDTO> GetByIdAsync(int id);
        Task CreateAsync(AssetDTO assetDTO);
        Task DeleteAsync(int id);
        Task UpdateAsync(AssetDTO assetDTO);
    }
}
