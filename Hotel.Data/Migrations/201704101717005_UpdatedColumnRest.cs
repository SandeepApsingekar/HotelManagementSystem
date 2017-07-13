namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedColumnRest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Locations", new[] { "Restaurant_Id" });
            RenameColumn(table: "dbo.Locations", name: "Restaurant_Id", newName: "RestaurantID");
            AlterColumn("dbo.Locations", "RestaurantID", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "RestaurantID");
            AddForeignKey("dbo.Locations", "RestaurantID", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.Locations", new[] { "RestaurantID" });
            AlterColumn("dbo.Locations", "RestaurantID", c => c.Int());
            RenameColumn(table: "dbo.Locations", name: "RestaurantID", newName: "Restaurant_Id");
            CreateIndex("dbo.Locations", "Restaurant_Id");
            AddForeignKey("dbo.Locations", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
