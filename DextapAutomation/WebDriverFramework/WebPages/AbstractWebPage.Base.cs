using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace WebDriverFramework.PageObject
{
    public abstract partial class AbstractWebPage
    {
        /// <summary>
        /// The web driver
        /// </summary>
        private IWebDriver webDriver;

        /// <summary>
        /// Gets or sets the web driver.
        /// </summary>
        /// <value>The web driver.</value>
        private IWebDriver WebDriver
        {
            get { return webDriver; }
            set { webDriver = value; PageFactory.InitElements(value, this); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractWebPage"/> class.
        /// </summary>
        public AbstractWebPage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            this.Actions = new ActionOperations(WebDriver);
            this.LocatableActions = new LocatableOperations(WebDriver);

            try
            {
                // Wait for 1 second to allow alerts to pop up
                System.Threading.Thread.Sleep(1000);
                WebDriver.SwitchTo().Window(WebDriver.CurrentWindowHandle);
            }
            catch (UnhandledAlertException AlertException)
            {
                string message = AlertException.AlertText;
                try
                {
                    IAlert alert = webDriver.SwitchTo().Alert();
                    alert.Accept();
                    Console.WriteLine("Alert message dissmised! Text was: " + AlertException.AlertText);
                }
                catch (NoAlertPresentException NoAlertException)
                {
                    Console.WriteLine("Attempted to dismiss alert but was already dismissed!. Text was: " + message, NoAlertException);
                }
            }
        }

        protected T NewPage<T>() where T : AbstractWebPage
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { WebDriver });
        }

    }
}
