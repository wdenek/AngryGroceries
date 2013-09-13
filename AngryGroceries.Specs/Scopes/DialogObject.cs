using AngryGroceries.Specs.Pages;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public abstract class DialogObject<TPage>: ScopeObject<TPage> where TPage: IPage
    {
        private readonly string _cssClass;

        protected DialogObject(IWebDriver driver, TPage page, string cssClass) : base(driver, page)
        {
            _cssClass = cssClass;
        }

        /// <summary>
        /// Accepts the settings in the dialog
        /// </summary>
        /// <returns></returns>
        public TPage Accept()
        {
            var acceptButton = RootElement.FindElement(By.CssSelector(".accept-button"));
            acceptButton.Click();

            return Then();
        }

        /// <summary>
        /// Gets the root element for the dialog.
        /// </summary>
        protected IWebElement RootElement
        {
            get { return Driver.FindElement(By.CssSelector(".modal-dialog." + _cssClass)); }
        }
    }
}