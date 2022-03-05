using BrokerAPP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerAPP.Infra.Repository
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllAsync();
        Task<Manager> GetByIdAsync(int id);
        Task<IEnumerable<Client>> GetClientsByManagerId(int managerId);
        Task<Manager> CreateAsync(Manager asset);
        Task<Manager> DeleteAsync(Manager asset);
        Task<Manager> UpdateAsync(Manager asset);
    }
}
