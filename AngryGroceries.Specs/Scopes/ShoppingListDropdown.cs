using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using AngryGroceries.Specs.Util;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    /// <summary>
    /// Scope object to work with the shopping list dropdown
    /// </summary>
    /// <typeparam name="TPage"></typeparam>
    public class ShoppingListDropdown : ScopeObject<ShoppingListPage>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ShoppingListDropdown"/>
        /// </summary>
        /// <param name="driver"></param>
        public ShoppingListDropdown(IWebDriver driver, ShoppingListPage page)
            : base(driver, page)
        {

        }

        /// <summary>
        /// Selects a single shopping list from the dropdown
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ShoppingListDropdown SelectShoppingList(string name)
        {
            Driver.FindElement(By.CssSelector(".shopping-list-dropdown")).Click();
            var menuElement = Driver.WaitFor(driver => driver
                .FindElements(By.CssSelector(".shopping-list-dropdown .dropdown-menu li"))
                .FirstOrDefault(item => item.Text.ToLower().Contains(name.ToLower())));

            menuElement.Click();

            return this;
        }

        /// <summary>
        /// Executes an action on the specified menu item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="elementAction"></param>
        /// <returns></returns>
        public ShoppingListDropdown WithItem(string name, Action<IWebElement> elementAction)
        {
            Driver.FindElement(By.CssSelector(".shopping-list-dropdown")).Click();

            var menuElement = Driver.WaitFor(driver => driver
                .FindElements(By.CssSelector(".shopping-list-dropdown .dropdown-menu li"))
                .FirstOrDefault(item => item.Text.ToLower().Contains(name.ToLower())));

            elementAction(menuElement);

            return this;
        }

        /// <summary>
        /// Creates a new shopping list
        /// </summary>
        /// <returns></returns>
        public CreateShoppingListDialog CreateNew()
        {
            WithItem("Create new", element => element.Click());

            return Then().CreateShoppingListDialog();
        }
    }
}
