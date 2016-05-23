using MbUnit.Framework;
using OpenQA.Selenium;
using WebDriverFramework.Factories;
using WebDriverFramework.PageObject;
using WebDriverFramework.WebPage;

namespace WebDriverFramework.TestCase
{
    [TestFixture]
    [Parallelizable(TestScope.Self)]
    public abstract class AbstractMBUnitTestCase<T> where T : AbstractWebPage
    {
        protected T InitialPage;
        internal DriverFactory factory = new DriverFactory();
        private static readonly object Padlock = new object();

        protected virtual void configureBrowser(BrowserType browser)
        {
            lock (Padlock)
            {
                IWebDriver driver = factory.getDriverFor(browser);
                InitialPage = (T)WebPageActivator.Activate<T>(driver);
            }
        }
    }

    [TestFixture]
    [Parallelizable(TestScope.Self)]
    public abstract class AbstractAngularMBUnitTestCase<T> : AbstractMBUnitTestCase<T> where T : AbstractWebPage
    {
        private static readonly object Padlock = new object();
        protected override void configureBrowser(BrowserType browser)
        {
            lock (Padlock)
            {
                IWebDriver driver = factory.getDriverWithAngularSupportFor(browser);
                InitialPage = (T)WebPageActivator.Activate<T>(driver);
            }
        }
    }
}
