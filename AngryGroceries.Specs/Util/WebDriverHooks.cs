using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngryGroceries.Specs.Pages;
using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AngryGroceries.Specs.Util
{
    /// <summary>
    /// Provides bindings for hooking up the webdriver to the test code.
    /// </summary>
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer _container;
        private static IWebDriver _driver;

        /// <summary>
        /// Initializes a new instance of <see cref="WebDriverHooks"/>
        /// </summary>
        /// <param name="container">Container to use in the test</param>
        public WebDriverHooks(IObjectContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Starts the web driver when a feature needs to be tested.
        /// </summary>
        [BeforeFeature]
        public static void BeforeFeature()
        {
            //TODO: Make this configurable
            _driver = WebDriverFactory.CreateDriver(BrowserType.Chrome);
        }

        /// <summary>
        /// Cleans up the web driver after a feature has been completed.
        /// </summary>
        [AfterFeature()]
        public static void AfterFeature()
        {
            _driver.Close();
        }

        /// <summary>
        /// Initializes a new browser scenario when a specflow scenario is about to be run.
        /// Ensures that the homepage is loaded and that the bindings can access the browser scenario.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Start a new browser scenario.
            var scenario = new BrowserScenario(_driver, "http://localhost:50249/");

            // Always start at the homepage
            scenario.Navigator.Navigate<ShoppingListPage>(KnownLocations.Homepage);

            // Store the scenario instance in the object container.
            // Every binding that requests IBrowserScenario in the constructor gets this instance.
            _container.RegisterInstanceAs(scenario,typeof(IBrowserScenario));
        }

        /// <summary>
        /// Cleans up at the end of a specflow scenario.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            
        }
    }
}
