using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AngryGroceries.Specs.Pages
{
    public abstract class Page: IPage
    {
        private IWebDriver _driver;

        protected Page(IWebDriver driver)
        {
            _driver = driver;
        }

        protected IWebDriver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }
    }
}
