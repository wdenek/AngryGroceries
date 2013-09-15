using System.Collections.Generic;

namespace AngryGroceries.Models
{
    /// <summary>
    /// Interface for the shopping list repository
    /// </summary>
    public interface IShoppingListRepository
    {
        /// <summary>
        /// Retrieves all the shopping lists you have access to as a user
        /// </summary>
        /// <returns></returns>
        List<ShoppingList> GetShoppingLists(string userId);

        /// <summary>
        /// Retrieves a single shopping list for the current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShoppingList GetShoppingList(int id, string ownerId);

        /// <summary>
        /// Creates a new shopping list
        /// </summary>
        /// <param name="shoppingList"></param>
        /// <returns></returns>
        void Create(ShoppingList shoppingList, string ownerId);

        /// <summary>
        /// Updates an existing shopping list
        /// </summary>
        /// <param name="value"></param>
        void Update(ShoppingList value);

        /// <summary>
        /// Deletes an existing shopping list
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id, string ownerId);
    }
}
