using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    internal class ServiceAddressMap : EntityTypeConfiguration<ServiceAddress>
    {
        public ServiceAddressMap()
        {
            ToTable("ServiceAddress");

            HasKey(x => x.Id);

            Property(x => x.Street).IsRequired().HasMaxLength(60);

            HasRequired(x => x.City)
                .WithMany()
                .Map(x => x.MapKey("city"));
        }
    }
}
