using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace AngryGroceries.Data
{
    public class AngryUser
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual User AspNetUser { get; set; }
        public virtual ICollection<List> Lists { get; set; }
    }
}