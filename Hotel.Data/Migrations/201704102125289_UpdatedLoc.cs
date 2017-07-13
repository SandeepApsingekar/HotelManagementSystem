namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedLoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestaurantLocations", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantLocations", "Location_Id", "dbo.Locations");
            DropIndex("dbo.RestaurantLocations", new[] { "Restaurant_Id" });
            DropIndex("dbo.RestaurantLocations", new[] { "Location_Id" });
            CreateIndex("dbo.Locations", "RestaurantID");
            AddForeignKey("dbo.Locations", "RestaurantID", "dbo.Restaurants", "Id", cascadeDelete: true);
            DropTable("dbo.RestaurantLocations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RestaurantLocations",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_Id, t.Location_Id });
            
            DropForeignKey("dbo.Locations", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.Locations", new[] { "RestaurantID" });
            CreateIndex("dbo.RestaurantLocations", "Location_Id");
            CreateIndex("dbo.RestaurantLocations", "Restaurant_Id");
            AddForeignKey("dbo.RestaurantLocations", "Location_Id", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RestaurantLocations", "Restaurant_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
    }
}
