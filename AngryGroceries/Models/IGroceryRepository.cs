using System.Collections.Generic;

namespace AngryGroceries.Models
{
    /// <summary>
    /// Interface for the grocery repository
    /// </summary>
    public interface IGroceryRepository
    {
        /// <summary>
        /// Retrieves previously added groceries by the user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Grocery> GetGroceries(int id);

        /// <summary>
        /// Create and add a grocery to a shoppinglist.
        /// </summary>
        /// <param name="grocery"></param>
        /// <param name="listId"></param>
        void Create(Grocery grocery, int listId);

        /// <summary>
        /// Update an existing grocery.
        /// </summary>
        /// <param name="grocery"></param>
        void Update(Grocery grocery);

        /// <summary>
        /// Remove an existing grocery.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}