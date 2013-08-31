using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Util
{
    /// <summary>
    /// Contains shared test state. Use this to store information during a test scenario
    /// that needs to be shared across steps in the same scenario
    /// </summary>
    public class BrowserScenario : IBrowserScenario
    {
        /// <summary>
        /// Initializes a new instance of the scenario state.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="baseUrl"></param>
        public BrowserScenario(IWebDriver driver, string baseUrl)
        {
            this.Driver = driver;
            this.Navigator = new Navigator(driver,baseUrl);
        }

        /// <summary>
        /// Gets or sets the web driver used for the test case.
        /// </summary>
        public IWebDriver Driver { get; private set; }

        /// <summary>
        /// Gets the navigator for getting around the application
        /// </summary>
        public Navigator Navigator { get; private set; }
    }
}
