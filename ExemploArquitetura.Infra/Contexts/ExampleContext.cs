using ExemploArquitetura.Domain.Entities;
using ExemploArquitetura.Infra.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExemploArquitetura.Infra.Contexts
{
    public class ExampleContext : DbContext
    {
        public ExampleContext() : base("Example")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));


            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ProviderMap());
            modelBuilder.Configurations.Add(new ServiceMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new AddressMap());

        }
    }
}