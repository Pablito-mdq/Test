using MbUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WebDriverFramework.Factories;
using WebDriverFramework.PageObject;

namespace WebDriverFramework.Test
{
    [TestFixture]
    [Parallelizable(TestScope.Self)]
    public abstract class AbstractWebTestCase<T> where T : AbstractWebPage
    {
        protected T StartPage;
        protected DriverFactory factory = new DriverFactory();
        private static readonly object Padlock = new object();

        public virtual void configureBrowser(BrowserType browser)
        {
            lock (Padlock)
            {
                IWebDriver driver = factory.getDriverFor(browser);
                StartPage = (T)Activator.CreateInstance(typeof(T), new object[] { driver });
            }
        }
    }

    public abstract class AbstractAngularWebTestCase<T> : AbstractWebTestCase<T> where T : AbstractWebPage
    {
        private static readonly object Padlock = new object();
        public override void configureBrowser(BrowserType browser)
        {
            lock (Padlock)
            {
                IWebDriver driver = factory.getDriverWithAngularSupportFor(browser);
                StartPage = (T)Activator.CreateInstance(typeof(T), new object[] { driver });
            }
        }
    }
}
