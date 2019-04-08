using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    public class ServiceMap : EntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
            ToTable("Service");

            HasKey(x => x.Id);

            Property(x => x.Description).IsRequired().HasMaxLength(60);
            Property(x => x.Type).IsRequired().HasMaxLength(60);

            HasRequired(x => x.ServiceAddress)
                .WithRequiredDependent()
                .Map(x => x.MapKey("address"));
        }
    }
}