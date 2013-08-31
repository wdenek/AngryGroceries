using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AngryGroceries.Specs.Util
{
    /// <summary>
    /// Extension methods related to waiting for specific elements to appear on the page or other wait conditions
    /// </summary>
    public static class WaitExtensions
    {
        /// <summary>
        /// Extension to let the driver wait until a specific result is reached.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="driver"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult WaitFor<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> func)
        {
            try
            {
                var wait = new WebDriverWait(driver,TimeSpan.FromSeconds(3));

                // Wait for the jQuery script actions to complete.
                //TODO: Enable this when we have jQuery stuff that needs waiting for.
                //wait.Until(drv => 0 == (long) ((IJavaScriptExecutor) drv).ExecuteScript("jQuery.active == 0"));

                return wait.Until(func);
            }
            catch (WebDriverTimeoutException)
            {
                // Return a null reference when the timeout elapsed.
                return default(TResult);
            }
        }
    }
}
