using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Scopes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AngryGroceries.Specs.Pages
{
    /// <summary>
    /// Contains the structure for the shopping list page.
    /// </summary>
    public class ShoppingListPage: Page
    {
        public ShoppingListPage(IWebDriver driver) : base(driver)
        {

        }

        /// <summary>
        /// Moves to the shopping lists scope
        /// </summary>
        /// <returns></returns>
        public ShoppingListDropdown ShoppingLists()
        {
            return new ShoppingListDropdown(Driver,this);
        } 

        /// <summary>
        /// Moves to the scope of a shopping list item
        /// </summary>
        /// <param name="text">Text to find in the shopping list</param>
        /// <returns>Returns the active shopping list item</returns>
        public ShoppingListItem ShoppingListItem(string text)
        {
            return new ShoppingListItem(Driver, this, text);
        }

        /// <summary>
        /// Moves to the create shopping list dialog scope
        /// </summary>
        /// <returns></returns>
        public CreateShoppingListDialog CreateShoppingListDialog()
        {
            return new CreateShoppingListDialog(Driver,this);
        }
    }
}
