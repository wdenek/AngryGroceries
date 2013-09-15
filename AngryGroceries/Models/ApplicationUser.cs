using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngryGroceries.Models
{
    public class ApplicationUser: User
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public virtual string FullName { get; set; }
        public virtual ICollection<ShoppingList> Lists { get; set; }
    }
}