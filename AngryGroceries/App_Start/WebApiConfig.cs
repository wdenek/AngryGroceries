using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AngryGroceries
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ShoppingListsRoute",
                routeTemplate: "api/shoppinglists/{id}",
                defaults: new {controller = "ShoppingLists", id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
