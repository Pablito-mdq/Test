using NUnit.Framework;
using SeleniumDemo.Utils;
using WebDriverFramework;
using WebDriverFramework.PageObject;
using WebDriverFramework.TestCase;

namespace SeleniumDemo.Tests
{
    class WorkStrideBaseTest<T> : AbstractNUnitTestCase<T> where T : AbstractWebPage
    {
        
        [SetUp]
        public void setUpBrowser()
        {

            BrowserType b = ConfigUtil.ImportConfig("Resources\\Config.xml");
            base.configureBrowser(ConfigUtil.BROWSER) ;
        }

        [TearDown]
        public void cleanUp()
        {
            InitialPage.Dispose();
        }
    }
}
