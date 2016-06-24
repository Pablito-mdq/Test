using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.EGroup
{
    class EGroupTestCases : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Regression")]
        [Category("EGroup")]
        //WS1110
        [Test]
        public void WS_1111()
        {
            if (!DataParser.ReturnExecution("WS_1111"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1111.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file), customerImpact = AwardData.GetAwardCustomerImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file),
                approval_name = AwardData.GetApprovalUserName(_file);
                Step2 step2 = InitialPage.Go().Logon().ClickLogin().NavigateToNominationPinnacola()
                    .SearchEmployeeFound(user)
                    .SelectAward(award);
                Assert.AreEqual("This award is worth $250.00", step2.GetValueAward(), "the message is not right");
                NominationHomePage recognitionPage = step2.SelectSameValues(customerImpact,1)
                    .FillMsg(msg)
                    .FillReason(reason)
                    .ClickNext();
                step2.SelectSameValues(bussinesImpact, 0).ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                MainHomePage home = recognitionPage.NavigateToAdminHomePageSpan().EnterUserName(proxy_name).ProxyToMainHomePage();
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                PendingApprovals change = home.ClickHereAwardPopUp();
                Assert.AreEqual("Pending Approvals", change.GetTitleMenu(), "Title is not pending approval");
                change.ApproveAward().ClickApprove();
                Assert.AreEqual("Pending Approvals", change.GetTitleMenu(), "Title is not pending approval");
                home = change.ExitProxyToMainPage().NavigateToAdminHomePageSpan().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.IsFalse(home.IsPopUpRecognitionShow(), "Pop up recognition is showing up");
            }
        }
    }
}
