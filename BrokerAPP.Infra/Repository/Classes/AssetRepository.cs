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
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AssetRepository (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Asset> CreateAsync (Asset asset)
        {
            _dbContext.Assets.Add(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<Asset> DeleteAsync (Asset asset)
        {
            _dbContext.Assets.Remove(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync ()
        {
            List<Asset> assetList = await _dbContext.Assets.ToListAsync();
            return assetList;
        }

        public async Task<Asset> GetByIdAsync (int id)
        {
            Asset asset = await _dbContext.Assets.FindAsync(id);
            return asset;
        }

        public async Task<Asset> UpdateAsync (Asset asset)
        {
            _dbContext.Update(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }
    }
}
