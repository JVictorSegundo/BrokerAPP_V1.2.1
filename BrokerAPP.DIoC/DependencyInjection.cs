using BrokerAPP.Application.Mapp;
using BrokerAPP.Application.Repository.Classes;
using BrokerAPP.Application.Repository.Interface;
using BrokerAPP.Infra.DBContext;
using BrokerAPP.Infra.Repository;
using BrokerAPP.Infra.Repository.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrokerAPP.DIoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection InfraApplicationServices (this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(config.GetConnectionString("DConnection"),
                x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            service.AddScoped<IAssetRepository, AssetRepository>();
            service.AddScoped<IAssetGroupRepository, AssetGroupRepository>();
            service.AddScoped<IClientRepository, ClientRepository>();
            service.AddScoped<IManagerRepository, ManagerRepository>();

            service.AddScoped<IAssetServiceDTO, AssetServiceDTO>();
            service.AddScoped<IAssetGroupServiceDTO, AssetGroupServiceDTO>();
            service.AddAutoMapper(typeof(DomainToDTOMapping));


            return service;
        }
    }
}
