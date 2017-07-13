namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Menus", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.Menus", new[] { "RestaurantID" });
            DropIndex("dbo.Menus", new[] { "Location_Id" });
            RenameColumn(table: "dbo.Menus", name: "Location_Id", newName: "LocationID");
            RenameColumn(table: "dbo.Menus", name: "RestaurantID", newName: "Restaurant_Id");
            AlterColumn("dbo.Menus", "Restaurant_Id", c => c.Int());
            AlterColumn("dbo.Menus", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "LocationID");
            CreateIndex("dbo.Menus", "Restaurant_Id");
            AddForeignKey("dbo.Menus", "LocationID", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Menus", "LocationID", "dbo.Locations");
            DropIndex("dbo.Menus", new[] { "Restaurant_Id" });
            DropIndex("dbo.Menus", new[] { "LocationID" });
            AlterColumn("dbo.Menus", "LocationID", c => c.Int());
            AlterColumn("dbo.Menus", "Restaurant_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Menus", name: "Restaurant_Id", newName: "RestaurantID");
            RenameColumn(table: "dbo.Menus", name: "LocationID", newName: "Location_Id");
            CreateIndex("dbo.Menus", "Location_Id");
            CreateIndex("dbo.Menus", "RestaurantID");
            AddForeignKey("dbo.Menus", "RestaurantID", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
