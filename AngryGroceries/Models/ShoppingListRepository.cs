using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;

namespace AngryGroceries.Models
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private AngryGroceriesDbContext _dataContext;

        /// <summary>
        /// Initializes a new instance of <see cref="ShoppingListRepository"/>
        /// </summary>
        public ShoppingListRepository()
        {
            _dataContext = new AngryGroceriesDbContext();
        }

        /// <summary>
        /// Retrieves all the shopping lists you have access to as a user
        /// </summary>
        /// <returns></returns>
        public List<ShoppingList> GetShoppingLists(string userId)
        {
            var currentUser = _dataContext.Users.FirstOrDefault(user => user.Id == userId);
            return currentUser.Lists.ToList();
        }

        /// <summary>
        /// Retrieves a single shopping list for the current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ShoppingList GetShoppingList(int id, string ownerId)
        {
            var currentUser = _dataContext.Users.FirstOrDefault(user => user.Id == ownerId);

            if (currentUser == null)
            {
                throw new ArgumentException("The provided user does not exist in the database.");
            }

            return currentUser.Lists.FirstOrDefault(list => list.Id == id);
        }

        /// <summary>
        /// Creates a new shopping list
        /// </summary>
        /// <param name="shoppingList"></param>
        /// <returns></returns>
        public void Create(ShoppingList shoppingList, string ownerId)
        {
            using (var scope = new TransactionScope())
            {
                // Assign the provided owner to the shopping list.
                if (shoppingList.Users == null)
                {
                    shoppingList.Users = new Collection<ApplicationUser>();
                }

                shoppingList.Users.Add(_dataContext.Users.FirstOrDefault(usr => usr.Id == ownerId));

                // Store the shopping list as part of this method
                _dataContext.Lists.Add(shoppingList);
                _dataContext.SaveChanges();

                scope.Complete();
            }
        }

        /// <summary>
        /// Updates an existing shopping list
        /// </summary>
        /// <param name="value"></param>
        public void Update(ShoppingList value)
        {
            using (var scope = new TransactionScope())
            {
                var existingList = _dataContext.Lists.FirstOrDefault(list => list.Id == value.Id);

                if (existingList == null)
                {
                    throw new ArgumentException("Provided value does not exist in the database and cannot be updated.");
                }

                existingList.Name = value.Name;

                _dataContext.SaveChanges();
                scope.Complete();
            }
        }

        public void Delete(int id, string ownerId)
        {
            //TODO: Unshare a shopping list when it is shared with someone else
            //TODO: Delete the list when the current user is the last one using the list

            using (TransactionScope scope = new TransactionScope())
            {
                var list = GetShoppingList(id, ownerId);

                if (list == null)
                {
                    throw new ArgumentException("The provided list ID does not refer to an existing list");
                }

                _dataContext.Lists.Remove(list);

                _dataContext.SaveChanges();
                scope.Complete();
            }
        }
    }
}