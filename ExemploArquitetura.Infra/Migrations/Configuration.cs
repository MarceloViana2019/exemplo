namespace ExemploArquitetura.Infra.Migrations
{
    using ExemploArquitetura.Domain.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ExemploArquitetura.Infra.Contexts.ExampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExemploArquitetura.Infra.Contexts.ExampleContext context)
        {
            //  This method will be called after migrating to the latest version.
            var sc = new State(42, "SC", "Santa Catarina");
            var rs = new State(43, "RS", "Rio Grande Do Sul");

            context.States.AddOrUpdate(sc);
            context.States.AddOrUpdate(rs);

            context.Cities.AddOrUpdate(new City(90, "Jaraguá do Sul", sc));
            context.Cities.AddOrUpdate(new City(92, "Joinville", sc));
            context.Cities.AddOrUpdate(new City(223, "Bombinhas", sc));


            context.Cities.AddOrUpdate(new City(158, "Porto Alegre", rs));
            context.Cities.AddOrUpdate(new City(179, "Santa Maria", rs));
            context.Cities.AddOrUpdate(new City(189, "Santo Cristo", rs));

            context.SaveChanges();
        }
    }
}