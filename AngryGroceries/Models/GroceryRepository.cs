using System;
using System.Linq;
using System.Collections.Generic;
using System.Transactions;
using System.Web;
using Microsoft.AspNet.Identity;

namespace AngryGroceries.Models
{
    /// <summary>
    /// Implementation for IGroceryRepository
    /// </summary>
    public class GroceryRepository : IGroceryRepository
    {
        private readonly AngryGroceriesDbContext _dataContext;

        public GroceryRepository()
        {
            _dataContext = new AngryGroceriesDbContext();
        }

        /// <summary>
        /// Retrieves the grocery with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Grocery Get(int id)
        {
            return _dataContext.Groceries.FirstOrDefault(grocery => grocery.Id == id);
        }

        /// <summary>
        /// Retrieves previously added groceries by the user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Grocery> GetGroceries(int id)
        {
            var existingList = _dataContext.Lists.FirstOrDefault(list => list.Id == id);

            if (existingList == null)
            {
                throw new ArgumentException("Provided value does not exist in the database and cannot be updated.");
            }
            
            return existingList.Groceries.ToList();
        }

        /// <summary>
        /// Create and add a grocery to a shoppinglist.
        /// </summary>
        /// <param name="grocery"></param>
        /// <param name="listId"></param>
        public void Create(Grocery grocery, int listId)
        {
            using (var scope = new TransactionScope())
            {
                var existingList = _dataContext.Lists.FirstOrDefault(list => list.Id == listId);

                if (existingList == null)
                {
                    throw new ArgumentException("Provided value does not exist in the database and cannot be updated.");
                }

                existingList.Groceries.Add(grocery);
                _dataContext.SaveChanges();
                scope.Complete();
            }
        }

        /// <summary>
        /// Update an existing grocery.
        /// </summary>
        /// <param name="grocery"></param>
        public void Update(Grocery grocery)
        {
            using (var scope = new TransactionScope())
            {
                var existingGrocery = _dataContext.Groceries.FirstOrDefault(groc => groc.Id == grocery.Id);

                if (existingGrocery == null)
                {
                    throw new ArgumentException("Provided value does not exist in the database and cannot be updated.");
                }

                existingGrocery.Name = grocery.Name;
                existingGrocery.Completed = grocery.Completed;
                _dataContext.SaveChanges();
                scope.Complete();
            }
        }

        /// <summary>
        /// Remove an existing grocery.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (var scope = new TransactionScope())
            {
                var existingGrocery = _dataContext.Groceries.FirstOrDefault(groc => groc.Id == id);

                if (existingGrocery == null)
                {
                    throw new ArgumentException("Provided value does not exist in the database and cannot be updated.");
                }

                _dataContext.Groceries.Remove(existingGrocery);
                _dataContext.SaveChanges();
                scope.Complete();
            }
        }
    }
}