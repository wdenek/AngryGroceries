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
            homepage.ShoppingLists()
                .CreateNew();
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

            homepage.ShoppingLists()
                .WithItem(name, element => Assert.IsNotNull(element, "Shopping list is not visible."));
        }

        [Given(@"I have a shopping list ""(.*)""")]
        public void GivenIHaveAShoppingList(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit the shopping list")]
        public void WhenIEditTheShoppingList()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter ""(.*)""")]
        public void WhenIEnter(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I accept the settings for the shopping list")]
        public void WhenIAcceptTheSettingsForTheShoppingList()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have the following shopping lists")]
        public void GivenIHaveTheFollowingShoppingLists(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have selected ""(.*)""")]
        public void GivenIHaveSelected(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I delete the shopping list")]
        public void WhenIDeleteTheShoppingList()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The shopping list ""(.*)"" is selected")]
        public void ThenTheShoppingListIsSelected(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
