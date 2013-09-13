using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    /// <summary>
    /// Definition for the edit shopping list dialog element.
    /// </summary>
    public class EditShoppingListDialog: DialogObject<ShoppingListPage>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EditShoppingListDialog"/>
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="page"></param>
        public EditShoppingListDialog(IWebDriver driver, ShoppingListPage page) : base(driver, page,"shopping-list-dialog")
        {
        }

        /// <summary>
        /// Enters the new name for the shopping list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EditShoppingListDialog EnterName(string name)
        {
            var textBox = RootElement.FindElement(By.CssSelector(".shopping-list-name"));

            textBox.Clear();
            textBox.SendKeys(name);

            return this;
        }
    }
}
