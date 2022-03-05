using BrokerAPP.Domain;
using BrokerAPP.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAPP.Infra.Repository.Classes
{
    public class AssetGroupRepository : IAssetGroupRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AssetGroupRepository (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AssetGroup> CreateAsync(AssetGroup asset)
        {
            _dbContext.AssetsGroups.Add(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<AssetGroup> DeleteAsync(AssetGroup asset)
        {
            _dbContext.AssetsGroups.Remove(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<IEnumerable<AssetGroup>> GetAllAsync()
        {
            List<AssetGroup> assetGroupList = await _dbContext.AssetsGroups.ToListAsync();
            return assetGroupList;
        }

        public async Task<IEnumerable<Asset>> GetAssetByAssetGroupId(int assetGroupId)
        {
            List<Asset> assetList = await _dbContext.Assets.Where(x => x.AssetGroupId == assetGroupId).ToListAsync();
            return assetList;
        }

        public async Task<AssetGroup> GetByIdAsync(int id)
        {
            AssetGroup asset = await _dbContext.AssetsGroups.FindAsync(id);
            return asset;
        }

        public async Task<AssetGroup> UpdateAsync(AssetGroup asset)
        {
            _dbContext.Update(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }
    }
}
