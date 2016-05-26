using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.BAE
{


    
    class SampleTestSuite : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");
        
        [Category("Regression")]
        [Category("BAE" )]
        //WS-317
        [Test]
        public void BAE_Enhanced_Proxy()
        {
            if (!Utils.DataParser.ReturnExecution("Enhanced_Proxy"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\Enhanced_Proxy.xml";
                username = ProxyData.GetProxyUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
            }
        }
        
        [Category("Regression")]
        [Category("BAE")]
        //WS-917
        [Test]
        public void Validate_Login_BAE()
        {
            if (!Utils.DataParser.ReturnExecution("Validate_Login_BAE"))
                Assert.Ignore();
            else
            {
                LoginPage loginPage = InitialPage.Go();
                Assert.AreEqual("IMPACT ID", loginPage.GetUsernameTitle(), "title is not IMPACT ID");
                Assert.AreEqual("Password", loginPage.GetPasswordTitle(), "title is not Password");
                Assert.IsTrue(loginPage.IsUsernameFieldAvl(), "username field is not available");
                Assert.IsTrue(loginPage.IsPasswordFieldAvl(), "username field is not available");
            }

        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-921
        [Test]
        public void BAE_Recognition_Approval_Flow_Non_Monetary()
        {
            if (!Utils.DataParser.ReturnExecution("Recognition_Approval_Flow_Non_Monetary"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\Recognition_Approval_Flow_Non_Monetary.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    amount = AwardData.GetAwardAmountValue(_file),
                    impact = AwardData.GetAwardImpact(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file);
                ProxyHomePage proxyPage =  InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(proxy_name);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                NominationHomePage recognitionPage =home.NavigateToNomination();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .FillMsg(msg);
                if (reason!="")
                    recognitionPage.FillReason(reason);
                recognitionPage.ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", recognitionPage.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
                AdminHomePage proxy = recognitionPage.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(user).ProxyToMainHomePage();
                Assert.IsTrue(home.IsPopUpRecognitionShow(),"Pop up recognition is not showing up");
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(award,awards.GetAwardName(1,4),"The last award that someone gave you is not present");
                awards.OpenDetailsAward(1,7);
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-924
        [Test]
        public void BAE_Recognition_Approval_Flow_Monetary()
        {
            if (!DataParser.ReturnExecution("BAE_Recognition_Approval_Flow_Monetary"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\BAE_Recognition_Approval_Flow_Monetary.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    secondAward = AwardData.GetSecondAwardName(_file),
                    populationImpact = AwardData.GetAwardPopulationImpact(_file),
                    financialImpact = AwardData.GetAwardFinancialImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file);
                int amount = AwardData.GetAwardAmountValueNumbers(_file);
                    string printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file), reason = AwardData.GetAwardReason(_file),
                    companyValue = AwardData.GetAwardCompanyValue(_file),
                proxy_name = ProxyData.GetProxyUserName(_file),
                approval_name = AwardData.GetApprovalUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(proxy_name);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                NominationHomePage recognitionPage = home.NavigateToNomination()
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .EnterValueAmount(amount)
                    .FillReason(reason)
                    .ChkCompanyValues(companyValue)
                    .SelectValues(populationImpact)
                    .SelectValues(bussinesImpact)
                    .SelectValues(financialImpact)
                    .FillMsg(msg)
                    .ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                AdminHomePage proxy = recognitionPage.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + approval_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                PendingApprovals pending = home.ClickHereAwardPopUp();
                Assert.AreEqual("Pending Approvals", pending.GetTitleMenu(), "Title is not pending approval");
                pending.ApproveAward().ClickApprove();
                proxy = pending.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(user).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + user, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(secondAward, awards.GetAwardName(1, 4), "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 7);
            }
        }
    }
}