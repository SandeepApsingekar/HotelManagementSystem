namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderType = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        MenuType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Temp_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TempModels", t => t.Temp_Id)
                .Index(t => t.Temp_Id);
            
            CreateTable(
                "dbo.TempModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(),
                        Email = c.String(),
                        RestaurantName = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        SentEmail = c.Boolean(nullable: false),
                        SentEmailDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Temp_Id", "dbo.TempModels");
            DropForeignKey("dbo.Locations", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Menus", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Items", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Users", new[] { "Temp_Id" });
            DropIndex("dbo.Restaurants", new[] { "User_Id" });
            DropIndex("dbo.Locations", new[] { "Restaurant_Id" });
            DropIndex("dbo.Menus", new[] { "LocationID" });
            DropIndex("dbo.Items", new[] { "Menu_Id" });
            DropTable("dbo.TempModels");
            DropTable("dbo.Users");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Locations");
            DropTable("dbo.Menus");
            DropTable("dbo.Items");
        }
    }
}
