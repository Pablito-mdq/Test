using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverFramework.PageObject
{
    public abstract partial class AbstractWebPage
    {

        /// <summary>
        /// Selects all (Ctrl+a).
        /// </summary>
        protected void SelectAll()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Copies selected value (Ctrl+c)
        /// </summary>
        protected void Copy()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Pastes clipboard (Ctrl+v)
        /// </summary>
        protected void Paste()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Returns current page title.
        /// </summary>
        /// <returns>The web page title.</returns>

        public string GetTitle()
        {
            return WebDriver.Title;
        }

        /// <summary>
        /// Returns current page url.
        /// </summary>
        /// <returns>The current URL for web page.</returns>
        public string GetCurrentUrl()
        {
            return WebDriver.Url;
        }

        /// <summary>
        /// Returns current page source code.
        /// </summary>
        /// <returns>The source code for current web page.</returns>
        public string GetPageSource()
        {
            return WebDriver.PageSource;
        }
    }
}
