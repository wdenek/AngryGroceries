using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using AngryGroceries.Specs.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AngryGroceries.Specs.StepDefinitions
{
    [Binding]
    public class ShoppingListItemSteps
    {
        private BrowserScenario _browserScenario;

        public ShoppingListItemSteps(BrowserScenario browserScenario)
        {
            _browserScenario = browserScenario;
        }

        [When(@"I add ""(.*)"" to the shopping list")]
        public void WhenIAddToTheShoppingList(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            page.CreateNewItem()
                .EnterText(item)
                .Submit();
        }

        [Then(@"I see ""(.*)"" in the uncompleted items list")]
        public void ThenISeeInTheUncompletedItemsList(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            page.PendingItems().WithItem(item, element => Assert.IsTrue(element != null && element.Displayed));
        }

        [Given(@"I have added ""(.*)"" to the shopping list")]
        public void GivenIHaveAddedToTheShoppingList(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            page.CreateNewItem()
                .EnterText(item)
                .Submit();
        }

        [When(@"I remove ""(.*)"" from the pending items")]
        public void WhenIRemoveFromThePendingItems(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            page.PendingItems().RemoveItem(item).Accept();
        }

        [When(@"I remove ""(.*)"" from the completed items")]
        public void WhenIRemoveFromTheCompletedItems(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            page.CompletedItems().RemoveItem(item).Accept();
        }

        [Then(@"I no longer see ""(.*)"" in the pending items")]
        public void ThenINoLongerSeeItemInThePendingItems(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            page.PendingItems().WithItem(item, element => Assert.IsNull(element,"Shopping list item not removed"));
        }

        [Then(@"I no longer see ""(.*)"" in the completed items")]
        public void ThenINoLongerSeeItemInTheCompletedItems(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            page.CompletedItems().WithItem(item, element => Assert.IsNull(element, "Shopping list item not removed"));
        }

        [When(@"I change ""(.*)"" into ""(.*)"" in the pending items")]
        public void WhenIChangeInto(string originalItem, string newItem)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            page.PendingItems()
                .EditItem(originalItem)
                .EnterText(newItem)
                .Accept();
        }

        [Then(@"I see ""(.*)"" in the pending items")]
        public void ThenISeeItemInThePendingItems(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            page.PendingItems().WithItem(item, 
                element => Assert.IsNotNull(element, "Item not visible in the pending items"));
        }

        [When(@"I mark ""(.*)"" as completed")]
        public void WhenIMarkAsCompleted(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            page.PendingItems().MarkAsCompleted(item);
        }

        [Given(@"I have marked ""(.*)"" as completed")]
        public void GivenIHaveMarkedAsCompleted(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            page.PendingItems().MarkAsCompleted(item);
        }

        [When(@"I mark ""(.*)"" as uncompleted")]
        public void WhenIMarkAsUncompleted(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            page.CompletedItems().MarkAsUncompleted(item);
        }

        [Then(@"I see ""(.*)"" in the completed items")]
        public void ThenISeeItemInTheCompletedList(string item)
        {
            var page = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            page.CompletedItems().WithItem(item, 
                element => Assert.IsNotNull(element, "Item not visible in completed list"));
        }
    }
}
