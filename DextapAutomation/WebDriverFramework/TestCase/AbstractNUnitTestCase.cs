using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverFramework.Factories;
using WebDriverFramework.PageObject;

namespace WebDriverFramework.TestCase
{
    [TestFixture]
    public abstract class AbstractNUnitTestCase<T> where T : AbstractWebPage
    {
        /// <summary>
        /// Instance that signals the starting point of a test.
        /// </summary>
        protected T InitialPage;
        internal DriverFactory factory = new DriverFactory();
        private static readonly object Padlock = new object();

        protected virtual void configureBrowser(BrowserType browser)
        {
            lock (Padlock)
            {
                IWebDriver driver = factory.getDriverFor(browser);
                InitialPage = (T)WebPage.WebPageActivator.Activate<T>(driver);
            }
        }
    }

    public abstract class AbstractAngularNUnitTestCase<T> : AbstractNUnitTestCase<T> where T : AbstractWebPage
    {
        private static readonly object Padlock = new object();
        protected override void configureBrowser(BrowserType browser)
        {
            lock (Padlock)
            {
                IWebDriver driver = factory.getDriverWithAngularSupportFor(browser);
                InitialPage = (T)WebPage.WebPageActivator.Activate<T>(driver);
            }
        }
    }
}
