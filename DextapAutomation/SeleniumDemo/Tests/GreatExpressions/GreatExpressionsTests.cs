using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemo.Pages;
using SeleniumDemo.Utils;
using NUnit.Framework;

namespace SeleniumDemo.Tests.GreatExpressions
{
    class GreatExpressionsTests : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Regression")]
        [Category("GreatExpressions")]
        //WS-1132
        [Test]
        public void WS_1132()
        {
            if (!DataParser.ReturnExecution("WS_1132"))
                Assert.Ignore();
            else
            {
                LoginPage MainPage = InitialPage.Go().Logon();
                string originalURL = MainPage.GetCurrentUrl();
                LoginPage loginPage = MainPage.ClickLogin().ClickLogOut();
                string newURL = loginPage.GetCurrentUrl();
                Assert.AreNotEqual(originalURL, newURL, "The login page is not the same for SSO users");
            }
        }
    }
}
