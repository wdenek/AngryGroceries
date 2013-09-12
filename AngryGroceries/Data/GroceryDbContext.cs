using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngryGroceries.Data
{
    public class GroceryDbContext : IdentityDbContext<User, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public GroceryDbContext() : base("DefaultConnection")
        {
            
        }

        public GroceryDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        
        }

        public DbSet<List> Lists { get; set; }

        public DbSet<Grocery> Groceries { get; set; }
    }
}