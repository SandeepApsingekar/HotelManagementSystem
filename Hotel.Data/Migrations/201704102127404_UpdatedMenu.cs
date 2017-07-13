namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Restaurant_Id", c => c.Int());
            CreateIndex("dbo.Menus", "Restaurant_Id");
            AddForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Menus", new[] { "Restaurant_Id" });
            DropColumn("dbo.Menus", "Restaurant_Id");
        }
    }
}
