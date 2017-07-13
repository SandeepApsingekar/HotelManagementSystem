namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.Locations", new[] { "RestaurantID" });
            CreateTable(
                "dbo.RestaurantLocations",
                c => new
                    {
                        Restaurant_Id = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_Id, t.Location_Id })
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantLocations", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.RestaurantLocations", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.RestaurantLocations", new[] { "Location_Id" });
            DropIndex("dbo.RestaurantLocations", new[] { "Restaurant_Id" });
            DropTable("dbo.RestaurantLocations");
            CreateIndex("dbo.Locations", "RestaurantID");
            AddForeignKey("dbo.Locations", "RestaurantID", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
    }
}
