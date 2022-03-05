using BrokerAPP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerAPP.Infra.EntitiesConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure (EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        }
    }
}