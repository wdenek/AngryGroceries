using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Scopes
{
    public class ScopeObject<TPage>
    {
        private readonly IWebDriver _driver;
        private readonly TPage _page;

        public ScopeObject(IWebDriver driver, TPage page)
        {
            _driver = driver;
            _page = page;
        }

        protected IWebDriver Driver
        {
            get { return _driver; }
        }

        public TPage Then()
        {
            return _page;
        }
    }
}
