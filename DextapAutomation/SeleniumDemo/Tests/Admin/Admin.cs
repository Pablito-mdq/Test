using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{
    class Admin : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();
        private static string url = ConfigUtil.ImportConfigURL(string.Format("Resources\\{0}\\Url.xml", client), client);


        [Category("Regression")]
        [Category("TRU")]
        [Test]
        //WS_1057
        public void WS_1057()
        {
            if (!DataParser.ReturnExecution("WS_1057"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1057.xml";
                string user = AwardData.GetAwardUserName(_file), msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file), value = AwardData.GetAwardValue(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNominationSpan();
                Thread.Sleep(1500);
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .FillMsg(msg)
                    .ClickNext()
                    .EmailReward();
                    Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                     "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognitionAward(), "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelXpath(),
                    "Button finish its not correct write");
                ReportsPage details = recognitionPage.NavigateToReportsSpan().NavigateToReports();
                Assert.AreEqual(award, details.GetAwardTable(1, 6), award + "award was not given");
                Assert.AreEqual(user, details.GetAwardTable(1,3), user + "user was not given or present");
                var proxypage =
                    details.NavigateToAdminHomePageSpan()
                        .ClickOptionProxy("Proxy")
                        .EnterUserName(user)
                        .ProxyToMainHomePage().ClosePopUp();
                Thread.Sleep(300);
                var myawards = proxypage.NavigateToMyAwards();
                Assert.AreEqual(award, myawards.GetAwardName(1, 5), award + "award was not given");
           }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1206
        [Test]
        public void Admin_NoPermissionNoAccess_WS_1206()
        {
            if (!DataParser.ReturnExecution("WS_1206"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1206.xml";
                string user = AwardData.GetAwardUserName(_file);
                MainHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxy("Proxy").EnterUserNameProxySprint2(user).ProxyToMainHomePageSprint().ClosePopUp();
                Assert.AreEqual("You are proxied in as:" + user, proxy.GetProxyLoginMsgSprint(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", proxy.GetExitMsg(), "The exit proxy link is not present");
                Assert.IsFalse(proxy.IsAdmLnkPresent(), "Admin link is present");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1206
        [Test]
        public void Admin_TestSupportPermissionAccess_WS_1204()
        {
            if (!DataParser.ReturnExecution("WS_1204"))
                Assert.Ignore();
            else
            {
                ProxyHomePage admin = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan();
                Assert.IsTrue(admin.IsBulkAwardOptPresent(), "Bulk Award Upload is not present");
                Assert.IsTrue(admin.IsProxyOptPresent(), "Proxy is not present");
                Assert.IsTrue(admin.IsBudgetToolOptPresent(), "Budget tool is not present");
                Assert.IsTrue(admin.IsPendingApprovalsOptPresent(), "Pending Approvals is not present");
                Assert.IsTrue(admin.IsEditRewardCartUserMessageOptPresent(),
                    "Edit Reward Cart User Message is not present");
                Assert.IsTrue(admin.IsProxyManagerOptPresent(), "Proxy Manager is not present");
                Assert.IsTrue(admin.IsDeletedUnusedAwardOptPresent(), "Deleted Unused Award is not present");
                Assert.IsTrue(admin.IsEditPendingAwardsOptPresent(), "Edit Pending Awards is not present");
                Assert.IsTrue(admin.IsDebugRuleOptPresent(), "Debug Rule is not present");
                Assert.IsTrue(admin.IsDebugReportOptPresent(), "Debug Report is not present");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1208
        [Test]
        public void Admin_LimitedPermissionAcess_WS_1208()
        {
            if (!DataParser.ReturnExecution("WS_1208"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1208.xml";
                string user = AwardData.GetAwardUserName(_file);
                MainHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxy("Proxy").EnterUserNameProxySprint2(user).ProxyToMainHomePageSprint().ClosePopUp();
                Assert.AreEqual("You are proxied in as:" + user, proxy.GetProxyLoginMsgSprint(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", proxy.GetExitMsg(), "The exit proxy link is not present");
                ProxyHomePage admin = proxy.NavigateToAdminHomePageSpan();
                Assert.IsTrue(admin.IsBulkAwardOptPresent(), "Bulk Award Upload is not present");
                Assert.IsTrue(admin.IsProxyOptPresent(), "Proxy is not present");
                Assert.IsTrue(admin.IsBudgetToolOptPresent(), "Budget tool is not present");
                Assert.IsTrue(admin.IsPendingApprovalsOptPresent(), "Pending Approvals is not present");
            }
        }


    }
}
