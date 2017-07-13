namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someunknownupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "RestaurantName", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "RestaurantDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "RestaurantDescription", c => c.String());
            AlterColumn("dbo.Restaurants", "RestaurantName", c => c.String());
        }
    }
}
