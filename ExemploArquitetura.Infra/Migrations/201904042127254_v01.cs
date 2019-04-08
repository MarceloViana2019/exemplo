namespace ExemploArquitetura.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60, unicode: false),
                        StateCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.State", t => t.StateCode)
                .Index(t => t.StateCode);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 2, unicode: false),
                        Name = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60, unicode: false),
                        address = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.address)
                .Index(t => t.address);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Street = c.String(nullable: false, maxLength: 60, unicode: false),
                        city = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.city)
                .Index(t => t.city);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 60, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(nullable: false, maxLength: 60, unicode: false),
                        Customer_Id = c.Guid(),
                        Provider_Id = c.Guid(),
                        address = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .ForeignKey("dbo.Provider", t => t.Provider_Id)
                .ForeignKey("dbo.ServiceAddress", t => t.address)
                .Index(t => t.Customer_Id)
                .Index(t => t.Provider_Id)
                .Index(t => t.address);
            
            CreateTable(
                "dbo.ServiceAddress",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Street = c.String(maxLength: 8000, unicode: false),
                        City_Code = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.City_Code)
                .Index(t => t.City_Code);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 30, unicode: false),
                        Claim = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Service", "address", "dbo.ServiceAddress");
            DropForeignKey("dbo.ServiceAddress", "City_Code", "dbo.City");
            DropForeignKey("dbo.Service", "Provider_Id", "dbo.Provider");
            DropForeignKey("dbo.Service", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Customer", "address", "dbo.Address");
            DropForeignKey("dbo.Address", "city", "dbo.City");
            DropForeignKey("dbo.City", "StateCode", "dbo.State");
            DropIndex("dbo.ServiceAddress", new[] { "City_Code" });
            DropIndex("dbo.Service", new[] { "address" });
            DropIndex("dbo.Service", new[] { "Provider_Id" });
            DropIndex("dbo.Service", new[] { "Customer_Id" });
            DropIndex("dbo.Address", new[] { "city" });
            DropIndex("dbo.Customer", new[] { "address" });
            DropIndex("dbo.City", new[] { "StateCode" });
            DropTable("dbo.User");
            DropTable("dbo.ServiceAddress");
            DropTable("dbo.Service");
            DropTable("dbo.Provider");
            DropTable("dbo.Address");
            DropTable("dbo.Customer");
            DropTable("dbo.State");
            DropTable("dbo.City");
        }
    }
}
