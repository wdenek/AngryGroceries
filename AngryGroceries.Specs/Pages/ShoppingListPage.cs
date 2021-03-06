﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Scopes;
using AngryGroceries.Specs.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace AngryGroceries.Specs.Pages
{
    /// <summary>
    /// Contains the structure for the shopping list page.
    /// </summary>
    public class ShoppingListPage: Page
    {
        public ShoppingListPage(IWebDriver driver) : base(driver)
        {

        }

        public ShoppingListPage WithSelectedShoppingList(Action<IWebElement> elementAction)
        {
            var element = Driver.FindElement(By.CssSelector(".shopping-list-dropdown h1"));
            elementAction(element);

            return this;
        }

        /// <summary>
        /// Moves to the shopping lists scope
        /// </summary>
        /// <returns></returns>
        public ShoppingListDropdown ShoppingLists()
        {
            return new ShoppingListDropdown(Driver,this);
        } 

        /// <summary>
        /// Moves to the scope of a shopping list item
        /// </summary>
        /// <param name="text">Text to find in the shopping list</param>
        /// <returns>Returns the active shopping list item</returns>
        public ShoppingListItem ShoppingListItem(string text)
        {
            return new ShoppingListItem(Driver, this, text);
        }

        public CreateShoppingListDialog CreateShoppingList()
        {
            var createButton = Driver.WaitFor(driver => driver.FindElement(By.CssSelector(".create-shopping-list-button")));
            
            if (createButton != null && createButton.Displayed)
            {
                createButton.Click();
            }
            else
            {
                ShoppingLists().CreateNew();
            }

            return CreateShoppingListDialog();
        }

        /// <summary>
        /// Moves to the create shopping list dialog scope
        /// </summary>
        /// <returns></returns>
        public CreateShoppingListDialog CreateShoppingListDialog()
        {
            return new CreateShoppingListDialog(Driver,this);
        }

        /// <summary>
        /// Edits the current shopping list
        /// </summary>
        /// <returns></returns>
        public EditShoppingListDialog EditShoppingList()
        {
            var element = Driver.FindElement(By.CssSelector(".edit-shopping-list-button"));
            element.Click();

            return EditShoppingListDialog();
        }

        /// <summary>
        /// Moves into the edit shopping list dialog scope
        /// </summary>
        /// <returns></returns>
        public EditShoppingListDialog EditShoppingListDialog()
        {
            return new EditShoppingListDialog(Driver, this);
        }

        /// <summary>
        /// Deletes the currently selected shopping list
        /// </summary>
        /// <returns></returns>
        public DeleteShoppingListDialog DeleteShoppingList()
        {
            var element = Driver.FindElement(By.CssSelector(".remove-shopping-list-button"));
            element.Click();

            return new DeleteShoppingListDialog(Driver,this);
        }

        /// <summary>
        /// Executes an assertion on the create shopping list button
        /// </summary>
        /// <param name="action"></param>
        public void WithCreateShoppingListButton(Action<IWebElement> action)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));

            var createButton = Driver.WaitFor(driver => driver.FindElement(
                By.CssSelector(".create-shopping-list-button")));

            action(createButton);
        }

        /// <summary>
        /// Enters the create new shopping list item scope
        /// </summary>
        /// <returns></returns>
        public CreateShoppingListItemForm CreateNewItem()
        {
            return new CreateShoppingListItemForm(Driver,this);
        }

        /// <summary>
        /// Enters the completed items scope
        /// </summary>
        /// <returns></returns>
        public ShoppingListItems CompletedItems()
        {
            return new ShoppingListItems(Driver, this, "completed-items");
        }

        /// <summary>
        /// Enters the pending items scope
        /// </summary>
        /// <returns></returns>
        public ShoppingListItems PendingItems()
        {
            return new ShoppingListItems(Driver, this, "pending-items");
        }
    }
}
