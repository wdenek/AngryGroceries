namespace AngryGroceries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AngryUsers", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AngryUserLists", "AngryUser_Id", "dbo.AngryUsers");
            DropForeignKey("dbo.AngryUserLists", "List_Id", "dbo.Lists");
            DropIndex("dbo.AngryUsers", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AngryUserLists", new[] { "AngryUser_Id" });
            DropIndex("dbo.AngryUserLists", new[] { "List_Id" });
            CreateTable(
                "dbo.ApplicationUserLists",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        List_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.List_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lists", t => t.List_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.List_Id);
            
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.AngryUsers");
            DropTable("dbo.AngryUserLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AngryUserLists",
                c => new
                    {
                        AngryUser_Id = c.Int(nullable: false),
                        List_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AngryUser_Id, t.List_Id });
            
            CreateTable(
                "dbo.AngryUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.ApplicationUserLists", "List_Id", "dbo.Lists");
            DropForeignKey("dbo.ApplicationUserLists", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserLists", new[] { "List_Id" });
            DropIndex("dbo.ApplicationUserLists", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropTable("dbo.ApplicationUserLists");
            CreateIndex("dbo.AngryUserLists", "List_Id");
            CreateIndex("dbo.AngryUserLists", "AngryUser_Id");
            CreateIndex("dbo.AngryUsers", "AspNetUser_Id");
            AddForeignKey("dbo.AngryUserLists", "List_Id", "dbo.Lists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AngryUserLists", "AngryUser_Id", "dbo.AngryUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AngryUsers", "AspNetUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
