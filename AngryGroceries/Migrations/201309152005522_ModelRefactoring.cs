namespace AngryGroceries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelRefactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListGroceries", "List_Id", "dbo.Lists");
            DropForeignKey("dbo.ListGroceries", "Grocery_Id", "dbo.Groceries");
            DropForeignKey("dbo.ApplicationUserLists", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserLists", "List_Id", "dbo.Lists");
            DropIndex("dbo.ListGroceries", new[] { "List_Id" });
            DropIndex("dbo.ListGroceries", new[] { "Grocery_Id" });
            DropIndex("dbo.ApplicationUserLists", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserLists", new[] { "List_Id" });
            CreateTable(
                "dbo.ShoppingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            DropTable("dbo.Lists");
            DropTable("dbo.ListGroceries");
            DropTable("dbo.ApplicationUserLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserLists",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        List_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.List_Id });
            
            CreateTable(
                "dbo.ListGroceries",
                c => new
                    {
                        List_Id = c.Int(nullable: false),
                        Grocery_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.List_Id, t.Grocery_Id });
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.ApplicationUserShoppingLists", "ShoppingList_Id", "dbo.ShoppingLists");
            DropForeignKey("dbo.ApplicationUserShoppingLists", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingListGroceries", "Grocery_Id", "dbo.Groceries");
            DropForeignKey("dbo.ShoppingListGroceries", "ShoppingList_Id", "dbo.ShoppingLists");
            DropIndex("dbo.ApplicationUserShoppingLists", new[] { "ShoppingList_Id" });
            DropIndex("dbo.ApplicationUserShoppingLists", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ShoppingListGroceries", new[] { "Grocery_Id" });
            DropIndex("dbo.ShoppingListGroceries", new[] { "ShoppingList_Id" });
            DropTable("dbo.ApplicationUserShoppingLists");
            DropTable("dbo.ShoppingListGroceries");
            DropTable("dbo.ShoppingLists");
            CreateIndex("dbo.ApplicationUserLists", "List_Id");
            CreateIndex("dbo.ApplicationUserLists", "ApplicationUser_Id");
            CreateIndex("dbo.ListGroceries", "Grocery_Id");
            CreateIndex("dbo.ListGroceries", "List_Id");
            AddForeignKey("dbo.ApplicationUserLists", "List_Id", "dbo.Lists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserLists", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ListGroceries", "Grocery_Id", "dbo.Groceries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ListGroceries", "List_Id", "dbo.Lists", "Id", cascadeDelete: true);
        }
    }
}
