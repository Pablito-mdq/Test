using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using WebDriverFramework.WebDriver;

namespace WebDriverFramework.PageObject.Internals
{

    public class SynchronizationOperations
    {
        private IWebDriver WebDriver;
        private WebDriverWait wait;
        private readonly double timeOut = Config.getDriverImplicitWaitTime().TotalSeconds;

        public SynchronizationOperations(IWebDriver driver)
        {
            this.WebDriver = driver;
            this.wait = new WebDriverWait(GetPlainDriver(WebDriver), Config.getDriverImplicitWaitTime());
            wait.PollingInterval = TimeSpan.FromMilliseconds(350);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        private IWebDriver GetPlainDriver(IWebDriver driver)
        {
            if (driver.GetType().Equals(typeof(EventFiringWebDriver)))
            {
                return ((EventFiringWebDriver)driver).WrappedDriver;
            }
            else
            {
                return driver;
            }
        }

        // =============================================
        // BY LOCATOR SECTION
        // =============================================

        /// <summary>
        /// Causes WebDriver to wait for X amount of time (in seconds) on a user specified locator.
        /// X = Framework's configured Implicit Wait time (in seconds)
        /// "Presence" means Existance AND Visibility (also means element's height and width is greater than 0!)
        /// </summary>
        public IWebElement WaitForElementToBePresent(By locator)
        {
            try
            {
                return wait.Until<IWebElement>(Expectations.ElementIsClickable(locator));
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public IList<IWebElement> WaitForElementsToBePresent(By locator)
        {
            return wait.Until<IList<IWebElement>>(Expectations.VisibilityOfAllElements(locator));
        }

        public void WaitForElementNotToBePresent(By locator)
        {
            wait.Until<Boolean>(Expectations.NumberOfVisibleElementsIs(locator, 0));
        }

        public void WaitForElementsNotToBePresent(By locator)
        {
            wait.Until<Boolean>(Expectations.NumberOfVisibleElementsIs(locator, 0));
        }

        public void WaitForNumberOfElementsBy(By locator, int amount)
        {
            wait.Until<Boolean>(Expectations.NumberOfElementsIs(locator, amount));
        }

        // =============================================
        // WEB ELEMENT SECTION
        // =============================================

        /// <summary>
        /// Causes WebDriver to wait for X amount of time (in seconds) on a user specified IWebElement.
        /// X = Framework's configured Implicit Wait time (in seconds)
        /// "Presence" means Existance AND Visibility (also means element's height and width is greater than 0!)
        /// </summary>
        public void WaitForElementToBePresent(IWebElement element)
        {
            Func<IWebElement, Boolean> isPresent = delegate(IWebElement e) { return e != null && e.Displayed && e.Enabled; };
            new DefaultWait<IWebElement>(element).Until(isPresent);
        }

        /// <summary>
        /// Causes WebDriver to wait for X amount of time (in seconds) on a user specified IWebElement.
        /// X = Framework's configured Implicit Wait time (in seconds)
        /// </summary>
        public void WaitForElementNotToBePresent(IWebElement element)
        {
            Func<IWebElement, Boolean> isNotPresent = delegate(IWebElement e) { return e == null || !e.Displayed; };
            new DefaultWait<IWebElement>(element).Until(isNotPresent);
        }
    }
}
