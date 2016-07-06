using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemo.Pages;
using SeleniumDemo.Utils;
using NUnit.Framework;

namespace SeleniumDemo.Tests.WellCare
{
    class WellCareTestCases : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Regression")]
        [Category("BAE")]
        [Category("Textron")]
        [Category("WellCare")]
        [Category("Sprint")]
        [Category("HealthAlliance")]
        //WS-1132
        [Test]
        public void WS_1142()
        {
            if (!DataParser.ReturnExecution("WS_1142"))
                Assert.Ignore();
            else
            {
                LoginPage mainPage = InitialPage.Go();
                Assert.IsTrue(mainPage.IshomePageLoadingRightImg("landingPageGrid1.jpg"),"The background img is not landingPage1.jpg");
                Assert.IsTrue(mainPage.ImgVisible(), "Img does not load correctly");
            }
        }
    }
}
