using BrokerAPP.Domain;
using BrokerAPP.Domain.EntitiesRelationship;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerAPP.Infra.EntitiesConfiguration
{
    public class ClientAssetConfiguration : IEntityTypeConfiguration<ClientAsset>
    {
        public void Configure (EntityTypeBuilder<ClientAsset> builder)
        {
            builder.HasKey(x => new { x.AssetId, x.ClientId });
            builder.HasOne<Asset>(x => x.Asset).WithMany(x => x.ClientsAssets)
                .HasForeignKey(x => x.AssetId);
            builder.HasOne<Client>(x => x.Client).WithMany(x => x.ClientsAssets)
                .HasForeignKey(x => x.ClientId);
        }
    }
}