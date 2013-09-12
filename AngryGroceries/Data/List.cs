using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngryGroceries.Data
{
    public class List
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Grocery> Groceries { get; set; }
        public virtual ICollection<AngryUser> Users { get; set; }
    }
}