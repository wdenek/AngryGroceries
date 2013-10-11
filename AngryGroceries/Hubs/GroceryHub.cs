using System.Collections.Concurrent;
using AngryGroceries.Models;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;

namespace AngryGroceries.Hubs
{
    public class GroceryHub : Hub
    {
        private IGroceryRepository _groceryRepository;
        private readonly static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();
        
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
            string groupName = listId.ToString();

            _groceryRepository.Create(grocery, listId);
            
            Clients.Group(groupName).groceryCreated(new
                {
                    grocery.Id,
                    grocery.Name,
                    grocery.Completed,
                    grocery.CorrelationId
                });
        }

        /// <summary>
        /// Update an existing grocery.
        /// </summary>
        /// <param name="grocery"></param>
        public void Update(Grocery grocery)
        {
            var existingGrocery = _groceryRepository.Get(grocery.Id);

            if (existingGrocery != null)
            {
                string groupName = existingGrocery.List.Id.ToString();
                _groceryRepository.Update(grocery);

                Clients.Group(groupName).groceryUpdated(new
                {
                    grocery.Id,
                    grocery.Name,
                    grocery.Completed,
                    grocery.CorrelationId
                });               
            }

        }

        /// <summary>
        /// Remove an existing grocery.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Grocery grocery = _groceryRepository.Get(id);
            
            if (grocery != null)
            {
                string groupName = grocery.List.Id.ToString();
                _groceryRepository.Delete(id);
                Clients.Group(groupName).groceryDeleted(id);
            }
        }

        /// <summary>
        /// Subscribe to list events
        /// </summary>
        /// <param name="listId"></param>
        public void Subscribe(int listId)
        {
            Unsubscribe(listId);
            
            Groups.Add(Context.ConnectionId, listId.ToString());
            Connections.TryAdd(Context.ConnectionId, listId.ToString());
        }
        
        /// <summary>
        /// Unsubscribe from the list events
        /// </summary>
        /// <param name="listId"></param>
        public void Unsubscribe(int listId)
        {
            string unsubscribeId;
            if (Connections.TryRemove(Context.ConnectionId, out unsubscribeId))
            {
                Groups.Remove(Context.ConnectionId, unsubscribeId);
            }
        }
    }
}