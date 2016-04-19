using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFramework.WebDriver
{
    class Expectations
    {

        /// <summary>
        /// An expectation with the logical opposite condition of the given condition.
        /// </summary>
        /// <param name="ExpectedCondition"></param>
        /// <returns></returns>
        public static Func<IWebElement, Boolean> Not(Func<IWebElement, Boolean> condition)
        {
            return element =>
                    {
                        var result = condition.Invoke(element);
                        return result == null || result == false;
                    };
        }

        /// <summary>
        /// An expectation for checking whether an element is invisible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and invisible.</returns>
        public static Func<IWebDriver, Boolean> InvisibilityOfElementLocated(By locator)
        {
            return driver =>
            {
                IWebElement element;
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    element = driver.FindElement(locator);
                    return element != null && !element.Displayed;
                }
                catch (NoSuchElementException nsee)
                {
                    return true;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitlyWait(Config.getDriverImplicitWaitTime());
                }
            };
        }

        /// <summary>
        /// An expectation for checking whether an element is disabled.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located, visible but disabled.</returns>
        public static Func<IWebDriver, Boolean> DisablenessOfElementLocated(By locator)
        {
            return driver =>
            {
                IWebElement element;
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    element = driver.FindElement(locator);
                    return element != null && element.Displayed && !element.Enabled;
                }
                catch (NoSuchElementException nsee)
                {
                    return false;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitlyWait(Config.getDriverImplicitWaitTime());
                }
            };
        }

        /// <summary>
        /// An expectation for checking whether an element is visible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located, visible and clickable.</returns>
        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                IWebElement element;
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    element = driver.FindElement(locator);
                    return element != null && element.Displayed && element.Enabled ? element : null;
                }
                catch (NoSuchElementException nsee)
                {
                    return null;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitlyWait(Config.getDriverImplicitWaitTime());
                }
            };
        }

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page.
        /// This does not necessarily mean that the element is visible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located, visible and clickable.</returns>
        public static Func<IWebDriver, IWebElement> PresenceOfElementLocated(By locator)
        {
            return driver =>
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    return driver.FindElement(locator);
                }
                catch (NoSuchElementException nsee)
                {
                    return null;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitlyWait(Config.getDriverImplicitWaitTime());
                }
            };
        }

        /// <summary>
        /// An expectation for checking if the given text is present in the specified element.
        /// </summary>
        /// <param name="element">The element on which we want to compare its text.</param>
        /// <param name="text">The text to be contained by the element.</param>
        /// <returns>True if text is contained within <see cref="IWebElement"/>'s text. False otherwise.</returns>
        public static Func<IWebDriver, Boolean> TextToBePresentInElement(IWebElement element, string text)
        {
            return driver =>
            {
                string elementText = element.Text;
                return elementText.Contains(text);
            };
        }

        /// <summary>
        /// An expectation for checking if the given text is present in the specified element.
        /// </summary>
        /// <param name="element">The element on which we want to compare its text.</param>
        /// <param name="text">The text to be contained by the element.</param>
        /// <returns>True if text is contained within <see cref="IWebElement"/>'s value attribute. False otherwise.</returns>
        public static Func<IWebDriver, Boolean> TextToBePresentInElementValue(IWebElement element, string text)
        {
            return driver =>
            {
                string elementText = element.GetAttribute("value");
                if (elementText != null)
                {
                    return elementText.Contains(text);
                }
                else
                {
                    return false;
                }
            };
        }

        /// <summary>
        /// An expectation for checking if the given attribute has the desired value.
        /// </summary>
        /// <param name="element">The element on which we want to compare its text.</param>
        /// <param name="attribute">The name of the attribute to compare against expected value.</param>
        /// <param name="text">The text to be contained by the attribute.</param>
        /// <returns>True if expectedValue is contained within <see cref="IWebElement"/>'s attribute. False otherwise.</returns>
        public static Func<IWebDriver, Boolean> AttributeValueToBePresentInElement(IWebElement element, string attribute, string expectedValue)
        {
            return driver =>
            {
                string elementAttr = element.GetAttribute(attribute);
                if (elementAttr != null)
                {
                    return elementAttr.Contains(expectedValue);
                }
                else
                {
                    return false;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that all elements present on the web page that
        /// match the locator are visible.
        /// </summary>
        /// <param name="locator">The locator used to find the elements.</param>
        /// <returns>The <see cref="IList<IWebElement>"/> once it is located, visible and clickable.</returns>
        public static Func<IWebDriver, IList<IWebElement>> VisibilityOfAllElements(By locator)
        {
            return driver =>
            {
                IList<IWebElement> elements;
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    elements = driver.FindElements(locator);
                    foreach (IWebElement element in elements)
                    {
                        if (!element.Displayed)
                        {
                            return null;
                        }
                    }
                    return elements;
                }
                catch (NoSuchElementException nsee)
                {
                    return null;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitlyWait(Config.getDriverImplicitWaitTime());
                }
            };
        }

        /// <summary>
        /// An expectation for checking that the amount of identified elements on the web page 
        /// match the expected number.
        /// </summary>
        /// <param name="locator">The locator used to find the elements.</param>
        /// <param name="amount">The number of desired elements that must match</param>
        /// <returns>The <see cref="IList<IWebElement>"/> once it is located, visible and clickable.</returns>
        public static Func<IWebDriver, Boolean> NumberOfElementsIs(By locator, int amount)
        {
            return driver =>
            {
                IList<IWebElement> elements;
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    elements = driver.FindElements(locator);
                    return elements.Count == amount;
                }
                catch (NoSuchElementException nsee)
                {
                    return 0 == amount;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitlyWait(Config.getDriverImplicitWaitTime());
                }                
            };
        }

        /// <summary>
        /// An expectation for checking that the amount of identified elements on the web page 
        /// match the expected number.
        /// </summary>
        /// <param name="locator">The locator used to find the elements.</param>
        /// <param name="amount">The number of desired elements that must match</param>
        /// <returns>The <see cref="IList<IWebElement>"/> once it is located, visible and clickable.</returns>
        public static Func<IWebDriver, Boolean> NumberOfVisibleElementsIs(By locator, int amount)
        {
            return driver =>
            {
                IList<IWebElement> elements;
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    elements = driver.FindElements(locator).Where(e => { return e.Displayed == true; }).ToList<IWebElement>();
                    return elements.Count == amount;
                }
                catch (NoSuchElementException nsee)
                {
                    return 0 == amount;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitlyWait(Config.getDriverImplicitWaitTime());
                }
            };
        }
    }
}
