using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngryGroceries.Models
{
    public class ShoppingList
    {
        public ShoppingList()
        {
            
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Grocery> Groceries { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}