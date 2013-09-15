using System.Collections.Generic;

namespace AngryGroceries.Models
{
    public class Grocery
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<ShoppingList> Lists { get; set; }
    }
}