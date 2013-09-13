using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web;
using System.Web.Http;
using AngryGroceries.Data;

namespace AngryGroceries.Controllers
{
    public class ShoppingListApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Data.List> Get()
        {
            using (GroceryDbContext context = new GroceryDbContext())
            {
                return context.Lists.ToList();
            }
        }

        // GET api/<controller>/5
        public Data.List Get(int id)
        {
            using (GroceryDbContext context = new GroceryDbContext())
            {
                return context.Lists.FirstOrDefault(lst => lst.Id == id);
            }
        }

        // POST api/<controller>
        public void Post([FromBody]Data.List value)
        {
            using (GroceryDbContext context = new GroceryDbContext())
            using (TransactionScope scope = new TransactionScope())
            {
                context.Lists.Add(value);
                scope.Complete();
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Data.List value)
        {
            
            using (GroceryDbContext context = new GroceryDbContext())
            using (TransactionScope scope = new TransactionScope())
            {
                var existingList = context.Lists.FirstOrDefault(lst => lst.Id == value.Id);

                if (existingList == null)
                {
                    throw new HttpException(404,"Shopping list not found");
                }

                // Update only the name of the list.
                // Skip the rest of the properties for now.
                //TODO: Find a better and easier way to do this using a model binder.
                existingList.Name = value.Name;

                scope.Complete();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (GroceryDbContext context = new GroceryDbContext())
            using (TransactionScope scope = new TransactionScope())
            {
                context.Lists.Remove(context.Lists.FirstOrDefault(lst => lst.Id == id));
                scope.Complete();
            }
        }
    }
}