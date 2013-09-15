using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngryGroceries.Models
{
    public class AngryGroceriesDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public AngryGroceriesDbContext()
            : base("DefaultConnection")
        {

        }

        public AngryGroceriesDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public DbSet<ShoppingList> Lists { get; set; }

        public DbSet<Grocery> Groceries { get; set; }
    }
}