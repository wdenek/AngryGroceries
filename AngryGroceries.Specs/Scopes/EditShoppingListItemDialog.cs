using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class EditShoppingListItemDialog : DialogObject<ShoppingListPage>
    {
        public EditShoppingListItemDialog(IWebDriver driver, ShoppingListPage page) : base(driver, page,"edit-item-dialog")
        {
        }

        public EditShoppingListItemDialog EnterText(string text)
        {
            var element = RootElement.FindElement(By.CssSelector(".item-text"));

            element.Clear();
            element.SendKeys(text);

            return this;
        }
    }
}
