using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");

            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(60);

            HasRequired(x => x.Address)
                .WithRequiredDependent()
                .Map(x => x.MapKey("address"));
        }
    }
}
