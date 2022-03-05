using BrokerAPP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerAPP.Infra.EntitiesConfiguration
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure (EntityTypeBuilder<Asset> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
        }
    }
}