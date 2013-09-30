using AngryGroceries.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AngryGroceries.Controllers
{
    public class GroceriesController : ApiController
    {
        private IGroceryRepository _groceryRepository;

        public GroceriesController()
        {
            _groceryRepository = new GroceryRepository();
        }

        public GroceriesController(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        // GET api/<controller>/4
        public IEnumerable<object> Get(int id)
        {
            return _groceryRepository.GetGroceries(id).Select(grocery => new 
            {
                Id = grocery.Id,
                Name = grocery.Name,
                Completed = grocery.Completed
            });
        }
    }
}
