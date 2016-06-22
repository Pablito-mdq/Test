using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.Login;
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


       /* [Test]
        //WS-57
        public void WorkStride_Add_Product_to_Cart()
        {
           if (!Utils.DataParser.ReturnExecution("WorkStride_Add_Product_to_Cart"))
                Assert.Ignore();
            else
            {
            string name = "Foot Locker", deliver = "email";
            GoToMallHomePage mallPage = InitialPage.Go().Logon().ClickLogin().NavigateToMall();
            CompanyGiftCard giftCardPage = mallPage.SearchCompany(name).SelectCompany();
            Assert.AreEqual("Email (Instant)", giftCardPage.GetDeliverMethod("email"), "The deliver method is not well written");
            Assert.AreEqual("Mail (A Few Days)", giftCardPage.GetDeliverMethod("person"), "The deliver method is not well written");
            giftCardPage.SelectDeliverMethod(deliver);
            Assert.AreEqual("10",giftCardPage.GetAmount(),"10 is not the default amount");
            giftCardPage.ClickPlusAmount().ClickPlusAmount().ClickPlusAmount();
            Assert.IsTrue(giftCardPage.IsQtyAvailable(),"Quantity field is available");
          }
        }*/
    /*[Category("Regression")]
    [Category("BAE")]
    [Category("Cleveland")]
    [Test]
        //WS-65
        public void WorkStride_Search_Filters()
        {
          if (!Utils.DataParser.ReturnExecution("WorkStride_Search_Filters"))
                Assert.Ignore();
            elseWorkStride_Search_Filters
            {
            LoginPage loginPage = InitialPage.Go().Logon();
            MainHomePage menuPage = loginPage.ClickLogin();
            GoToMallHomePage mallPage = menuPage.NavigateToMall();
            Assert.AreEqual(" By Price:",mallPage.GetFilterTitleText(0),"The subtitle is not the right one");
            Assert.AreEqual("  Under $25",mallPage.GetFilterChkTypeByPrice(0),"The category to filter it's wrong labeled");
            Assert.AreEqual("  $25 - $50", mallPage.GetFilterChkTypeByPrice(1), "The category to filter it's wrong labeled");
            Assert.AreEqual("  $50 - $100", mallPage.GetFilterChkTypeByPrice(2), "The category to filter it's wrong labeled");
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
            Assert.AreEqual("  Travel & Entertainment", mallPage.GetFilterChkTypeByCategory(31), "The category to filter it's wrong labeled");
         }
        }*/

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
                Assert.AreEqual(url,home.GetCurrentUrl(),"The URL is not correct");
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
                NominationHomePage recognitionPage =home.NavigateToNomination();
                //SCENARIO 1
                recognitionPage.SearchEmployeeFound(username);
                recognitionPage.ClickEdit();
                Assert.IsTrue(recognitionPage.BringToStep1(),"You didnt go back to step 1");
                //SCENARIO 2
                recognitionPage = home.NavigateToNomination();
                recognitionPage.ClickMultipleRecipients().SearchEmployeeFoundMultiple(username).SearchEmployeeFoundMultiple("John");
                recognitionPage.ClickNextGeneric().ClickEdit().ClickRemove(0);
                Assert.IsFalse(recognitionPage.IsFirstUserAddedPresent(username),"First User still in the list selected");

            }
        }
        
        [Category("Regression")]
        [Category("BAE" )]
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
                Assert.AreEqual("First Name",registerPage.GetName("First Name"),"First Name is now well spell");
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
                Assert.AreEqual("Success!\r\nWe found you. Check your inbox at " + email + " for a link to finish registration. Thank you!",registerPage.GetSuccessMsg(),"Message is not the expected");
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
    }
}