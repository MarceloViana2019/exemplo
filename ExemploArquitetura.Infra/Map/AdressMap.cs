using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    internal class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable("Address");

            HasKey(x => x.Id);

            Property(x => x.Street).IsRequired().HasMaxLength(60);

            HasRequired(x => x.City)
                .WithMany()
                .Map(x => x.MapKey("city"));
        }
    }
}
