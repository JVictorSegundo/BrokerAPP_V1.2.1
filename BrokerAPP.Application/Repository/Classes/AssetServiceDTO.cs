using AutoMapper;
using BrokerAPP.Application.DTOs;
using BrokerAPP.Application.Repository.Interface;
using BrokerAPP.Domain;
using BrokerAPP.Infra.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerAPP.Application.Repository.Classes
{
    public class AssetServiceDTO : IAssetServiceDTO
    {
        private readonly IAssetRepository _repository;
        private readonly IMapper _mapper;
        public AssetServiceDTO(IAssetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        public async Task CreateAsync (AssetDTO assetDTO)
        {
            var asset = _mapper.Map<Asset>(assetDTO);
            await _repository.CreateAsync(asset);
        }

        public async Task DeleteAsync (int id)
        {
            var assetById = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(assetById);
        }

        public async Task<IEnumerable<AssetDTO>> GetAllAsync()
        {
            var assetList = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssetDTO>>(assetList);
        }

        public async Task<AssetDTO> GetByIdAsync(int id)
        {
            var asset = await _repository.GetByIdAsync(id);
            return _mapper.Map<AssetDTO>(asset);
        }

        public async Task UpdateAsync(AssetDTO assetDTO)
        {
            var asset = _mapper.Map<Asset>(assetDTO);
            await _repository.UpdateAsync(asset);
        }
    }
}
