using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AngryGroceries.Specs.Util
{
    public class JavaScriptErrorLogger
    {
        public static void Install(IWebDriver driver)
        {
            var runner = (IJavaScriptExecutor) driver;

            runner.ExecuteScript("window.errorlogger = window.errorlogger || {};");
            runner.ExecuteScript("window.onerror = function(errorMessage) { window.errorlogger.errors.push(errorMessage); };");
        }
    }
}
