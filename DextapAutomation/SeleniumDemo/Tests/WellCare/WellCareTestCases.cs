using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;

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

        [Category("HealthAlliance")]
        //WS-1196
        [Test]
        public void WS_1196()
        {
            if (!DataParser.ReturnExecution("WS_1196"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1196.xml";
                string user = AwardData.GetAwardUserName(_file), msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file), value = AwardData.GetAwardValue(_file), amountvalue= AwardData.GetAwardAmountValue(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file), proxy_name2 = ProxyData.GetProxySecondUserName(_file);
                MainHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage().LoginProxyAsuser().EnterUserNameHealthAlliance(proxy_name).ProxyToMainHomePage();
                NominationHomePage recognitionPage = proxyPage.NavigateToHomePage().NavigateToNomination();
                Thread.Sleep(1500);
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValueOfAward(amountvalue)
                    .SelectValues(value)
                    .FillMsg(msg)
                    .ClickNext()
                    .EmailReward();
                recognitionPage.ClickSendRecognition();
                var proxypage = recognitionPage.ExitProxy().NavigateToAdminHomePage().LoginProxyAsuser().EnterUserNameHealthAlliance(proxy_name2)
                        .ProxyToMainHomePage().ClosePopUp();
                Thread.Sleep(300);
                var amount = proxypage.GetBudget();
                //Fail cannot appear link to switch to see the budget
                PendingApprovals pending = proxypage.NavigateToPendingApprovals();
                Thread.Sleep(300);
            }
        }

        [Category("WellCare")]
        //WS-1325
        [Test]
        public void WS_1325()
        {
            if (!DataParser.ReturnExecution("WS_1325"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1325.xml";
                string msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    send_type = AwardData.GetAwardDeliverType(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file);
                MainHomePage proxyPage =InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().ClickOptionProxy("Proxy")
                        .EnterUserNameProxySprint2(proxy_name).ProxyToMainHomePageSprint().ClosePopUp();
                Assert.AreEqual("You are proxied in as:" + proxy_name, proxyPage.GetProxyLoginMsgSprint(),
                   "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", proxyPage.GetExitMsg(), "The exit proxy link is not present");
                Step2 step2 = proxyPage.NavigateToEventCalendar().clickSendAniversaryCard();
                var recognitionPage = step2.SelectAward(award).FillMsg(msg).DeliverType(send_type);
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
            }
        }
    }
}
