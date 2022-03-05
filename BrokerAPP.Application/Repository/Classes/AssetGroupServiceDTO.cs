using AutoMapper;
using BrokerAPP.Application.DTOs;
using BrokerAPP.Application.Repository.Interface;
using BrokerAPP.Domain;
using BrokerAPP.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAPP.Application.Repository.Classes
{
    public class AssetGroupServiceDTO : IAssetGroupServiceDTO
    {
        private readonly IAssetGroupRepository _repository;
        private readonly IMapper _mapper;
        public AssetGroupServiceDTO (IAssetGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(AssetGroupDTO assetGroupDTO)
        {
            var asset = _mapper.Map<AssetGroup>(assetGroupDTO);
            await _repository.CreateAsync(asset);
        }

        public async Task DeleteAsync(int id)
        {
            var assetById = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(assetById);
        }

        public async Task<IEnumerable<AssetGroupDTO>> GetAllAsync ()
        {
            var assetGroupList = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssetGroupDTO>>(assetGroupList);
        }

        public async Task<IEnumerable<AssetDTO>> GetAssetByAssetGroupId(int assetGroupDTOId)
        {
            var assetList = await _repository.GetAssetByAssetGroupId(assetGroupDTOId);
            return _mapper.Map<IEnumerable<AssetDTO>>(assetList);
        }

        public async Task<AssetGroupDTO> GetByIdAsync(int id)
        {
            var asset = await _repository.GetByIdAsync(id);
            return _mapper.Map<AssetGroupDTO>(asset);
        }

        public async Task UpdateAsync(AssetGroupDTO assetDTO)
        {
            var assetGroup = _mapper.Map<AssetGroup>(assetDTO);
            await _repository.UpdateAsync(assetGroup);
        }
    }
}
