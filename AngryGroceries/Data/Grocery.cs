using System.Collections.Generic;

namespace AngryGroceries.Data
{
    public class Grocery
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<List> Lists { get; set; }
    }
}