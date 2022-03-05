using BrokerAPP.Domain;
using BrokerAPP.Domain.EntitiesRelationship;
using Microsoft.EntityFrameworkCore;

namespace BrokerAPP.Infra.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetGroup> AssetsGroups { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ClientAsset> ClientsAssets { get; set; }
                        
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
