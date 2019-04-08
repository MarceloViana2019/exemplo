using ExemploArquitetura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploArquitetura.Infra.Map
{
    internal class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            HasKey(x => x.Id);

            Property(x => x.Login).IsRequired().HasMaxLength(50);
            Property(x => x.Password).IsRequired().HasMaxLength(30);
            Property(x => x.Claim).IsRequired().HasMaxLength(30);
        }
    }
}