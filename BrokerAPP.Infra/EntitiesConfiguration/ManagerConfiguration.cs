using BrokerAPP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrokerAPP.Infra.EntitiesConfiguration
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure (EntityTypeBuilder<Manager> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
        }
    }
}