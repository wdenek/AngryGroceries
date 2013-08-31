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
    /// Component used to navigate around the web application
    /// </summary>
    public class Navigator
    {
        private IWebDriver _driver;
        private Uri _baseUri;

        /// <summary>
        /// Intializes a new instance of <see cref="Navigator"/>
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="baseUrl"></param>
        public Navigator(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _baseUri = new Uri(PatchBaseUrl(baseUrl), UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// Navigates to a page using a relative URL
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public TPage NavigateUrl<TPage>(string relativeUrl) where TPage: IPage
        {
            // Use the web driver to navigate to the specified URL.
            _driver.Navigate().GoToUrl(new Uri(_baseUri, PatchRelativeUrl(relativeUrl)));

            return CurrentPage<TPage>();
        }

        /// <summary>
        /// Navigates to a page using a well known location in the app
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <param name="knownLocation"></param>
        /// <returns></returns>
        public TPage Navigate<TPage>(KnownLocations knownLocation) where TPage: IPage
        {
            // Translate the well known location to a relative URL and use that to navigate.
            return NavigateUrl<TPage>(KnownLocationAttribute.Parse(knownLocation));
        }

        /// <summary>
        /// Gets the instance of the current page.
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        public TPage CurrentPage<TPage>() where TPage : IPage
        {
            return (TPage)Activator.CreateInstance(typeof (TPage), new[] {_driver});
        }

        private string PatchRelativeUrl(string relativeUrl)
        {
            if (relativeUrl.StartsWith("./")) return relativeUrl;

            string result = relativeUrl;

            if (!result.StartsWith("/"))
            {
                result = "/" + result;
            }

            if (result.StartsWith("/"))
            {
                result = "." + result;
            }

            return result;
        }

        private string PatchBaseUrl(string baseUrl)
        {
            string result = baseUrl;

            if (!result.EndsWith("/"))
            {
                result += "/";
            }

            return result;
        }
    }
}
