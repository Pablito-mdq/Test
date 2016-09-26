using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Utils;
using System.Windows.Forms;
using System.Threading;
using SeleniumDemo.Tests.Sprint;

namespace SeleniumDemo.Tests.Awards
{
    class Awards : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();
     

        [Category("Regression")]
        [Category("Pinnacol")]
        //PIN_240
        [Test]
        public void Awards_PointsDepositSuccessfull_WS_1096()
        {
            if (!DataParser.ReturnExecution("WS_1096"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1096.xml";
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
                NominationHomePage recognitionPage = home.NavigateToNominationSpan()
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

        [Category("Regression")]
        [Category("BAE")]
        //WS_1274
        [Test]
        public void Awards_ViewDetailsModal_WS_1274()
        {
            if (!DataParser.ReturnExecution("WS_1274"))
                Assert.Ignore();
            else
            {
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                string issuer = reportpage.GetAwardTable(1, 8),
                    award = reportpage.GetAwardTable(1, 4),
                    recipient = reportpage.GetAwardTable(1, 2),
                    awardTie = reportpage.GetAwardTable(1, 4),
                    teamName = reportpage.GetAwardTable(1, 6),
                    date = reportpage.GetAwardTable(1, 1),
                    amount = reportpage.GetAwardTable(1, 3);
                ReportDetailsPage detailsPage = reportpage.ClickViewDetails(1);
                Assert.AreEqual(issuer, detailsPage.GetIssuer(), "Issuer Value is not the same");
                Assert.AreEqual(award, detailsPage.GetAward(), "Issuer Value is not the same");
                Assert.AreEqual(recipient, detailsPage.GetRecipient(), "Issuer Value is not the same");
                Assert.AreEqual(awardTie, detailsPage.GetAwardTie(), "Issuer Value is not the same");
                Assert.AreEqual(teamName, detailsPage.GetteamName(), "Issuer Value is not the same");
                Assert.AreEqual(date, detailsPage.Getdate(), "Issuer Value is not the same");
                Assert.AreEqual(amount, detailsPage.GetAmount(), "Issuer Value is not the same");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        [Test]
        public void Awards_MultipleRecipients_WS_1438()
        {
            if (!DataParser.ReturnExecution("WS_1438"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1438.xml";
                string proxy_name = ProxyData.GetProxyUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(proxy_name);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                NominationHomePage nominationHome = home.NavigateToNomination().ClickMultipleRecipients();
                nominationHome.SearchEmployeeFoundMultiple("Brian Walters")
                    .SearchEmployeeFoundMultiple("Aaron Ashing")
                    .ClickNextGeneric();
                Assert.AreEqual("Rave", nominationHome.GetFirstAwardName(), "the only Award name is not Rave");
            }
        }

        [Category("Regression")]
        [Category("EGroup")]
        //WS1110
        [Test]
        public void Awards_RemoveFromOtherAppQueue_WS_1111()
        {
            if (!DataParser.ReturnExecution("WS_1111"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1111.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file), customerImpact = AwardData.GetAwardCustomerImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file),
                approval_name = AwardData.GetApprovalUserName(_file);
                Step2 step2 = InitialPage.Go().Logon().ClickLogin().NavigateToNominationSpan()
                    .SearchEmployeeFound(user)
                    .SelectAward(award);
                Assert.AreEqual("This award is worth $250.00", step2.GetValueAward(), "the message is not right");
                NominationHomePage recognitionPage = step2.SelectSameValues(customerImpact, 1)
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
                home = change.ExitProxyToMainPage().NavigateToAdminHomePageSpan().NavigateToAdminHomePageSpan().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.IsFalse(home.IsPopUpRecognitionShow(), "Pop up recognition is showing up");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1177
        [Test]
        public void SprintAwards_PostReleaseRegression_WS_1177()
        {
            if (!DataParser.ReturnExecution("WS_1177"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1177.xml";
                string user = AwardData.GetAwardUserName(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    subAward1 = AwardData.GetAwardSubType1(_file),
                    subAward2 = AwardData.GetAwardSubType2(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple(user)
                    .ClickNextStep2()
                    .SelectAwardMultiple(award, 0)
                    .SelectSubAwardTypeSprint(subAward1, subAward2)
                    .ClickNextFillCard()
                    .FillEditCardEditor(msg)
                    .ClickNextStep()
                    .ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognition(),
                    "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelSprint(),
                    "Button finish its not correct write");
            }
        }


        [Category("Regression")]
        [Category("Sprint")]

        //WS_1155
        [Test]
        public void Awards_BulkUploadTool_WS_1155()
        {
            if (!DataParser.ReturnExecution("WS_1155"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1155.xml";
                string path = GeneralData.path(_file);
                BulkAward bulk = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionBulk("Bulk Award Upload");
                bulk.UploadFile();
                foreach (char a in path)
                {
                    SendKeys.SendWait(a.ToString());
                    Thread.Sleep(30);
                }
                SendKeys.SendWait("{ENTER}");
                bulk.WaitForFileToUpload();
                Assert.IsTrue(bulk.WasFileSuccessfullyUpload(), "The file was not successfully upload");
            }
        }


    }
}
