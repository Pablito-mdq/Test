using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;
using NUnit.Framework;
using SeleniumDemo.Pages.VisaCenter;

namespace SeleniumDemo.Tests.Quantum
{
    class QuantumTestCases : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Regression")]
        [Category("Quantum")]
        //WS_1273
        
        [Test]
        public void WS_1273()
        {
            if (!DataParser.ReturnExecution("WS_1273"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1273.xml";
                string proxy_name = ProxyData.GetProxyUserName(_file);
                 MainHomePage home = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageLi().ClickOptionProxy("Proxy")
                    .EnterUserNameProxySprint2(proxy_name).ClickProxyBtn();
                Thread.Sleep(1500);
                Assert.AreEqual("0.00", home.GetRewardsBalance(),
                    "The rewards balance is not 0");
                VisaCenterHomePage visaPage = home.NavigateToVisaCenter();
                Assert.IsTrue(visaPage.IsSubmitAClaimPresent(),"Option is not present");
                Assert.IsFalse(visaPage.IsReloadYourCardPresent(),"Reload your card option is present");
                Assert.IsFalse(visaPage.IsCheckVisaCardBalance(), "Check Visa Card Balance option is present");
            }
        }

        [Category("Regression")]
        [Category("Quantum")]
        //WS_1278

        [Test]
        public void WS_1279()
        {
            if (!DataParser.ReturnExecution("WS_1279"))
                Assert.Ignore();
            else
            {
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                Thread.Sleep(1500);
                Assert.LessOrEqual("25.00", home.GetRewardsBalance(),
                    "The rewards balance is less than $25");
                VisaCenterHomePage visaPage = home.NavigateToVisaCenter();
                Assert.IsFalse(visaPage.IsSubmitAClaimPresent(), "Option is not present");
                Assert.IsTrue(visaPage.IsReloadYourCardPresent(), "Reload your card option is present");
                Assert.IsTrue(visaPage.IsCheckVisaCardBalance(), "Check Visa Card Balance option is present");
            }
        }
    }
}
