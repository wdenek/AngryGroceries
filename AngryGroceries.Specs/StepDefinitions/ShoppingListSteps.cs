using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using AngryGroceries.Specs.Util;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AngryGroceries.Specs.StepDefinitions
{
    [Binding]
    public class ShoppingListSteps
    {
        private readonly IBrowserScenario _browserScenario;

        public ShoppingListSteps(IBrowserScenario browserScenario)
        {
            _browserScenario = browserScenario;
        }

        [When(@"I create a new shopping list")]
        public void WhenICreateANewShoppingList()
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            // Use the shopping lists menu to create a new shopping list
            homepage.CreateShoppingList();
        }

        [When(@"I enter the name ""(.*)""")]
        public void WhenIEnterTheName(string name)
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            homepage.CreateShoppingListDialog().EnterName(name);
        }

        [When(@"I accept the settings for the new shopping list")]
        public void WhenIAcceptTheSettingsForTheNewShoppingList()
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>(); 
            homepage.CreateShoppingListDialog().Accept();
        }

        [Then(@"I see the shopping list ""(.*)""")]
        public void ThenISeeTheShoppingList(string name)
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            homepage.WithSelectedShoppingList(element => Assert.IsNotNull(element, "Shopping list not visible."));
        }

        [Given(@"I have a shopping list ""(.*)""")]
        public void GivenIHaveAShoppingList(string name)
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            homepage
                .CreateShoppingList()
                .EnterName(name)
                .Accept();
        }

        [When(@"I edit the shopping list")]
        public void WhenIEditTheShoppingList()
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            homepage.EditShoppingList();
        }

        [When(@"I change the name to ""(.*)""")]
        public void WhenIEnter(string name)
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            homepage.EditShoppingListDialog().EnterName(name);
        }

        [When(@"I accept the settings for the shopping list")]
        public void WhenIAcceptTheSettingsForTheShoppingList()
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();
            homepage.EditShoppingListDialog().Accept();
        }

        [Given(@"I have the following shopping lists")]
        public void GivenIHaveTheFollowingShoppingLists(Table table)
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            foreach (var row in table.Rows)
            {
                homepage
                    .CreateShoppingList()
                    .EnterName(row["name"])
                    .Accept();
            }
        }

        [Given(@"I have selected ""(.*)""")]
        public void GivenIHaveSelected(string name)
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            homepage.ShoppingLists().SelectShoppingList(name);
        }

        [When(@"I delete the shopping list")]
        public void WhenIDeleteTheShoppingList()
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            homepage.DeleteShoppingList().Accept();
        }

        [Then(@"The shopping list ""(.*)"" is selected")]
        public void ThenTheShoppingListIsSelected(string name)
        {
            var homepage = _browserScenario.Navigator.CurrentPage<ShoppingListPage>();

            homepage.WithSelectedShoppingList(item => Assert.AreEqual(name,item.Text,"Wrong shopping list selected."));
        }

    }
}
