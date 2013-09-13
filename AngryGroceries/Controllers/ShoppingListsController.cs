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
    public class ShoppingListsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            //TODO: Only retrieve the shopping lists, the user has currently access to.

            using (GroceryDbContext context = new GroceryDbContext())
            {
                return context.Lists.Select(lst => new
                {
                    Id = lst.Id,
                    Name = lst.Name
                }).ToList();
            }
        }

        // GET api/<controller>/5
        public Data.List Get(int id)
        {
            //TODO: Only retrieve the shopping lists, the user has currently access to.

            using (GroceryDbContext context = new GroceryDbContext())
            {
                return context.Lists.FirstOrDefault(lst => lst.Id == id);
            }
        }

        // POST api/<controller>
        public void Post([FromBody]Data.List value)
        {
            //TODO: Link the new list to the current user.

            using (GroceryDbContext context = new GroceryDbContext())
            using (TransactionScope scope = new TransactionScope())
            {
                context.Lists.Add(value);
                context.SaveChanges();
                scope.Complete();
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Data.List value)
        {
            //TODO: Only allow updates to lists that the user owns

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

                context.SaveChanges();
                scope.Complete();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            //TODO: Unshare a shopping list when it is shared with someone else
            //TODO: Delete the list when the current user is the last one using the list

            using (GroceryDbContext context = new GroceryDbContext())
            using (TransactionScope scope = new TransactionScope())
            {
                context.Lists.Remove(context.Lists.FirstOrDefault(lst => lst.Id == id));
                context.SaveChanges();
                scope.Complete();
            }
        }
    }
}