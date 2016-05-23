using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Utils
{
    class SeleniumUtils
    {
        /// <summary>
        /// Waits for an element.
        /// If element is null, the iwebelement is search through the driver. 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="by"></param>
        /// <param name="timeout">Default timeout in seconds</param>
        public static void WaitForElementIsVisible(IWebDriver driver, By by, int timeout, IWebElement element = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until<IWebElement>(d =>
            {
                IWebElement e = element == null ? driver.FindElement(by) : element.FindElement(by);
                if (!e.Displayed || !e.Enabled)
                    throw new NoSuchElementException(by + "This element was not found yet");
                return e;

            });
        }

        public static void WaitForElementDissapear(IWebDriver driver, By by, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until<bool>(d =>
            {
                try
                {
                    IWebElement e = d.FindElement(by);
                    //if element is pressent but it is not displayed, return true to exit
                    return e.Displayed ? false : true;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }

            });
        }

        public static bool WaitForElementVisible(IWebDriver driver, IWebElement element)
        {
            WaitForElementExists(element);
            int i = 0;
            while (i < 15 && element.Displayed == false)
            {
                i++;
                Thread.Sleep(500);
            }

            return i == 15 ? false : true;
        }

        public static bool WaitForElementNotVisible(IWebDriver driver, IWebElement element)
        {
            WaitForElementExists(element);
            int i = 0;
            while (i < 15 && element.Displayed == true)
            {
                i++;
                Thread.Sleep(500);
            }

            return i == 15 ? false : true;
        }


        /// <summary>
        /// searches for elements matching 'by' until at least one is found
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static bool WaitForElementExists(IWebDriver driver, By by)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
            int i = 0;
            while (i < 15 && driver.FindElements(by).Count == 0)
            {
                i++;
                Thread.Sleep(500);
            }
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));

            return i == 15 ? false : true;
        }

        /// <summary>
        /// Waits for the element until it exists
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static bool WaitForElementExists(IWebElement element)
        {

            int i = 0;
            while (i < 15 && element == null)
            {
                i++;
                Thread.Sleep(500);
            }

            return i == 15 ? false : true;
        }

        /// <summary>
        /// Searches for elements matching 'by' until none is found
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static bool WaitForElementStopExisting(IWebDriver driver, By by)
        {
            int i = 0;
            while (i < 15 && driver.FindElements(by).Count != 0)
            {
                i++;
                Thread.Sleep(500);
            }

            return i == 15 ? false : true;
        }

        /// <summary>
        /// Waits for a the table to display a number of rows
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static bool WaitForTableRowsCount(IWebElement table, int rowCount)
        {
            bool flag = false;
            int i = 0;
            while (i < 15 && flag == false)
            {
                //Console.WriteLine("(Wait for table) row count " + table.FindElements(By.XPath(".//tr")).Count);
                if (table.FindElements(By.XPath(".//tr")).Count != rowCount)
                    Thread.Sleep(500);
                else
                    flag = true;
                i++;

            }

            if (i == 15 || flag == false)
                return false;
            else
                return true;
        }

        public static bool WaitForNumberOfElements(IWebDriver driver, By by, int count)
        {
            bool flag = false;
            int i = 0;
            while (i < 15 && flag == false)
            {
                if (driver.FindElements(by).Count != count)
                    Thread.Sleep(500);
                else
                    flag = true;
                i++;

            }

            if (i == 15 || flag == false)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Wait for an element to be displayed DUPLICATE OF WaitForElementVisible, USE THAT ONE INSTEAD
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool WaitForElement(IWebElement element)
        {
            int i = 0;
            while (i < 15 && !element.Displayed)
            {
                i++;
                Thread.Sleep(500);
            }
            return element.Displayed;
        }

        /// <summary>
        /// Wait for an element to be enabled
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool WaitForElementEnabled(IWebElement element)
        {
            int i = 0;
            while (i < 15 && !element.Enabled)
            {
                i++;
                Thread.Sleep(500);
            }
            return element.Enabled;
        }
    }
}
