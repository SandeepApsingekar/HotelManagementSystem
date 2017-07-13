namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RestaurantImage", c => c.Binary());
            AddColumn("dbo.Restaurants", "RestaurantDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "RestaurantDescription");
            DropColumn("dbo.Restaurants", "RestaurantImage");
        }
    }
}
