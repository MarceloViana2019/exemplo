using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    internal class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            ToTable("City");

            HasKey(x => x.Code);
            Property(x => x.Code).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(x => x.Name).IsRequired().HasMaxLength(60);

            HasRequired(x => x.State)
                .WithMany()
                .HasForeignKey<int>(x => x.StateCode);
        }
    }
}
