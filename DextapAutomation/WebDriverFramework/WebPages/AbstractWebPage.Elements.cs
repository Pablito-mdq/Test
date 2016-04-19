using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace WebDriverFramework.PageObject
{
    public abstract partial class AbstractWebPage
    {

        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>IWebElement.</returns>
        protected IWebElement FindElement(By locator)
        {
            IWebElement element = null;
            try
            {
                element = WebDriver.FindElement(locator);
            }
            catch (NoSuchElementException nsee)
            {
                throw new WebDriverException("No element named \"" + locator.ToString() + "\" have been found in page. You should check the accessor.", nsee);
            }

            return element;
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>List of IWebElement.</returns>
        protected ReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            ReadOnlyCollection<IWebElement> elements = null;
            try
            {
                elements = WebDriver.FindElements(locator);
            }
            catch (NoSuchElementException nsee)
            {
                throw new WebDriverException("No elements named \"" + locator.ToString() + "\" have been found in page. You should check the accessor.", nsee);
            }

            return elements;
        }

        protected void HighlightElement(IWebElement element)
        {
            for (int i = 0; i < 2; i++)
            {
                RunScript("arguments[0].style.border='3px solid red'", new object[] { element });
                System.Threading.Thread.Sleep(100);
                RunScript("arguments[0].style.border=''", new object[] { element });
            }
        }


    }
}
