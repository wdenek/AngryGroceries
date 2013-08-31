using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class CreateShoppingListDialog: ScopeObject<ShoppingListPage>
    {
        public CreateShoppingListDialog(IWebDriver driver, ShoppingListPage page) : base(driver, page)
        {
        }

        /// <summary>
        /// Enters the new name for the shopping list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CreateShoppingListDialog EnterName(string name)
        {
            var textBox = Driver.FindElement(By.CssSelector(".modal-dialog.create-shopping-list-dialog .shopping-list-name"));

            textBox.Clear();
            textBox.SendKeys(name);

            return this;
        }

        /// <summary>
        /// Accepts the settings in the dialog
        /// </summary>
        /// <returns></returns>
        public ShoppingListPage Accept()
        {
            var acceptButton = Driver.FindElement(By.CssSelector(".modal-dialog.create-shopping-list-dialog .accept-button"));
            acceptButton.Click();

            return Then();
        }
    }
}
