using BrokerAPP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerAPP.Infra.EntitiesConfiguration
{
    public class AssetGroupConfiguration : IEntityTypeConfiguration<AssetGroup>
    {
        public void Configure (EntityTypeBuilder<AssetGroup> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        }
    }
}