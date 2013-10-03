using AngryGroceries.Models;
using Microsoft.AspNet.SignalR;

namespace AngryGroceries.Hubs
{
    public class GroceryHub : Hub
    {
        private IGroceryRepository _groceryRepository;

        public GroceryHub()
        {
            _groceryRepository = new GroceryRepository();
        }

        /// <summary>
        /// Create a new grocery and add it to a list.
        /// </summary>
        /// <param name="grocery"></param>
        /// <param name="listId"></param>
        public void Create(Grocery grocery, int listId)
        {
            _groceryRepository.Create(grocery, listId);
            Clients.All.groceryCreated(new
                {
                    grocery.Id,
                    grocery.Name,
                    grocery.Completed
                });
        }

        /// <summary>
        /// Update an existing grocery.
        /// </summary>
        /// <param name="grocery"></param>
        public void Update(Grocery grocery)
        {
            _groceryRepository.Update(grocery);
            Clients.All.groceryUpdated(new
                {
                    grocery.Id, 
                    grocery.Name, 
                    grocery.Completed
                });
        }

        /// <summary>
        /// Remove an existing grocery.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _groceryRepository.Delete(id);
            Clients.All.groceryDeleted(id);
        }
    }
}