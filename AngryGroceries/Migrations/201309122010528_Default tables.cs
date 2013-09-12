namespace AngryGroceries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Defaulttables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groceries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AngryUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserManagement",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        DisableSignIn = c.Boolean(nullable: false),
                        LastSignInTimeUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetTokens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                        ValidUntilUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserSecrets",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.ListGroceries",
                c => new
                    {
                        List_Id = c.Int(nullable: false),
                        Grocery_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.List_Id, t.Grocery_Id })
                .ForeignKey("dbo.Lists", t => t.List_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groceries", t => t.Grocery_Id, cascadeDelete: true)
                .Index(t => t.List_Id)
                .Index(t => t.Grocery_Id);
            
            CreateTable(
                "dbo.AngryUserLists",
                c => new
                    {
                        AngryUser_Id = c.Int(nullable: false),
                        List_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AngryUser_Id, t.List_Id })
                .ForeignKey("dbo.AngryUsers", t => t.AngryUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lists", t => t.List_Id, cascadeDelete: true)
                .Index(t => t.AngryUser_Id)
                .Index(t => t.List_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AngryUserLists", "List_Id", "dbo.Lists");
            DropForeignKey("dbo.AngryUserLists", "AngryUser_Id", "dbo.AngryUsers");
            DropForeignKey("dbo.AngryUsers", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserManagement", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ListGroceries", "Grocery_Id", "dbo.Groceries");
            DropForeignKey("dbo.ListGroceries", "List_Id", "dbo.Lists");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AngryUserLists", new[] { "List_Id" });
            DropIndex("dbo.AngryUserLists", new[] { "AngryUser_Id" });
            DropIndex("dbo.AngryUsers", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserManagement", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.ListGroceries", new[] { "Grocery_Id" });
            DropIndex("dbo.ListGroceries", new[] { "List_Id" });
            DropTable("dbo.AngryUserLists");
            DropTable("dbo.ListGroceries");
            DropTable("dbo.AspNetUserSecrets");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetTokens");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserManagement");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AngryUsers");
            DropTable("dbo.Lists");
            DropTable("dbo.Groceries");
        }
    }
}
