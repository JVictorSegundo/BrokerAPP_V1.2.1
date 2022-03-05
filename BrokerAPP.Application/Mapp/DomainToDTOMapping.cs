using AutoMapper;
using BrokerAPP.Application.DTOs;
using BrokerAPP.Domain;

namespace BrokerAPP.Application.Mapp
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Asset, AssetDTO>().ReverseMap();
            CreateMap<AssetGroup, AssetGroupDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Manager,ManagerDTO>().ReverseMap();
        }
    }
}
