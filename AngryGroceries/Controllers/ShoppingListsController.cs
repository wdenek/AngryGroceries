using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web;
using System.Web.Http;
using AngryGroceries.Models;
using Microsoft.AspNet.Identity;

namespace AngryGroceries.Controllers
{
    public class ShoppingListsController : ApiController
    {
        private IShoppingListRepository _shoppingListRepository;

        public ShoppingListsController()
        {
            _shoppingListRepository = new ShoppingListRepository();
        }

        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            return _shoppingListRepository.GetShoppingLists(User.Identity.GetUserId()).Select(shoppingList => new
            {
                Id = shoppingList.Id,
                Name = shoppingList.Name
            });
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            var shoppingList = _shoppingListRepository.GetShoppingList(id,User.Identity.GetUserId());

            return new
            {
                Id = shoppingList.Id,
                Name = shoppingList.Name
            };
        }

        // POST api/<controller>
        public void Post([FromBody]ShoppingList value)
        {
            _shoppingListRepository.Create(value, User.Identity.GetUserId());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]ShoppingList value)
        {
            var shoppingList = _shoppingListRepository.GetShoppingList(value.Id,User.Identity.GetUserId());

            if (shoppingList == null)
            {
                throw new HttpException(404,"Shopping list not found.");
            }

            _shoppingListRepository.Update(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _shoppingListRepository.Delete(id,User.Identity.GetUserId());
        }
    }
}