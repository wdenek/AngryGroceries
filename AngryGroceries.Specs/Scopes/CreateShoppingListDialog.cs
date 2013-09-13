using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class CreateShoppingListDialog: DialogObject<ShoppingListPage>
    {
        public CreateShoppingListDialog(IWebDriver driver, ShoppingListPage page) : base(driver, page,"create-shopping-list-dialog")
        {
        }

        /// <summary>
        /// Enters the new name for the shopping list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CreateShoppingListDialog EnterName(string name)
        {
            var textBox = RootElement.FindElement(By.CssSelector(".shopping-list-name"));

            textBox.Clear();
            textBox.SendKeys(name);

            return this;
        }
    }
}
