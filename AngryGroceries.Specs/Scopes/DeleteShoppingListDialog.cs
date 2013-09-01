using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class DeleteShoppingListDialog: ScopeObject<ShoppingListPage>
    {
        public DeleteShoppingListDialog(IWebDriver driver, ShoppingListPage page) : base(driver, page)
        {
        }

        public ShoppingListPage Accept()
        {
            var acceptButton = Driver.FindElement(By.CssSelector(".modal-dialog.remove-shopping-list-dialog .accept-button"));
            acceptButton.Click();

            return Then();
        }
    }
}
