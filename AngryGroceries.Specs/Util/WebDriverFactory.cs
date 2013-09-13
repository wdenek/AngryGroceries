using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace AngryGroceries.Specs.Util
{
    /// <summary>
    /// Produces drivers to use with the test cases in this project.
    /// </summary>
    public static class WebDriverFactory
    {
        /// <summary>
        /// Creates a new web driver for the test cases.
        /// </summary>
        /// <param name="browserType">Type of browser to use</param>
        /// <returns>Returns the new web driver for use with the testcases</returns>
        public static IWebDriver CreateDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver(InstallDriver("ChromeDriver.exe", Resources.chromedriver));
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                case BrowserType.InternetExplorer:
                    return new InternetExplorerDriver(InstallDriver("IEDriverServer.exe",Resources.IEDriverServer));
                case BrowserType.PhantomJs:
                    return new PhantomJSDriver(InstallDriver("phantomjs.exe", Resources.phantomjs));
                default: 
                    return null;
            }
        }

        /// <summary>
        /// Installs the necessary driver binary on disk
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="binary"></param>
        /// <returns></returns>
        private static string InstallDriver(string filename, byte[] binary)
        {
            // Create a folder for the driver to be installed.
            var tempFolder = Path.Combine(Path.GetTempPath(), "AngryGroceries.Specs");
            Directory.CreateDirectory(tempFolder);

            var filePath = Path.Combine(tempFolder, filename);
            if (!File.Exists(filePath))
            {
                File.WriteAllBytes(filePath, binary);
            }

            return tempFolder;
        }
    }
}
