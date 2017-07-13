namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Items", new[] { "Menu_Id" });
            RenameColumn(table: "dbo.Items", name: "Menu_Id", newName: "MenuID");
            AlterColumn("dbo.Items", "MenuID", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "MenuID");
            AddForeignKey("dbo.Items", "MenuID", "dbo.Menus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "MenuID", "dbo.Menus");
            DropIndex("dbo.Items", new[] { "MenuID" });
            AlterColumn("dbo.Items", "MenuID", c => c.Int());
            RenameColumn(table: "dbo.Items", name: "MenuID", newName: "Menu_Id");
            CreateIndex("dbo.Items", "Menu_Id");
            AddForeignKey("dbo.Items", "Menu_Id", "dbo.Menus", "Id");
        }
    }
}
