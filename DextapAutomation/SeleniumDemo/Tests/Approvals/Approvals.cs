using NUnit.Framework;
using System.Threading;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{
    class Approvals : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();

     
        [Category("Regression")]
        [Category("Textron")]
        //WS-927
        [Test]
        public void Approval_StandardMonAppvTextron_WS_927()
        {
            if (!DataParser.ReturnExecution("WS_927"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_927.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file), secondAward = AwardData.GetSecondAwardName(_file),
                    populationImpact = AwardData.GetAwardPopulationImpact(_file),
                    financialImpact = AwardData.GetAwardFinancialImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file),
                    amount = AwardData.GetAwardAmountValue(_file),objetives = AwardData.GetAwardObjetives(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file), projectTask = AwardData.GetAwardProjectTask(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file),
                approval_name = AwardData.GetApprovalUserName(_file);
                ProxyHomePage proxyPage =  InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(user);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + user, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Step2 step2 = home.NavigateToNomination()
                    .SearchEmployeeFound(proxy_name)
                    .SelectAward(award)
                    .SelectValues(populationImpact)
                    .SelectValues(financialImpact)
                    .SelectValues(bussinesImpact)
                    .ClickNextSameStep();
                 Assert.AreEqual("Appreciation Award",step2.GetAwardName("Appreciation Award"),"Award is not the same as expected");
                Assert.AreEqual("Honors Award",step2.GetAwardName("Honors Award"),"Award is not the same as expected");
                Assert.AreEqual("Excellence Award",step2.GetAwardName("Excellence Award"),"Award is not the same as expected");
                Assert.AreEqual("Distinction Award",step2.GetAwardName("Distinction Award"),"Award is not the same as expected");
                NominationHomePage recognitionPage = step2.SelectSecondAward(secondAward).SelectValueOfAward(amount)
                    .SelectProjectTask(projectTask)
                    .CheckProjectApproval()
                    .SelectValues(objetives)
                    .FillMsg(msg)
                    .FillReason(reason)
                    .ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                AdminHomePage proxy = recognitionPage.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.IsTrue(home.IsPopUpRecognitionShow(),"Pop up recognition is not showing up");
                PendingApprovals pending = home.ClickHereAwardPopUp();
                Assert.AreEqual("Pending Approvals",pending.GetTitleMenu(),"Title is not pending approval");
                pending.ApproveAward().ClickApprove();
                proxy = pending.ExitProxy();
                 home = proxy.LoginProxyAsuser().EnterUserName(proxy_name).ProxyToMainHomePage();
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(secondAward,awards.GetAwardName(1,6),"The last award that someone gave you is not present");
                awards.OpenDetailsAward(1,7);
            }
        }


        [Category("Regression")]
        [Category("Textron")]
        
        [Test]
        public void Approvals_StandardDenialTextron_WS_933()
        {
            if (!DataParser.ReturnExecution("WS_933"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_933.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file), secondAward = AwardData.GetSecondAwardName(_file),
                    populationImpact = AwardData.GetAwardPopulationImpact(_file),
                    financialImpact = AwardData.GetAwardFinancialImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file),
                    amount = AwardData.GetAwardAmountValue(_file), objetives = AwardData.GetAwardObjetives(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file), projectTask = AwardData.GetAwardProjectTask(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file),
                approval_name = AwardData.GetApprovalUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(user);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + user, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Step2 step2 = home.NavigateToNomination()
                    .SearchEmployeeFound(proxy_name)
                    .SelectAward(award)
                    .SelectValues(populationImpact)
                    .SelectValues(financialImpact)
                    .SelectValues(bussinesImpact)
                    .ClickNextSameStep();
                Assert.AreEqual("Appreciation Award", step2.GetAwardName("Appreciation Award"), "Award is not the same as expected");
                Assert.AreEqual("Honors Award", step2.GetAwardName("Honors Award"), "Award is not the same as expected");
                Assert.AreEqual("Excellence Award", step2.GetAwardName("Excellence Award"), "Award is not the same as expected");
                Assert.AreEqual("Distinction Award", step2.GetAwardName("Distinction Award"), "Award is not the same as expected");
                NominationHomePage recognitionPage = step2.SelectSecondAward(secondAward).SelectValueOfAward(amount)
                    .SelectProjectTask(projectTask)
                    .CheckProjectApproval()
                    .SelectValues(objetives)
                    .FillMsg(msg)
                    .FillReason(reason)
                    .ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                AdminHomePage proxy = recognitionPage.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                PendingApprovals pending = home.ClickHereAwardPopUp();
                Assert.AreEqual("Pending Approvals", pending.GetTitleMenu(), "Title is not pending approval");
                pending.DeclineAward().ClickDeclined();
                proxy = pending.ExitProxy();
                AllAwards allAwardsPage = proxy.NavigateToReports().clickAllAwards();
                Assert.AreEqual(secondAward, allAwardsPage.GetAwardName(1, 5), "Award is not the expected");
                Assert.AreEqual("Denied", allAwardsPage.GetStatus(1, 6), "Award was not Denied");
            }
        }

        [Category("Regression")]
        [Category("Textron")]
        
        [Test]
        public void Approvals_ChangingNomdurAppWS_951()
        {
            if (!DataParser.ReturnExecution("WS_951"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_951.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file), secondAward = AwardData.GetSecondAwardName(_file),
                    populationImpact = AwardData.GetAwardPopulationImpact(_file),
                    financialImpact = AwardData.GetAwardFinancialImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file),
                    amount = AwardData.GetAwardAmountValue(_file), objetives = AwardData.GetAwardObjetives(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file), projectTask = AwardData.GetAwardProjectTask(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file),
                approval_name = AwardData.GetApprovalUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(user);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + user, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Step2 step2 = home.NavigateToNomination()
                    .SearchEmployeeFound(proxy_name)
                    .SelectAward(award)
                    .SelectValues(populationImpact)
                    .SelectValues(financialImpact)
                    .SelectValues(bussinesImpact)
                    .ClickNextSameStep();
                Assert.AreEqual("Appreciation Award", step2.GetAwardName("Appreciation Award"), "Award is not the same as expected");
                Assert.AreEqual("Honors Award", step2.GetAwardName("Honors Award"), "Award is not the same as expected");
                Assert.AreEqual("Excellence Award", step2.GetAwardName("Excellence Award"), "Award is not the same as expected");
                Assert.AreEqual("Distinction Award", step2.GetAwardName("Distinction Award"), "Award is not the same as expected");
                NominationHomePage recognitionPage = step2.SelectSecondAward(secondAward).SelectValueOfAward(amount)
                    .SelectProjectTask(projectTask)
                    .CheckProjectApproval()
                    .SelectValues(objetives)
                    .FillMsg(msg)
                    .FillReason(reason)
                    .ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                AdminHomePage proxy = recognitionPage.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                PendingApprovals change = home.ClickHereAwardPopUp();
                Assert.AreEqual("Pending Approvals", change.GetTitleMenu(), "Title is not pending approval");
                change.ChangeAward().ChangeValue().ClickUpgrade();
                Assert.AreEqual("Pending Approvals", change.GetTitleMenu(), "Title is not pending approval");
            }
        }



        [Category("Regression")]
        [Category("Sprint")]
        //WS_1130
        [Test]
        public void Approval_BulkApprovalToolDeny_WS_1135()
        {
            if (!DataParser.ReturnExecution("WS_1135"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1135.xml";
                string user = AwardData.GetAwardUserName(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    begindate = AwardData.GetAwardBeginDate(_file),
                    endate = AwardData.GetAwardEndDate(_file),
                    description = AwardData.GetAwardDescription(_file),
                    Criteria = AwardData.GetAwardCriteria(_file),
                    subCriteria = AwardData.GetSubCriteria(_file),
                    value = AwardData.GetAwardAmountValue(_file),
                    ccEmail = AwardData.GetAwardCCEmail(_file),
                    proxyname = AwardData.GetApprovalUserName(_file);
                MainHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxy("Proxy").EnterUserNameProxySprint2(user).ProxyToMainHomePageSprint().ClosePopUp();
                NominationHomePage recognitionPage = proxy.NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple("Brenda Michel")
                    .SearchEmployeeFoundMultiple("Adri Johnson")
                    .SearchEmployeeFoundMultiple("Ada Pitocco")
                    .SearchEmployeeFoundMultiple("Alex Alvarado")
                    .ClickNextStep2()
                    .SelectAwardMultiple(award, 2)
                    .SelectValueOfAwardSprint(value)
                    .EnterBeginDate(begindate)
                    .EnterEndDate(endate)
                    .SelectValues(Criteria)
                    .SelectValues(subCriteria)
                    .FillDescription(description)
                    .FillMsg(msg)
                    .ClickNextSprint()
                    .EnterUserCCEmail(ccEmail).ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognition(),
                    "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelSprint(),
                    "Button finish its not correct write");
                recognitionPage.ExitProxy2();
                Thread.Sleep(1000);
                proxy =
                    proxy.NavigateToAdminHomePageSpan()
                        .ClickOptionProxy("Proxy")
                        .EnterUserNameProxySprint2(proxyname)
                        .ProxyToMainHomePageSprint()
                        .ClosePopUp();
                var pending = proxy.NavigateToPendingApprovals();
                Assert.AreEqual(user, pending.GetFirstUserApproval(), user + " is not present");
                var popUp = pending.ClickThumpsDown();
                Assert.IsTrue(popUp.IsPopUpPresent(), "Pop Up To Approve or Decline was not present");
                popUp.ApproveAllorDeclineAll();
                Assert.AreEqual("Successfully declined!", popUp.GetSuccesfullMsg(), "Successfull message is not present");
                popUp.ClickClose();
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1130
        [Test]
        public void Approval_BulkApprovalToolApprove_WS_1130()
        {
            if (!DataParser.ReturnExecution("WS_1130"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1130.xml";
                string user = AwardData.GetAwardUserName(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    begindate = AwardData.GetAwardBeginDate(_file),
                    endate = AwardData.GetAwardEndDate(_file),
                    description = AwardData.GetAwardDescription(_file),
                    Criteria = AwardData.GetAwardCriteria(_file),
                    subCriteria = AwardData.GetSubCriteria(_file),
                    value = AwardData.GetAwardAmountValue(_file),
                    ccEmail = AwardData.GetAwardCCEmail(_file),
                    proxyname = AwardData.GetApprovalUserName(_file);
                MainHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxy("Proxy").EnterUserNameProxySprint2(user).ProxyToMainHomePageSprint().ClosePopUp();
                NominationHomePage recognitionPage = proxy.NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple("Brenda Michel")
                    .SearchEmployeeFoundMultiple("Adri Johnson")
                    .SearchEmployeeFoundMultiple("Ada Pitocco")
                    .SearchEmployeeFoundMultiple("Alex Alvarado")
                    .ClickNextStep2()
                    .SelectAwardMultiple(award, 2)
                    .SelectValueOfAwardSprint(value)
                    .EnterBeginDate(begindate)
                    .EnterEndDate(endate)
                    .SelectValues(Criteria)
                    .SelectValues(subCriteria)
                    .FillDescription(description)
                    .FillMsg(msg)
                    .ClickNextSprint()
                    .EnterUserCCEmail(ccEmail).ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognition(),
                    "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelSprint(),
                    "Button finish its not correct write");
                recognitionPage.ExitProxy2();
                Thread.Sleep(1000);
                proxy =
                    proxy.NavigateToAdminHomePageSpan()
                        .ClickOptionProxy("Proxy")
                        .EnterUserNameProxySprint2(proxyname)
                        .ProxyToMainHomePageSprint()
                        .ClosePopUp();
                var pending = proxy.NavigateToPendingApprovals();
                Assert.AreEqual(user, pending.GetFirstUserApproval(), user + " is not present");
                var popUp = pending.ClickThumpsUp();
                Assert.IsTrue(popUp.IsPopUpPresent(), "Pop Up To Approve or Decline was not present");
                popUp.ApproveAllorDeclineAll();
                Assert.AreEqual("Successfully approved!", popUp.GetSuccesfullMsg(), "Successfull message is not present");
                popUp.ClickClose();
            }
        }

        [Category("Regression")]
        [Category("Sungard")]
        //WS-1354
        [Test]
        public void Angular_ApprovalPage_WS_1354()
        {
            if (!DataParser.ReturnExecution("WS_1354"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1354.xml";
                string proxy_name = ProxyData.GetProxyUserName(_file),
                    url = GeneralData.GetUrl(_file);
                MainHomePage home = InitialPage.GoSpecial(_file).Logon().ClickLogin().NavigateToAdminHomePageSpan().ClickOptionProxy("Proxy")
                    .EnterUserNameProxySprint2(proxy_name).ClickProxyBtn().ClosePopUp();
                Assert.AreEqual("http://qaastar-sungardas.workstride.net/ng#/approval", home.GetPendingApprovalsUrl(), "url is not http://qaastar-sungardas.workstride.net/ng#/approval");
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                PendingApprovals admin = home.NavigateToAdminHomePageSpan().ClickOptionPendingApprovals();
                Assert.AreEqual("http://qaastar-sungardas.workstride.net/ng#/approval", admin.GetPendingApprovalsUrl(), "url is not http://qaastar-sungardas.workstride.net/ng#/approval");
            }
        }


    }
}
