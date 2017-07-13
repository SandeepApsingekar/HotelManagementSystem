namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "RestaurantImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "RestaurantImage", c => c.Binary());
        }
    }
}
