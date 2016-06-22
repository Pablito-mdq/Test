using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Tests.Pages;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Tests.Pinnacol
{
    class PinnacolTest : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Regression")]
        [Category("Pinnacol")]
        //PIN_240
        [Test]
        public void WS_1096()
        {
            if (!DataParser.ReturnExecution("WS_1096"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1096.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file),
                approval_name = AwardData.GetApprovalUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePagePinnacola()
                    .EnterUserName(user);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in as:" + user, home.GetProxyLoginMsgPinnacol(),
                    "The message of proxy login is not correct");
                NominationHomePage recognitionPage = home.NavigateToNominationPinnacola()
                    .SearchEmployeeFound(proxy_name)
                    .SelectAward(award)
                    .FillReason(reason)
                    .FillMsg(msg)
                    .ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                home = recognitionPage.ExitProxy().ClosePopUp().NavigateToAdminHomePagePinnacola()
                    .EnterUserName(proxy_name).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in as:" + proxy_name, home.GetProxyLoginMsgPinnacol(),
                    "The message of proxy login is not correct");
                int point = home.ClosePopUp().GetAwardPoint();
                home.ExitProxy();
                home.Refresh();
                home = home.NavigateToAdminHomePagePinnacola().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                Assert.AreEqual("You are proxied in as:" + approval_name, home.GetProxyLoginMsgPinnacol(),
                    "The message of proxy login is not correct");
                PendingApprovals pending = home.ClickHereAwardPopUp();
                Assert.AreEqual("Pending Approvals", pending.GetTitleMenu(), "Title is not pending approval");
                pending.ApproveAward().ClickApprove();
                home.ExitProxy();
                home.Refresh();
                home = home.NavigateToAdminHomePagePinnacola().EnterUserName(proxy_name).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in as:" + proxy_name, home.GetProxyLoginMsgPinnacol(),
                    "The message of proxy login is not correct");
                 Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                int totalpoints = home.GetAwardPoint();
                home.ClickHereAwardPopUp();
                if (point + 100 != totalpoints)
                    Assert.Fail(totalpoints + "is not equal to " + point);
                else
                    Assert.True(1==1,totalpoints + "is equal to " + point);
            }
        }
    }
}
