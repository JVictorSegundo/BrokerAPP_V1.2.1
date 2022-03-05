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
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ManagerRepository (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Manager> CreateAsync (Manager asset)
        {
            _dbContext.Managers.Add(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<Manager> DeleteAsync (Manager asset)
        {
            _dbContext.Managers.Remove(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync ()
        {
            List<Manager> managerList = await _dbContext.Managers.ToListAsync();
            return managerList;
        }

        public async Task<Manager> GetByIdAsync (int id)
        {
            Manager manager = await _dbContext.Managers.FindAsync(id);
            return manager;
        }

        public async Task<IEnumerable<Client>> GetClientsByManagerId (int managerId)
        {
            List<Client> clientList = await _dbContext.Clients.Where(x => x.ManagerId == managerId).ToListAsync();
            return clientList;
        }

        public async Task<Manager> UpdateAsync(Manager asset)
        {
            _dbContext.Update(asset);
            await _dbContext.SaveChangesAsync();
            return asset;
        }
    }
}
