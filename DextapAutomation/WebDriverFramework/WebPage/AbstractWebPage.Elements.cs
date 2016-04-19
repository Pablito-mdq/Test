using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Threading;

namespace WebDriverFramework.PageObject
{
    public abstract partial class AbstractWebPage
    {
        /// <summary>
        /// Searches and gets a web element from web page matching given locator.
        /// </summary>
        /// <param name="locator">Locator representing the desired element.</param>
        /// <returns>Instance of IWebElement, if found. Null otherwise.</returns>
        protected IWebElement FindElement(By locator)
        {
            return Synchronization.WaitForElementToBePresent(locator);
        }

        /// <summary>
        /// Searches and gets a web element from web page matching given locator, without waiting for its visibility
        /// or taking into account if it is enabled.
        /// </summary>
        /// <param name="locator">Locator representing the desired element.</param>
        /// <returns>Instance of IWebElement, if found. Null otherwise.</returns>
        protected IWebElement FindElementPresence(By locator)
        {
            return Synchronization.WaitForElementToBePresent(locator);
        }

        /// <summary>
        /// Searches and gets a list of web elements from web page matching given locator.
        /// </summary>
        /// <param name="locator">Locator representing the desired elements.</param>
        /// <returns>List of instances of IWebElements, if found. Empty list otherwise.</returns>
        protected ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return new ReadOnlyCollection<IWebElement>(Synchronization.WaitForElementsToBePresent(locator));
        }

        /// <summary>
        /// Highlights a given web element in the web page for a brief amount of time (100 ms).
        /// </summary>
        /// <param name="element">The web element to highlight</param>
        protected void HighlightElement(IWebElement element)
        {
            for (int i = 0; i < 4; i++)
            {
                RunScript("arguments[0].style.border='3px solid red'", new object[] { element });
                Thread.Sleep(250);
                RunScript("arguments[0].style.border=''", new object[] { element });
            }
        }


    }
}
