using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.Textron
{
    class TextronTest : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Regression")]
        [Category("Textron")]
        //WS-917
        [Test]
        public void Login_LoginFormRouting_WS_1045_Textron()
        {
            if (!DataParser.ReturnExecution("WS_1045_Textron"))
                Assert.Ignore();
            else
            {
                LoginPage loginPage = InitialPage.Go().FailLogon();
                loginPage.ClickLogin();
                Assert.IsTrue(loginPage.WasFailLogin(),"You are login");
                loginPage.FailLogonTextron().ClickLoginTextron();
                Assert.AreEqual("Authentication Failed. Click Here to enable your new portal password.", loginPage.GetFailLoginMsgTextron(),
                    "The message is not the correct for fail login");
            }
        }

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
    }
}
