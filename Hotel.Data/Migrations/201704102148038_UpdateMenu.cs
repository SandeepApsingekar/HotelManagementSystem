namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Menus", new[] { "LocationID" });
            DropIndex("dbo.Menus", new[] { "Restaurant_Id" });
            RenameColumn(table: "dbo.Menus", name: "LocationID", newName: "Location_Id");
            RenameColumn(table: "dbo.Menus", name: "Restaurant_Id", newName: "RestaurantID");
            AlterColumn("dbo.Menus", "Location_Id", c => c.Int());
            AlterColumn("dbo.Menus", "RestaurantID", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "RestaurantID");
            CreateIndex("dbo.Menus", "Location_Id");
            AddForeignKey("dbo.Menus", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.Menus", "RestaurantID", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Menus", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Menus", new[] { "Location_Id" });
            DropIndex("dbo.Menus", new[] { "RestaurantID" });
            AlterColumn("dbo.Menus", "RestaurantID", c => c.Int());
            AlterColumn("dbo.Menus", "Location_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Menus", name: "RestaurantID", newName: "Restaurant_Id");
            RenameColumn(table: "dbo.Menus", name: "Location_Id", newName: "LocationID");
            CreateIndex("dbo.Menus", "Restaurant_Id");
            CreateIndex("dbo.Menus", "LocationID");
            AddForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants", "Id");
            AddForeignKey("dbo.Menus", "LocationID", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}
