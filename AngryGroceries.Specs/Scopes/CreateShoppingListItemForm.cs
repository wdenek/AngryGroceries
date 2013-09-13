using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class CreateShoppingListItemForm: ScopeObject<ShoppingListPage>
    {
        public CreateShoppingListItemForm(IWebDriver driver, ShoppingListPage page) : base(driver, page)
        {
        }

        public CreateShoppingListItemForm EnterText(string text)
        {
            var addItemTextBox = Driver.FindElement(By.Id("add-item-box"));

            addItemTextBox.Clear();
            addItemTextBox.SendKeys(text);

            return this;
        }

        public CreateShoppingListItemForm Submit()
        {
            var addItemButton = Driver.FindElement(By.Id("add-item-button"));
            addItemButton.Click();

            return this;
        }
    }
}
