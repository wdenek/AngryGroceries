namespace AngryGroceries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabaseStructure : DbMigration
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
                "dbo.ShoppingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        FullName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                "dbo.ShoppingListGroceries",
                c => new
                    {
                        ShoppingList_Id = c.Int(nullable: false),
                        Grocery_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoppingList_Id, t.Grocery_Id })
                .ForeignKey("dbo.ShoppingLists", t => t.ShoppingList_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groceries", t => t.Grocery_Id, cascadeDelete: true)
                .Index(t => t.ShoppingList_Id)
                .Index(t => t.Grocery_Id);
            
            CreateTable(
                "dbo.ApplicationUserShoppingLists",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ShoppingList_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ShoppingList_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingLists", t => t.ShoppingList_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ShoppingList_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserManagement", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserShoppingLists", "ShoppingList_Id", "dbo.ShoppingLists");
            DropForeignKey("dbo.ApplicationUserShoppingLists", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingListGroceries", "Grocery_Id", "dbo.Groceries");
            DropForeignKey("dbo.ShoppingListGroceries", "ShoppingList_Id", "dbo.ShoppingLists");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserManagement", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserShoppingLists", new[] { "ShoppingList_Id" });
            DropIndex("dbo.ApplicationUserShoppingLists", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ShoppingListGroceries", new[] { "Grocery_Id" });
            DropIndex("dbo.ShoppingListGroceries", new[] { "ShoppingList_Id" });
            DropTable("dbo.ApplicationUserShoppingLists");
            DropTable("dbo.ShoppingListGroceries");
            DropTable("dbo.AspNetUserSecrets");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetTokens");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserManagement");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ShoppingLists");
            DropTable("dbo.Groceries");
        }
    }
}
