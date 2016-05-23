﻿using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.Textron
{
    class TextronTest : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Smoke")]
        //WS-917
        [Test]
        public void Fail_Login_Textron()
        {
            if (!DataParser.ReturnExecution("Fail_Login_Textron"))
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

        [Category("Smoke")]
        [Category("Textron")]
        //WS-927
        [Test]
        public void Recognition_Standard_Approval_Monetary_Flow()
        {
            if (!DataParser.ReturnExecution("Recognition_Standard_Approval_Monetary_Flow"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\Recognition_Standard_Approval_Monetary_Flow.xml";
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


        [Category("Smoke")]
        [Category("Textron")]
        //WS-927
        [Test]
        public void TEXTRON_Recognition_Standard_Denial_Monetary_Flow()
        {
            if (!DataParser.ReturnExecution("TEXTRON_Recognition_Standard_Denial_Monetary_Flow"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\TEXTRON_Recognition_Standard_Denial_Monetary_Flow.xml";
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
                pending.ApproveAward().ClickApprove();
                proxy = pending.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(proxy_name).ProxyToMainHomePage();
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(secondAward, awards.GetAwardName(1, 6), "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 7);
            }
        }
    }
}
