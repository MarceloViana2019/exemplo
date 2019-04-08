using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    public class ProviderMap : EntityTypeConfiguration<Provider>
    {
        public ProviderMap()
        {
            ToTable("Provider");
            HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(60);

        }
    }
}
