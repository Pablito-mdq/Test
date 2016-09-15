using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.VisaCenter;
using SeleniumDemo.Utils;

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
                _file = "Resources\\" + client + "\\TestsData\\WS_1273.xml";
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
                var balance = visaPage.GetBalance();
                Assert.IsTrue(visaPage.IsAmountFieldAvl(),"Amount field is not available");
                visaPage.EnterAmount("100").ClickReloadCard();
                Assert.AreEqual(balance - 100,visaPage.GetBalance(),"Balance was not right decresing the amount");
            }
        }
    }
}
