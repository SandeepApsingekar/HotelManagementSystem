namespace Hotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleInfoAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoleInfoes",
                c => new
                    {
                        UserInfoId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserInfoId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserInfoes", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserInfoRoles",
                c => new
                    {
                        UserInfo_UserId = c.Int(nullable: false),
                        Role_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserInfo_UserId, t.Role_RoleId })
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.UserInfo_UserId)
                .Index(t => t.Role_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleInfoes", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.UserRoleInfoes", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserInfoRoles", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserInfoRoles", "UserInfo_UserId", "dbo.UserInfoes");
            DropIndex("dbo.UserInfoRoles", new[] { "Role_RoleId" });
            DropIndex("dbo.UserInfoRoles", new[] { "UserInfo_UserId" });
            DropIndex("dbo.UserRoleInfoes", new[] { "UserId" });
            DropIndex("dbo.UserRoleInfoes", new[] { "RoleId" });
            DropTable("dbo.UserInfoRoles");
            DropTable("dbo.UserRoleInfoes");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Roles");
        }
    }
}
