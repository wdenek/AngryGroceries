using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class RemoveItemDialog: DialogObject<ShoppingListPage>
    {
        public RemoveItemDialog(IWebDriver driver, ShoppingListPage page) : base(driver, page,"remove-item-dialog")
        {

        }
    }
}
