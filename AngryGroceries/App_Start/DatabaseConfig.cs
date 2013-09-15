using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AngryGroceries.App_Start
{
    public static class DatabaseConfig
    {
        public static void Configure()
        {
#if DEBUG
            // Automatically create the database when the app is running in debug mode.
            Database.SetInitializer<AngryGroceriesDbContext>(new CreateDatabaseIfNotExists<AngryGroceriesDbContext>());
#endif

            // Migrate the database to the latest version.
            DbMigrator migrator = new DbMigrator(new Migrations.Configuration());
            migrator.Update();
        }
    }
}