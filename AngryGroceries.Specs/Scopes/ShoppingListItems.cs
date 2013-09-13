using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using AngryGroceries.Specs.Util;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class ShoppingListItems: ScopeObject<ShoppingListPage>
    {
        private readonly string _elementId;

        public ShoppingListItems(IWebDriver driver, ShoppingListPage page, string elementId) : base(driver, page)
        {
            _elementId = elementId;
        }

        public ShoppingListItems WithItem(string text, Action<IWebElement> elementAction)
        {
            var element = FindShoppingListItem(text);

            elementAction(element);

            return this;
        }

        public ShoppingListItems RemoveItem(string text)
        {
            var element = FindShoppingListItem(text);
            var removeButton = element.FindElement(By.CssSelector(".remove-item-link"));

            removeButton.Click();

            return this;
        }

        public EditShoppingListItemDialog EditItem(string text)
        {
            var element = FindShoppingListItem(text);
            var editButton = element.FindElement(By.CssSelector(".edit-item-link"));

            editButton.Click();

            return new EditShoppingListItemDialog(Driver,Parent);
        }

        public ShoppingListItems MarkAsCompleted(string text)
        {
            var element = FindShoppingListItem(text);
            var checkbox = element.FindElement(By.CssSelector(".item-marker"));

            if (!checkbox.Selected)
            {
                checkbox.Click();
            }

            return this;
        }

        public ShoppingListItems MarkAsUncompleted(string text)
        {
            var element = FindShoppingListItem(text);
            var checkbox = element.FindElement(By.CssSelector(".item-marker"));

            if (checkbox.Selected)
            {
                checkbox.Click();
            }

            return this;
        }

        private IWebElement RootElement
        {
            get { return Driver.FindElement(By.Id(_elementId)); }
        }

        private IWebElement FindShoppingListItem(string text)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1)); 

            var shoppingListItem = RootElement.FindElements(By.CssSelector("li"))
                .FirstOrDefault(item => item.Text.Contains(text));

            return shoppingListItem;
        }
    }
}
