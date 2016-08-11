using System;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.LeftMenu.MyRedemption;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.SunGard
{
    internal class SungardTests : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");
        private static string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml", "Sungard");


        [Category("Regression")]
        [Category("Sungard")]
        //WS-917
        [Test]
        public void WS_1044()
        {
            if (!DataParser.ReturnExecution("WS_1044"))
                Assert.Ignore();
            else
            {
                LoginPage loginPage = InitialPage.Go();
                Assert.AreEqual("Email Address", loginPage.GetUsernameTitleGeneric(), "title is not Email Address");
                Assert.AreEqual("Password", loginPage.GetPasswordTitleGeneric(), "title is not Password");
                Assert.IsTrue(loginPage.IsUsernameFieldAvl(), "username field is not available");
                Assert.IsTrue(loginPage.IsPasswordFieldAvl(), "password field is not available");
                loginPage.EnterId(client).Logon();
                MainHomePage myJobs = loginPage.ClickLogin();
                Assert.IsTrue(loginPage.Imlogin(), "You are not login");
            }
        }

        [Category("Regression")]
        [Category("Sungard")]
        //WS-927
        [Test]
        public void WS_927()
        {
            if (!DataParser.ReturnExecution("WS_927"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_927.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    secondAward = AwardData.GetSecondAwardName(_file),
                    populationImpact = AwardData.GetAwardPopulationImpact(_file),
                    financialImpact = AwardData.GetAwardFinancialImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file),
                    amount = AwardData.GetAwardAmountValue(_file),
                    objetives = AwardData.GetAwardObjetives(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    projectTask = AwardData.GetAwardProjectTask(_file),
                    reason = AwardData.GetAwardReason(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file),
                    approval_name = AwardData.GetApprovalUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(user);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + user, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Step2 step2 = home.NavigateToNominationSpan()
                    .SearchEmployeeFound(proxy_name)
                    .SelectAward(award)
                    .SelectValues(populationImpact)
                    .SelectValues(financialImpact)
                    .SelectValues(bussinesImpact)
                    .ClickNextSameStep();
                Assert.AreEqual("Appreciation Award", step2.GetAwardName("Appreciation Award"),
                    "Award is not the same as expected");
                Assert.AreEqual("Honors Award", step2.GetAwardName("Honors Award"), "Award is not the same as expected");
                Assert.AreEqual("Excellence Award", step2.GetAwardName("Excellence Award"),
                    "Award is not the same as expected");
                Assert.AreEqual("Distinction Award", step2.GetAwardName("Distinction Award"),
                    "Award is not the same as expected");
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
                Assert.AreEqual(secondAward, awards.GetAwardName(1, 6),
                    "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 7);
            }
        }

        [Category("Regression")]
        [Category("Sungard")]

        [Test]
        public void WS_1161()
        {
            if (!DataParser.ReturnExecution("WS_1161"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1161.xml";
                string user = AwardData.GetAwardUserName(_file),
                    user1 = AwardData.GetAwardUserName1(_file)
                    ,
                    user2 = AwardData.GetAwardUserName2(_file),
                    user3 = AwardData.GetAwardUserName3(_file),
                    user4 = AwardData.GetAwardUserName4(_file),
                    user5 = AwardData.GetAwardUserName5(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file);

                //Scenario 1
                NominationHomePage recognitionPage =
                    InitialPage.Go().EnterId(client).EnterId(client).Logon().ClickLogin().NavigateToNominationSpan();
                recognitionPage.ClickMultipleRecipients()
                    .SearchEmployeeFoundMultiple(user)
                    .SearchEmployeeFoundMultiple(user1)
                    .SearchEmployeeFoundMultiple(user2).SearchEmployeeFoundMultiple(user3).ClickNextGeneric();
                Assert.IsTrue(recognitionPage.IsStep2Block(), "Step2 is not blocked");

                //Scenario 2
                MainHomePage mainPage =
                    recognitionPage.NavigateToAdminHomePage()
                        .LoginProxyAsuser()
                        .EnterUserName(proxy_name)
                        .ProxyToMainHomePage();
                Step2 ste2 = mainPage.NavigateToNominationSpan().SearchEmployeeFound(user4);
                Assert.AreEqual("Rave", ste2.GetAwardName("Rave"), "Rave Award is not present");
                Assert.AreEqual("Pioneer Award", ste2.GetAwardName("Pioneer Award"), "Pioneer Award is not present");
                Assert.AreEqual("Pathfinder Award", ste2.GetAwardName("Pathfinder Award"),
                    "Pathfinder Award is not present");
                Assert.AreEqual("Trailblazer Award", ste2.GetAwardName("Trailblazer Award"),
                    "Trailblazer Award is not present");

                //Scenario 3
                ste2.Refresh();
                ste2 = recognitionPage.SearchEmployeeFound(user5);
                Assert.AreEqual("Rave", ste2.GetAwardName("Rave"), "Rave Award is not present");
                Assert.IsFalse(ste2.IsAwardPresent("Pioneer Award"), "Pioneer Award is  present");
                Assert.IsFalse(ste2.IsAwardPresent("Pathfinder Award"), "Pathfinder Award not present");
                Assert.IsFalse(ste2.IsAwardPresent("Trailblazer Award"), "Trailblazer Award not present");
            }
        }

        [Category("Regression")]
        [Category("Sungard")]
        //WS-1201
        [Test]
        public void WS_1198()
        {
            if (!DataParser.ReturnExecution("WS_1198"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1198.xml";
                string company = RedeemData.GetRedeemCompany(_file),
                    firstname = RedeemData.GetRedeemFirstName(_file),
                    secondname = RedeemData.GetRedeemSecondName(_file),
                    address = RedeemData.GetRedeemAddress(_file),
                    city = RedeemData.GetRedeemCity(_file),
                    zip = RedeemData.GetRedeemZip(_file),
                    phone = RedeemData.GetRedeemPhone(_file),
                    state = RedeemData.GetRedeemState(_file);
                MainHomePage mall = InitialPage.Go().EnterId(client).Logon().ClickLogin();
                var gif = mall.NavigateToRedeemA().SearchCompany(company);
                Assert.AreEqual("Amazon.com", gif.GetGifCardTitle(), "The gif card is not amazon");
                var gifcard = gif.SelectCompany().ClickAddToCart();
                Assert.AreEqual("Your item has been added to your cart!", gifcard.GetSuccesfullMsg(),
                    "succesfull msg is not well spell");
                var checkout = gifcard.ClickGoToCart().ClickCheckOut();
                checkout.FillName(firstname)
                    .FillLastName(secondname)
                    .FillAddress(address)
                    .FillCity(city)
                    .SelectState(state)
                    .FillZipCode(zip)
                    .FillPhoneNumber(phone);
                Assert.IsFalse(checkout.CannotEditEmail(), "Email txt field is editable");
                checkout.ClickNext();
                Assert.AreEqual("We got you covered Tester Stride", checkout.GetNoCreditCardUseMsg(),
                    "The message is wrong or its possible to use the credit card");
                Assert.AreEqual("Your rewards have covered your balance.\r\nEnjoy your gift.",
                    checkout.GetNoCreditCardUseMsgSubtitle(),
                    "The message is wrong or its possible to use the credit card");
                checkout.ClickNextPayment();
                Assert.AreEqual("Review items", checkout.GetLastStep(), "Last step title is not right");
                checkout.ClickCheckOut();
                Assert.AreEqual("$25", checkout.GetAmountChecked(), "Amount Checked is not $25");
                Assert.AreEqual("1", checkout.GetQuantityChecked(), "Quantity is not 1");
            }
        }

        [Category("Regression")]
        [Category("Sungard")]
        //WS-956
        [Test]
        public void WS_956()
        {
            if (!DataParser.ReturnExecution("WS_956"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_956.xml";
                AwardData.GetAwardImpact(_file);
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    amount = AwardData.GetAwardAmountValue(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file);
                NominationHomePage recognitionPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToNominationSpan();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValueOfAward(amount)
                    .SelectValues(value)
                    .FillMsg(msg)
                    .FillReason(reason).ClickNext();
                Assert.AreEqual("I want to email this award.", recognitionPage.GetDeliverLabel("email"),
                    "Label is not correct");
                Assert.AreEqual("I want to print this award.", recognitionPage.GetDeliverLabel("print"),
                    "Label is not correct");
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", recognitionPage.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
                ProxyHomePage proxyPage = recognitionPage.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(proxy_name);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(award, awards.GetAwardName(1, 5), "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 8);
            }
        }

        [Category("Regression")]
        [Category("Sungard")]

        //WS_1148
        [Test]
        public void WS_1148()
        {
            if (!DataParser.ReturnExecution("WS_1148"))
                Assert.Ignore();
            else
            {
                MainHomePage mainHomePage = InitialPage.Go().EnterId(client).Logon().ClickLogin();
                Assert.IsTrue(mainHomePage.IsEveryoneSelected(), "Everyone is not selected in display options");
                int quantComments = Int32.Parse(mainHomePage.CongratsCount());
                mainHomePage.ClickCongrats();
                mainHomePage.AddCongrats("QA Test Submision").SendCongrats();
                Assert.AreEqual("Your message has been sent!", mainHomePage.GetCongratsMsg(),
                    "Congrats msg was not sent");
                Assert.AreEqual(quantComments + 1, Int32.Parse(mainHomePage.CongratsCount()),
                    "Congrats was not plus well 1");
            }
        }

        [Category("Regression")]
        [Category("Sungard")]

        [Test]
        public void WS_1062()
        {
            if (!DataParser.ReturnExecution("WS_1062"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1062.xml";
                username = ProxyData.GetProxyUserName(_file);
                MainHomePage home = InitialPage.Go().EnterId(client).Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
            }
        }

        [Category("Regression")]
        [Category("Sungard")]

        //WS_1184
        [Test]
        public void WS_1185()
        {
            if (!DataParser.ReturnExecution("WS_1185"))
                Assert.Ignore();
            else
            {
                MainHomePage mainHomePage = InitialPage.Go().EnterId(client).Logon().ClickLogin();
                Assert.IsTrue(mainHomePage.IsEveryoneSelected(), "Everyone is not selected in display options");
                mainHomePage.ClickCheers();
                if (mainHomePage.CheersCountSungard() == "-1")
                    mainHomePage.ClickCheers();
                Assert.AreEqual("1", mainHomePage.CheersCountSungard(), "Cheers is not 1");
                mainHomePage.NavigateToRedeem().NavigateToHomePage();
                Assert.AreEqual("1", mainHomePage.CheersCountSungard(), "Cheers is not 1");
            }
        }

        [Category("Regression")]
        [Category("Sungard")]
        //WS-1112
        [Test]
        public void WS_1112()
        {
            if (!DataParser.ReturnExecution("WS_1112"))
                Assert.Ignore();
            else
            {
                string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml", client);
                url = url.Substring(0, 28);
                MainHomePage home = InitialPage.Go().EnterId(client).Logon().ClickLogin();
                Assert.AreEqual("Recognize Someone", home.GetLeftMenuOpts(0),"Link is Broken or not well written");
                NominationHomePage nomination = home.NavigateToNominationSpan();
                Assert.AreEqual(url + "ng#/recognize", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = nomination.NavigateToHomePage();
                Assert.AreEqual("Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                EventCalendar events = home.NavigateToEventCalendar();
                Assert.AreEqual(url + "event_calendar#/", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = events.NavigateToHomePage();
                Assert.AreEqual("Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                GoToMallHomePage mall = home.NavigateToMall();
                Assert.AreEqual(url + "mall#/", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = mall.NavigateToHomePage();
                Assert.AreEqual("My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                MyAwards awards = home.NavigateToMyAwards();
                Assert.AreEqual(url + "my_awards#/", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = awards.NavigateToHomePage();
                Assert.AreEqual("Pending Approvals", home.GetLeftMenuOpts(4), "Link is Broken or not well written");
                PendingApprovals pending = home.NavigateToPendingApprovals();
                Assert.AreEqual(url + "approval#/", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = awards.NavigateToHomePage();
                Assert.AreEqual("My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                MyRedemptions redemption = home.NavigateToMyRedemptions();
                Assert.AreEqual(url + "my_redemptions#/", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
            }
        }
    }
}
