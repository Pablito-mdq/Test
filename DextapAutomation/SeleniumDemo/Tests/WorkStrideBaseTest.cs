using NUnit.Framework;
using SeleniumDemo.Pages;
using WebDriverFramework;
using WebDriverFramework.PageObject;
using WebDriverFramework.TestCase;

namespace SeleniumDemo.Tests
{
    class DextapBaseTest<T> : AbstractNUnitTestCase<T> where T : AbstractWebPage
    {

        [SetUp]
        public void setUpBrowser()
        {
            base.configureBrowser(BrowserType.Chrome);
        }

        [TearDown]
        public void cleanUp()
        {
            InitialPage.Dispose();
        }
    }
}
