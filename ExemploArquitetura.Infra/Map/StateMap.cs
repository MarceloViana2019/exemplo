using ExemploArquitetura.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ExemploArquitetura.Infra.Map
{
    internal class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            ToTable("State");

            HasKey(x => x.Code);
            Property(x => x.Code).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(x => x.Name).IsRequired().HasMaxLength(60);
            Property(x => x.Initials).IsRequired().HasMaxLength(2);
        }
    }
}
