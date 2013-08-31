using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class ShoppingListItem: ScopeObject<ShoppingListPage>
    {
        private readonly IWebDriver _driver;
        private readonly string _text;

        /// <summary>
        /// Initializes a new instance of <see cref="ShoppingListItem{TPage}"/>
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="page"></param>
        /// <param name="text"></param>
        public ShoppingListItem(IWebDriver driver, ShoppingListPage page, string text):base(driver,page)
        {
            _driver = driver;
            _text = text;
        }
    }
}
