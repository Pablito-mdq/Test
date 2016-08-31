using System;
using System.Windows.Forms;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.Login;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.BAE
{

    class SampleTestSuite : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");
        private static string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml","BAE");

        [Category("Regression")]
        [Category("BAE")]
        //WS-1133
        [Test]
        public void WS_1133()
        {
            if (!DataParser.ReturnExecution("WS_1133"))
                Assert.Ignore();
            else
            {
                LoginPage MainPage = InitialPage.Go().Logon();
                string originalURL = MainPage.GetCurrentUrl();
                LoginPage loginPage = MainPage.ClickLogin().ClickLogOut();
                string newURL = loginPage.GetCurrentUrl();
                Assert.AreEqual(originalURL,newURL,"The login page is not the same for SSO users");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        [Category("Cleveland")]
        [Test]
        //WS-65
        public void WS_65()
        {
            if (!DataParser.ReturnExecution("WS_65"))
                Assert.Ignore();
            else
            {
                MainHomePage menuPage = InitialPage.Go().Logon().ClickLogin();
                GoToMallHomePage mallPage = menuPage.NavigateToMall();
                Assert.AreEqual(" By Price:", mallPage.GetFilterTitleText(0), "The subtitle is not the right one");
                Assert.AreEqual("  Under $25", mallPage.GetFilterChkTypeByPrice(0), "The category to filter it's wrong labeled");
                Assert.AreEqual("  $25 - $50", mallPage.GetFilterChkTypeByPrice(1), "The category to filter it's wrong labeled");
                mallPage.CheckOptionByPrice("Under $25");
                Assert.IsTrue(mallPage.FilterByPriceUnderWorks("$25"), "The Filter Under $25 is not working");
                mallPage.CheckOptionByPrice("Under $25");
                mallPage.CheckOptionByPrice("$25 - $50");
                Assert.IsTrue(mallPage.FilterByPriceUnderWorks("$25"), "The Filter $25 - $50 is not working");
                /*Assert.AreEqual("  $50 - $100", mallPage.GetFilterChkTypeByPrice(2), "The category to filter it's wrong labeled");
            Assert.AreEqual("  $100 - $250", mallPage.GetFilterChkTypeByPrice(3), "The category to filter it's wrong labeled");
            Assert.AreEqual("  $250 - $500", mallPage.GetFilterChkTypeByPrice(4), "The category to filter it's wrong labeled");
            Assert.AreEqual("  $500 +", mallPage.GetFilterChkTypeByPrice(5), "The category to filter it's wrong labeled");
            Assert.AreEqual(" Purchase Type:", mallPage.GetFilterTitleText(1), "The subtitle is not the right one");
            Assert.AreEqual("  Email (Instant)", mallPage.GetFilterChkTypeByPurchase(0), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Mail (A Few Days)", mallPage.GetFilterChkTypeByPurchase(1), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Multi-Store !", mallPage.GetFilterChkTypeByPurchase(2), "The category to filter it's wrong labeled");
            Assert.AreEqual(" Categories:", mallPage.GetFilterTitleText(2), "The subtitle is not the right one");
            Assert.AreEqual("  Featured", mallPage.GetFilterChkTypeByCategory(9), "The category to filter it's wrong labeled");
            Assert.AreEqual("  All", mallPage.GetFilterChkTypeByCategory(10), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Accessories", mallPage.GetFilterChkTypeByCategory(11), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Apparel & Shoes", mallPage.GetFilterChkTypeByCategory(12), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Babies and Kids", mallPage.GetFilterChkTypeByCategory(13), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Bed & Bath", mallPage.GetFilterChkTypeByCategory(14), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Books and Music", mallPage.GetFilterChkTypeByCategory(15), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Décor", mallPage.GetFilterChkTypeByCategory(16), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Department Stores", mallPage.GetFilterChkTypeByCategory(17), "The category to filter it's wrong labeled");
            Assert.AreEqual("  DVD's and Movies", mallPage.GetFilterChkTypeByCategory(18), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Electronics", mallPage.GetFilterChkTypeByCategory(19), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Food and Wine", mallPage.GetFilterChkTypeByCategory(20), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Gifts", mallPage.GetFilterChkTypeByCategory(21), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Health & Beauty", mallPage.GetFilterChkTypeByCategory(22), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Home & Garden", mallPage.GetFilterChkTypeByCategory(23), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Jewelry & Watches", mallPage.GetFilterChkTypeByCategory(24), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Kitchen & Cooking", mallPage.GetFilterChkTypeByCategory(25), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Office", mallPage.GetFilterChkTypeByCategory(26), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Pets", mallPage.GetFilterChkTypeByCategory(27), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Restaurants", mallPage.GetFilterChkTypeByCategory(28), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Sports and Fitness", mallPage.GetFilterChkTypeByCategory(29), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Toys and Games", mallPage.GetFilterChkTypeByCategory(30), "The category to filter it's wrong labeled");
            Assert.AreEqual("  Travel & Entertainment", mallPage.GetFilterChkTypeByCategory(31), "The category to filter it's wrong labeled");*/
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-317
        [Test]
        public void WS_1059()
        {
            if (!DataParser.ReturnExecution("WS_1059"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1059.xml";
                string path = GeneralData.path(_file); int width = GeneralData.width(_file), height = GeneralData.height(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                var a = home.EditProfile();
                a.ClickUploadphoto();
                SendKeys.SendWait(path);
                SendKeys.SendWait("{ENTER}");
                int b = width*height;
                var c = a.getsizeuploadim();
                Assert.AreNotEqual(b,c, "The size is the same so,the image is not changed");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-317
        [Test]
        public void WS_61()
        {
            if (!DataParser.ReturnExecution("WS_61"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_61.xml";
                string url = GeneralData.GetUrl(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                home.NavigateToMall();
                Assert.AreEqual(url, home.GetCurrentUrl(), "The URL is not correct");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-317
        [Test]
        public void WS_69()
        {
            if (!DataParser.ReturnExecution("WS_69"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_69.xml";
                username = AwardData.GetAwardUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                NominationHomePage recognitionPage = home.NavigateToNomination();
                //SCENARIO 1
                recognitionPage.SearchEmployeeFound(username);
                recognitionPage.ClickEdit();
                Assert.IsTrue(recognitionPage.BringToStep1(), "You didnt go back to step 1");
                //SCENARIO 2
                recognitionPage = home.NavigateToNomination();
                recognitionPage.ClickMultipleRecipients().SearchEmployeeFoundMultiple(username).SearchEmployeeFoundMultiple("John");
                recognitionPage.ClickNextGeneric().ClickEdit().ClickRemove(0);
                Assert.IsFalse(recognitionPage.IsFirstUserAddedPresent(username), "First User still in the list selected");

            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-317
        [Test]
        public void WS_317()
        {
            if (!DataParser.ReturnExecution("WS_317"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_317.xml";
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
        public void WS_1044_BAE()
        {
            if (!DataParser.ReturnExecution("WS_1044_BAE"))
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
        public void WS_921()
        {
            if (!DataParser.ReturnExecution("WS_921"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_921.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    amount = AwardData.GetAwardAmountValue(_file),
                    impact = AwardData.GetAwardImpact(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(proxy_name);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                NominationHomePage recognitionPage = home.NavigateToNomination();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .FillMsg(msg);
                if (reason != "")
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
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(award, awards.GetAwardName(1, 4), "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 7);
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-924
        [Test]
        public void WS_924()
        {
            if (!DataParser.ReturnExecution("WS_924"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_924.xml";
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
        [Category("Regression")]
        [Category("BAE")]
        //WS-917
        [Test]
        public void WS_1052()
        {
            if (!DataParser.ReturnExecution("WS_1052"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1052.xml";
                string firstName = RegisterData.GetRegisterFirstName(_file),
                    lastName = RegisterData.GetRegisterLastName(_file),
                    ID = RegisterData.GetRegisterID(_file),
                    email = RegisterData.GetRegisterEmail(_file);
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.AreEqual("First Name", registerPage.GetName("First Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.AreEqual("Last Name", registerPage.GetName("Last Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.AreEqual("Employee ID", registerPage.GetName("Employee ID"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.AreEqual("Email Address", registerPage.GetName("Email Address"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                registerPage.EnterFirstName(firstName)
                    .EnterLastName(lastName)
                    .EnterEmployeeID(ID)
                    .EnterEmployeeEmail(email)
                    .ClickRegister();
                Assert.AreEqual("Success!\r\nWe found you. Check your inbox at " + email + " for a link to finish registration. Thank you!", registerPage.GetSuccessMsg(), "Message is not the expected");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-917
        [Test]
        public void WS_175()
        {
            if (!DataParser.ReturnExecution("WS_175"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_175.xml";
                string preferredName = RegisterData.GetRegisterPreferedName(_file);
                EditProfilePage profilePage = InitialPage.Go().Logon().ClickLogin().EditProfile();
                Assert.AreEqual("Profile Settings", profilePage.GetTitleName("Profile Settings"), "Title is now well spell");
                profilePage.EnterPreferedName(preferredName).ClickSubmit();
                Assert.AreEqual(preferredName, profilePage.GetShowName(preferredName), "Prefered Name is now well spell");
                MainHomePage mainPage = profilePage.NavigateToHomePage();
                Assert.AreEqual("Welcome " + preferredName + " to the BAE Systems, IMPACT!", mainPage.GetWelcomeTitle(), "Welcome Ttile is now well spell");
            }
        }
        [Category("Regression")]
        [Category("BAE")]

        [Test]
        public void WS_1070()
        {
            if (!DataParser.ReturnExecution("WS_1070"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1070.xml";
                username = ProxyData.GetProxyUserName(_file);
                string username2 = ProxyData.GetProxySecondUserName(_file), award = AwardData.GetAwardName(_file),
                    msg = AwardData.GetAwardMessage(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                EventCalendar eventPage = home.NavigateToEventCalendar();
                eventPage.ClickRecent();
                Assert.AreEqual(username2 + "\r\nBirthday", eventPage.GetNameList(0), username2 + " is not present");
                NominationHomePage nomination = eventPage.clickSendRecognition().SelectAward(award).FillMsg(msg).SelectImgs();
                nomination.EmailReward().ClickSendRecognition();
                Assert.AreEqual("Success!", nomination.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", nomination.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", nomination.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
            }
        }

        [Category("Regression")]
        [Category("BAE")]

        [Test]
        public void WS_1084()
        {
            if (!DataParser.ReturnExecution("WS_1084"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1084.xml";
                username = ProxyData.GetProxyUserName(_file);
                string username2 = ProxyData.GetProxySecondUserName(_file), award = AwardData.GetAwardName(_file),
                    msg = AwardData.GetAwardMessage(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                EventCalendar eventPage = home.NavigateToEventCalendar();
                eventPage.ClickRecent();
                Assert.AreEqual(username2 + "\r\n12 year Anniversary", eventPage.GetNameList(6), username2 + " is not present");
                NominationHomePage nomination = eventPage.clickSendAniversaryCard().SelectAward(award).FillMsg(msg).SelectImgs();
                nomination.EmailReward().ClickSendRecognition();
                Assert.AreEqual("Success!", nomination.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", nomination.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", nomination.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
            }
        }

        [Category("Regression")]
        [Category("BAE")]

        [Test]
        public void WS_1161()
        {
            if (!DataParser.ReturnExecution("WS_1161"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1161.xml";
                string user = AwardData.GetAwardUserName(_file), user1 = AwardData.GetAwardUserName1(_file)
                    , user2 = AwardData.GetAwardUserName2(_file), user3 = AwardData.GetAwardUserName3(_file),
                    user4 = AwardData.GetAwardUserName4(_file), 
                    user5 = AwardData.GetAwardUserName5(_file), proxy_name = ProxyData.GetProxyUserName(_file);
                    
                //Scenario 1
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNomination();
                recognitionPage.ClickMultipleRecipients()
                    .SearchEmployeeFoundMultiple(user)
                    .SearchEmployeeFoundMultiple(user1)
                    .SearchEmployeeFoundMultiple(user2).SearchEmployeeFoundMultiple(user3).ClickNextGeneric();
                Assert.IsTrue(recognitionPage.IsStep2Block(),"Step2 is not blocked");

                //Scenario 2
                MainHomePage mainPage = recognitionPage.NavigateToAdminHomePage().LoginProxyAsuser().EnterUserName(proxy_name).ProxyToMainHomePage();
                Step2 ste2 =mainPage.NavigateToNomination().SearchEmployeeFound(user4);
                Assert.AreEqual("Rave",ste2.GetAwardName("Rave"),"Rave Award is not present");
                Assert.AreEqual("Pioneer Award", ste2.GetAwardName("Pioneer Award"), "Pioneer Award is not present");
                Assert.AreEqual("Pathfinder Award", ste2.GetAwardName("Pathfinder Award"), "Pathfinder Award is not present");
                Assert.AreEqual("Trailblazer Award", ste2.GetAwardName("Trailblazer Award"), "Trailblazer Award is not present");

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
        [Category("BAE")]
        //WS-1133
        [Test]
        public void WS_1145()
        {
            if (!DataParser.ReturnExecution("WS_1145"))
                Assert.Ignore();
            else
            {
                MainHomePage mainPage = InitialPage.Go().Logon().ClickLogin();
                Assert.IsTrue(mainPage.GetAllHttpLinkResponses(url),"No all Responses Get an successfully validation");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-1189
        [Test]
        public void WS_1187()
        {
            if (!DataParser.ReturnExecution("WS_1187"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1187.xml";
                string creditcard1 = GeneralData.GetPathCreditCard1Img(_file), creditcard2 = GeneralData.GetPathCreditCard2Img(_file);
                GoToMallHomePage redeem = InitialPage.Go().Logon().ClickLogin().NavigateToRedeemA();
                Assert.AreEqual("Welcome to the Mall!",redeem.GetWelcomeMsg(),"Welcome Msg is not present or well written");
                redeem.SearchCompany("Work");
                Assert.AreEqual(creditcard1,redeem.GetImgFirstCreditCard(),"Credit Card 1 source is not the same");
                Assert.AreEqual(creditcard2,redeem.GetImgSecondCreditCard(),"Credit Card 2 source is not the same");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-1189
        [Test]
        public void WS_1190()
        {
            if (!DataParser.ReturnExecution("WS_1190"))
                Assert.Ignore();
            else
            {
                MainHomePage mainPage = InitialPage.Go().Logon().ClickLogin();
                Assert.IsTrue(mainPage.IsEveryoneSelected(), "Everyone is not selected in display options");
                if (mainPage.IsFollowBannerPresent())
                       mainPage.ClickFollow();
                mainPage.ClickFollow();
                Assert.IsTrue(mainPage.IsFollowBannerPresent(),"Follow banner is not present");
                mainPage = mainPage.NavigateToRedeemA().NavigateToHomePage();
                Assert.AreEqual("FOLLOWING",mainPage.GetFollowingRibbonMsg(),"Following is not present or not spell well");
            }
        }


        [Category("Regression")]
        [Category("BAE")]
        //WS-1201
        [Test]
        public void WS_1199()
        {
            if (!DataParser.ReturnExecution("WS_1199"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1199.xml";
                string company = RedeemData.GetRedeemCompany(_file), creditcardnumber=RedeemData.GetRedeemCreditCardNumber(_file)
                    , creditcardname = RedeemData.GetRedeemCreditCardName(_file), creditcardexpiremonth = RedeemData.GetRedeemCreditCardExpireMonth(_file), creditcardexpireyear = RedeemData.GetRedeemCreditCardExpireYear(_file)
                    , creditcardCDI = RedeemData.GetRedeemCreditCardCDI(_file), firstname = RedeemData.GetRedeemFirstName(_file),
                    secondname = RedeemData.GetRedeemSecondName(_file),address = RedeemData.GetRedeemAddress(_file), city = RedeemData.GetRedeemCity(_file),
                    zip = RedeemData.GetRedeemZip(_file), phone = RedeemData.GetRedeemPhone(_file), state = RedeemData.GetRedeemState(_file);
                MainHomePage mall = InitialPage.Go().Logon().ClickLogin();
                var gif = mall.NavigateToRedeemA().SearchCompany(company);
                Assert.AreEqual("Amazon.com",gif.GetGifCardTitle(),"The gif card is not amazon");
                var gifcard = gif.SelectCompany().ClickPlusAmount().ClickPlusQuantity(20).ClickAddToCart();
                Assert.AreEqual("Your item has been added to your cart!",gifcard.GetSuccesfullMsg(),"succesfull msg is not well spell");
                var checkout = gifcard.ClickGoToCart().ClickCheckOut();
                checkout.FillName(firstname)
                    .FillLastName(secondname)
                    .FillAddress(address)
                    .FillCity(city)
                    .SelectState(state)
                    .FillZipCode(zip)
                    .FillPhoneNumber(phone);
                Assert.IsFalse(checkout.CannotEditEmail(),"Email txt field is editable");
                checkout.ClickNext().FillCreditCardNumber(creditcardnumber)
                    .FillCreditCardName(creditcardname)
                    .SelectExpireDate(creditcardexpiremonth,creditcardexpireyear)
                    .FillCreditCardCDI(creditcardCDI)
                    .CheckSameBillingAddress()
                    .ClickNext();
                Assert.AreEqual("Review items", checkout.GetLastStep(), "Last step title is not right");
                checkout.ClickCheckOut();
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-1201
        [Test]
        public void WS_1198()
        {
            if (!DataParser.ReturnExecution("WS_1198"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1198.xml";
                string company = RedeemData.GetRedeemCompany(_file), firstname = RedeemData.GetRedeemFirstName(_file),
                    secondname = RedeemData.GetRedeemSecondName(_file), address = RedeemData.GetRedeemAddress(_file), city = RedeemData.GetRedeemCity(_file),
                    zip = RedeemData.GetRedeemZip(_file), phone = RedeemData.GetRedeemPhone(_file), state = RedeemData.GetRedeemState(_file);
                MainHomePage mall = InitialPage.Go().Logon().ClickLogin();
                var gif = mall.NavigateToRedeemA().SearchCompany(company);
                Assert.AreEqual("Amazon.com", gif.GetGifCardTitle(), "The gif card is not amazon");
                var gifcard = gif.SelectCompany().ClickAddToCart();
                Assert.AreEqual("Your item has been added to your cart!", gifcard.GetSuccesfullMsg(), "succesfull msg is not well spell");
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
                Assert.AreEqual("We got you covered Tester Stride", checkout.GetNoCreditCardUseMsg(), "The message is wrong or its possible to use the credit card");
                Assert.AreEqual("Your rewards have covered your balance.\r\nEnjoy your gift.", checkout.GetNoCreditCardUseMsgSubtitle(), "The message is wrong or its possible to use the credit card");
                checkout.ClickNextPayment();
                Assert.AreEqual("Review items", checkout.GetLastStep(), "Last step title is not right");
                checkout.ClickCheckOut();
                Assert.AreEqual("$25",checkout.GetAmountChecked(),"Amount Checked is not $25");
                Assert.AreEqual("1",checkout.GetQuantityChecked(),"Quantity is not 1");
            }
        }


        [Category("Regression")]
        [Category("BAE")]
        //WS-1202
        [Test]
        public void WS_1202()
        {
            if (!DataParser.ReturnExecution("WS_1202"))
                Assert.Ignore();
            else
            {
                GoToMallHomePage mall = InitialPage.Go().Logon().ClickLogin().NavigateToRedeemA();
                Assert.IsTrue(mall.AreAllImagesDisplayed(), "No all images all ok Get an successfully validation");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1212
        [Test]
        public void WS_1212()
        {
            if (!DataParser.ReturnExecution("WS_1212"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1212.xml";
                string firstName = RegisterData.GetRegisterFirstName(_file),
                    lastName = RegisterData.GetRegisterLastName(_file),
                    ID = RegisterData.GetRegisterID(_file),
                    email = RegisterData.GetRegisterEmail(_file);
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.AreEqual("First Name", registerPage.GetName("First Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.AreEqual("Last Name", registerPage.GetName("Last Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.AreEqual("Employee ID", registerPage.GetName("Employee ID"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.AreEqual("Email Address", registerPage.GetName("Email Address"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                registerPage.EnterFirstName(firstName)
                    .EnterLastName(lastName)
                    .EnterEmployeeID(ID)
                    .EnterEmployeeEmail(email)
                    .ClickRegister();
                Assert.AreEqual("Hmm, we couldn't find anyone matching the information you entered. Please make sure your email and Employee ID are correct. Also, maybe we have a different variation of your first or last name?", registerPage.GetSuccessMsg(), "Message is not the expected");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        [Test]
        public void WS_1210()
        {
            if (!DataParser.ReturnExecution("WS_1210"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1210.xml";
                string username1 = ProxyData.GetProxySecondUserName(_file), username = ProxyData.GetProxyUserName(_file),
                    username2 = ProxyData.GetProxyThirdUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username + " Ahsing", home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                home = home.ExitProxy().EnterUserName(username1).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + "Aaron " + username1, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                home = home.ClosePopUp().ExitProxy().EnterUserName(username2).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username2, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1212
        [Test]
        public void WS_1216()
        {
            if (!DataParser.ReturnExecution("WS_1216"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1216.xml";
                string firstName = RegisterData.GetRegisterFirstName(_file),
                    lastName = RegisterData.GetRegisterLastName(_file),
                    ID = RegisterData.GetRegisterID(_file),
                    email = RegisterData.GetRegisterEmail(_file);
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.AreEqual("First Name", registerPage.GetName("First Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.AreEqual("Last Name", registerPage.GetName("Last Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.AreEqual("Employee ID", registerPage.GetName("Employee ID"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.AreEqual("Email Address", registerPage.GetName("Email Address"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                registerPage.EnterFirstName(firstName)
                    .EnterLastName(lastName)
                    .EnterEmployeeID(ID)
                    .EnterEmployeeEmail(email)
                    .ClickRegister();
                Assert.AreEqual("Hmm, we couldn't find anyone matching the information you entered. Please make sure your email and Employee ID are correct. Also, maybe we have a different variation of your first or last name?", registerPage.GetSuccessMsg(), "Message is not the expected");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1212
        [Test]
        public void WS_1218()
        {
            if (!DataParser.ReturnExecution("WS_1218"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1218.xml";
                string firstName = RegisterData.GetRegisterFirstName(_file),
                    lastName = RegisterData.GetRegisterLastName(_file),
                    ID = RegisterData.GetRegisterID(_file),
                    email = RegisterData.GetRegisterEmail(_file);
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.AreEqual("First Name", registerPage.GetName("First Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.AreEqual("Last Name", registerPage.GetName("Last Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.AreEqual("Employee ID", registerPage.GetName("Employee ID"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.AreEqual("Email Address", registerPage.GetName("Email Address"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                registerPage.EnterFirstName(firstName)
                    .EnterLastName(lastName)
                    .EnterEmployeeID(ID)
                    .EnterEmployeeEmail(email)
                    .ClickRegister();
                Assert.AreEqual("Hmm, we couldn't find anyone matching the information you entered. Please make sure your email and Employee ID are correct. Also, maybe we have a different variation of your first or last name?", registerPage.GetSuccessMsg(), "Message is not the expected");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        [Category("Sprint")]
        //WS_1225
        [Test]
        public void WS_1225()
        {
            if (!DataParser.ReturnExecution("WS_1225"))
                Assert.Ignore();
            else
            {
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                Assert.AreEqual(url + "report/bae_awards", reportpage.GetCurrentUrl(),"URL is not the correct");
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(),"The Report takes more than 10 sec to load");
                reportpage.ClickHeader(1);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(2);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(3);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(4);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(5);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(6);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(7);
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1229
        [Test]
        public void WS_1229()
        {
            if (!DataParser.ReturnExecution("WS_1229"))
                Assert.Ignore();
            else
            {
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("All Awards"),"Option is not well written");
                reportpage.ClickLeftMenu("All Awards");
                Assert.AreEqual(url + "report/bae_awards",reportpage.GetCurrentUrl(),"Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("All Awards (Sector)"), "Option is not well written");
                reportpage.ClickLeftMenu("All Awards (Sector)");
                Assert.AreEqual(url + "report/bae_awards_by_sector", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Issued Awards"), "Option is not well written");
                reportpage.ClickLeftMenu("Issued Awards");
                Assert.AreEqual(url + "report/bae_issued_awards", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Teams Awards"), "Option is not well written");
                reportpage.ClickLeftMenu("Teams Awards");
                Assert.AreEqual(url + "report/awards_by_manager", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Milestones"), "Option is not well written");
                reportpage.ClickLeftMenu("Milestones");
                Assert.AreEqual(url + "report/milestones", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Received Awards"), "Option is not well written");
                reportpage.ClickLeftMenu("Received Awards");
                Assert.AreEqual(url + "report/bae_received_awards", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Payroll (Sector)"), "Option is not well written");
                reportpage.ClickLeftMenu("Payroll (Sector)");
                Assert.AreEqual(url + "report/bae_payroll_sector", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Payroll"), "Option is not well written");
                reportpage.ClickLeftMenu("Payroll");
                Assert.AreEqual(url + "report/bae_payroll", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Budget"), "Option is not well written");
                reportpage.ClickLeftMenu("Budget");
                Assert.AreEqual(url + "report/edit_budget_tool", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Pending Approvals"), "Option is not well written");
                reportpage.ClickLeftMenu("Pending Approvals");
                Assert.AreEqual(url + "report/pending_approvals", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Team Pending Approvals"), "Option is not well written");
                reportpage.ClickLeftMenu("Team Pending Approvals");
                Assert.AreEqual(url + "report/pending_approvals_by_manager", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Proxy Access"), "Option is not well written");
                reportpage.ClickLeftMenu("Proxy Access");
                Assert.AreEqual(url + "report/proxy_access", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Activity"), "Option is not well written");
                reportpage.ClickLeftMenu("Activity");
                Assert.AreEqual(url + "report/activities", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Missing Emails (Internal)"), "Option is not well written");
                reportpage.ClickLeftMenu("Missing Emails (Internal)");
                Assert.AreEqual(url + "report/bae_missing_emails", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Awards By Budget"), "Option is not well written");
                reportpage.ClickLeftMenu("Awards By Budget");
                Assert.AreEqual(url + "report/awards_by_budget_owner", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Payroll By Budget"), "Option is not well written");
                reportpage.ClickLeftMenu("Payroll By Budget");
                Assert.AreEqual(url + "report/payroll_by_budget_owner", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Manager Issued Awards"), "Option is not well written");
                reportpage.ClickLeftMenu("Manager Issued Awards");
                Assert.AreEqual(url + "report/manager_awards", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Awards By Payroll (HRBP)"), "Option is not well written");
                reportpage.ClickLeftMenu("Awards By Payroll (HRBP)");
                Assert.AreEqual(url + "report?reportName=bae_payroll_by_budget_owner_hrbp", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Budget Transactions"), "Option is not well written");
                reportpage.ClickLeftMenu("Budget Transactions");
                Assert.AreEqual(url + "report/budget_adjustments", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Manager Award Totals"), "Option is not well written");
                reportpage.ClickLeftMenu("Manager Award Totals");
                Assert.AreEqual(url + "report/manager_issued_awards", reportpage.GetCurrentUrl(), "Url is not the expected one");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1231
        [Test]
        public void WS_1231()
        {
            if (!DataParser.ReturnExecution("WS_1231"))
                Assert.Ignore();
            else
            {
                 _file = "Resources\\TestsData\\" + client + "\\WS_1231.xml";
                 string startDate = ReportFilterData.GetStartDate(_file),
                    finishDate = ReportFilterData.GetFinishDate(_file);
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                reportpage.ClickFilter().EnterStartDate(startDate).EnterFinishDate(finishDate).ClickSubmit();
                Assert.AreEqual(startDate,reportpage.GetDate(0),"Start Date is not the same");
                Assert.AreEqual(finishDate, reportpage.GetDate(1), "Start Date is not the same");
             }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1227
        [Test]
        public void WS_1227()
        {
            if (!DataParser.ReturnExecution("WS_1227"))
                Assert.Ignore();
            else
            {
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports().SelectPageSize("500");
                int row=500 , col=7;
                for (int i = 1; i < row; i++)
                  for (int j = 1; j < col; j++)
                     Assert.IsTrue(reportpage.IsCellFull(i,j), "Cell is empty");
                Assert.Pass("All cell Are full");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1233
        [Test]
        public void WS_1233()
        {
            if (!DataParser.ReturnExecution("WS_1233"))
                Assert.Ignore();
            else
            {
                int[] list =new int[21];
                for (int i = 0; i < 21; i++)
                {
                    list[i] = Convert.ToInt32("1");
                }
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                Assert.AreEqual(url + "report/bae_awards", reportpage.GetCurrentUrl(), "URL is not the correct");
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickLeftMenu("All Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[1] = 0;
                reportpage.ClickLeftMenu("All Awards (Sector)");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[2] = 0;
                reportpage.ClickLeftMenu("Issued Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[3] = 0;
                reportpage.ClickLeftMenu("Teams Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[4] = 0;
                reportpage.ClickLeftMenu("Milestones");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[5] = 0;
                reportpage.ClickLeftMenu("Received Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[6] = 0;
                reportpage.ClickLeftMenu("Payroll (Sector)");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[7] = 0;
                reportpage.ClickLeftMenu("Payroll");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[8] = 0;
                reportpage.ClickLeftMenu("Budget");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[9] = 0;
                reportpage.ClickLeftMenu("Pending Approvals");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[10] = 0;
                reportpage.ClickLeftMenu("Team Pending Approvals");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[11] = 0;
                reportpage.ClickLeftMenu("Proxy Access");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[12] = 0;
                reportpage.ClickLeftMenu("Activity");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[13] = 0;
                reportpage.ClickLeftMenu("Missing Emails (Internal)");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[14] = 0;
                reportpage.ClickLeftMenu("Awards By Budget");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[15] = 0;
                reportpage.ClickLeftMenu("Payroll By Budget");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[16] = 0;
                reportpage.ClickLeftMenu("Manager Issued Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[17] = 0;
                reportpage.ClickLeftMenu("Awards By Payroll (HRBP)");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[18] = 0;
                reportpage.ClickLeftMenu("Budget Transactions");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[19] = 0;
                reportpage.ClickLeftMenu("Manager Award Totals");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[20] = 0;
                int j = 0;
                while ((list[j] == 1) && (j < 21))
                    j++;
                if (j == 21)
                    Assert.Pass("All the links are loaded in less than 10 sec");
                Assert.Fail("Not all the links are loading in less than 10 secs");
            }
        }
        [Category("Regression")]
        [Category("BAE")]
        //WS_1274
        [Test]
        public void WS_1274()
        {
            if (!DataParser.ReturnExecution("WS_1274"))
                Assert.Ignore();
            else
            {
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                string issuer = reportpage.GetAwardTable(1, 8), award = reportpage.GetAwardTable(1, 4), recipient = reportpage.GetAwardTable(1, 2),
                    awardTie = reportpage.GetAwardTable(1, 4), teamName = reportpage.GetAwardTable(1, 6), date = reportpage.GetAwardTable(1, 1),
                    amount = reportpage.GetAwardTable(1,3);
                ReportDetailsPage detailsPage = reportpage.ClickViewDetails(1);
                Assert.AreEqual(issuer,detailsPage.GetIssuer(),"Issuer Value is not the same");
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
        //WS_1274
        [Test]
        public void WS_1277()
        {
            if (!DataParser.ReturnExecution("WS_1277"))
                Assert.Ignore();
            else
            {
                BudgetHomePage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports().ClickBudgetLeftMenu();
                var balance = reportpage.GetAwardTable(1, 6);
                var editdetailsPage = reportpage.ClickEdit(1);
                Assert.AreEqual("ADD", reportpage.GetAddBtnTxt(), "Issuer Value is not the same");
                Assert.AreEqual("SUBTRACT", reportpage.GetSubstratBtnTxt(), "Subtract Value is not the same");
                Assert.AreEqual("DEACTIVATE", reportpage.GetDeactBtnTxt(), "Deactivate Value is not the same");
                Assert.AreEqual("CLOSE", reportpage.GetBtnCloseTxt(), "close Value is not the same");
                reportpage = editdetailsPage.EnterAmount("1000").ClickAdd();
                var amount = balance + 1000;
                Assert.AreEqual(amount, reportpage.GetAwardTable(1, 6), "Budget Value is not the same");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1282
        [Test]
        public void WS_1282()
        {
            if (!DataParser.ReturnExecution("WS_1282"))
                Assert.Ignore();
            else
            {
                BudgetHomePage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports().ClickBudgetLeftMenu();
                var editdetailsPage = reportpage.ClickEdit(1);
                Assert.AreEqual("ADD", reportpage.GetAddBtnTxt(), "Issuer Value is not the same");
                Assert.AreEqual("SUBTRACT", reportpage.GetSubstratBtnTxt(), "Subtract Value is not the same");
                Assert.AreEqual("DEACTIVATE", reportpage.GetDeactBtnTxt(), "Deactivate Value is not the same");
                Assert.AreEqual("CLOSE", reportpage.GetBtnCloseTxt(), "close Value is not the same");
                reportpage.ClickDeactivate();
                editdetailsPage = reportpage.ClickEdit(1);
                Assert.AreEqual("Budget Active Status: false",editdetailsPage.GetDeactMsg(),"Deact Text is not the same as expected");
                editdetailsPage.ClickActivate();
                reportpage = editdetailsPage.ClickEdit(1);
                Assert.AreEqual("ADD", reportpage.GetAddBtnTxt(), "Issuer Value is not the same");
                Assert.AreEqual("SUBTRACT", reportpage.GetSubstratBtnTxt(), "Subtract Value is not the same");
                Assert.AreEqual("DEACTIVATE", reportpage.GetDeactBtnTxt(), "Deactivate Value is not the same");
                Assert.AreEqual("CLOSE", reportpage.GetBtnCloseTxt(), "close Value is not the same");
                reportpage.ClickClose();
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1291
        [Test]
        public void WS_1291()
        {
            if (!DataParser.ReturnExecution("WS_1291"))
                Assert.Ignore();
            else
            {
                GoToMallHomePage mallpage = InitialPage.Go().Logon().ClickLogin().NavigateToRedeemA();
                Assert.AreEqual("Welcome to the Mall!",mallpage.GetWelcomeMsg(),"You are not in the Welcome page");
            }
        }
    }
}