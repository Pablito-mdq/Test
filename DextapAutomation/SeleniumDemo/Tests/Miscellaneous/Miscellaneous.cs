using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.MyRedemption;

namespace SeleniumDemo.Tests
{
    class Miscellaneous : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = DataParser.Getclient();
        private static string url = ConfigUtil.ImportConfigURL(string.Format("Resources\\{0}\\Url.xml", client), client);


        [Category("Regression")]
        [Category("BAE")]
        [Category("Textron")]
        [Category("WellCare")]
        [Category("Sprint")]
        [Category("HealthAlliance")]
        //WS-1132
        [Test]
        public void HomePAge_ClienteBackgroundImg_WS_1142()
        {
            if (!DataParser.ReturnExecution("WS_1142"))
                Assert.Ignore();
            else
            {
                LoginPage mainPage = InitialPage.Go();
                Assert.IsTrue(mainPage.IshomePageLoadingRightImg("landingPageGrid1.jpg"),"The background img is not landingPage1.jpg");
                Assert.IsTrue(mainPage.ImgVisible(), "Img does not load correctly");
            }
        }

        [Category("HealthAlliance")]
        //WS-1196
        [Test]
        public void Bugdet_FundFromReciepts_WS_1196()
        {
            if (!DataParser.ReturnExecution("WS_1196"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1196.xml";
                string user = AwardData.GetAwardUserName(_file), msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file), value = AwardData.GetAwardValue(_file), amountvalue= AwardData.GetAwardAmountValue(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file), proxy_name2 = ProxyData.GetProxySecondUserName(_file);
                MainHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage().LoginProxyAsuser().EnterUserNameHealthAlliance(proxy_name).ProxyToMainHomePage();
                NominationHomePage recognitionPage = proxyPage.NavigateToHomePage().NavigateToNomination();
                Thread.Sleep(1500);
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValueOfAward(amountvalue)
                    .SelectValues(value)
                    .FillMsg(msg)
                    .ClickNext()
                    .EmailReward();
                recognitionPage.ClickSendRecognition();
                var proxypage = recognitionPage.ExitProxy().NavigateToAdminHomePage().LoginProxyAsuser().EnterUserNameHealthAlliance(proxy_name2)
                        .ProxyToMainHomePage().ClosePopUp();
                Thread.Sleep(300);
                var amount = proxypage.GetBudget();
                //Fail cannot appear link to switch to see the budget
                PendingApprovals pending = proxypage.NavigateToPendingApprovals();
                Thread.Sleep(300);
            }
        }

        [Category("WellCare")]
        //WS-1325
        [Test]
        public void Service_AnniversarySubmission_WS_1325()
        {
            if (!DataParser.ReturnExecution("WS_1325"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1325.xml";
                string msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    send_type = AwardData.GetAwardDeliverType(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file);
                MainHomePage proxyPage =InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().ClickOptionProxy("Proxy")
                        .EnterUserNameProxySprint2(proxy_name).ProxyToMainHomePageSprint().ClosePopUp();
                Assert.AreEqual("You are proxied in as:" + proxy_name, proxyPage.GetProxyLoginMsgSprint(),
                   "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", proxyPage.GetExitMsg(), "The exit proxy link is not present");
                Step2 step2 = proxyPage.NavigateToEventCalendar().clickSendAniversaryCard();
                var recognitionPage = step2.SelectAward(award).FillMsg(msg).DeliverType(send_type);
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
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
                _file = "Resources\\" + client + "\\TestsData\\WS_317.xml";
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

        [Test]
        public void EventCalendar_BirthDays_WS_1070()
        {
            if (!DataParser.ReturnExecution("WS_1070"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1070.xml";
                username = ProxyData.GetProxyUserName(_file);
                string username2 = ProxyData.GetProxySecondUserName(_file),
                    award = AwardData.GetAwardName(_file),
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
                NominationHomePage nomination =
                    eventPage.clickSendRecognition().SelectAward(award).FillMsg(msg).SelectImgs();
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
        public void EventCalendar_Anniversaries_WS_1084()
        {
            if (!DataParser.ReturnExecution("WS_1084"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1084.xml";
                username = ProxyData.GetProxyUserName(_file);
                string username2 = ProxyData.GetProxySecondUserName(_file),
                    award = AwardData.GetAwardName(_file),
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
                Assert.AreEqual(username2 + "\r\n12 year Anniversary", eventPage.GetNameList(6),
                    username2 + " is not present");
                NominationHomePage nomination =
                    eventPage.clickSendAniversaryCard().SelectAward(award).FillMsg(msg).SelectImgs();
                nomination.EmailReward().ClickSendRecognition();
                Assert.AreEqual("Success!", nomination.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", nomination.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", nomination.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
            }
        }


       
        [Category("Regression")]
        [Category("Sungard")]
        //WS-1112
        [Test]
        public void General_IdentifyIncorrectLinks_WS_1112()
        {
            if (!DataParser.ReturnExecution("WS_1112"))
                Assert.Ignore();
            else
            {
                string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml", client);
                url = url.Substring(0, 28);
                MainHomePage home = InitialPage.Go().EnterId(client).Logon().ClickLogin();
                Assert.AreEqual("Recognize Someone", home.GetLeftMenuOpts(0), "Link is Broken or not well written");
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

       


        [Category("Regression")]
        [Category("BAE")]
        //WS-917
        [Test]
        public void ContactUs_Submission_WS_1431()
        {
            if (!DataParser.ReturnExecution("WS_1431"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1431.xml";
                string firstname = RegisterData.GetRegisterFirstName(_file),
                    lastname = RegisterData.GetRegisterLastName(_file),
                    email = RegisterData.GetRegisterEmail(_file),
                    inquiry = RegisterData.GetInquiryType(_file),
                    msg = RegisterData.GetInquiry(_file);
                HelpHomePage helpPage = InitialPage.Go().Logon().ClickLogin().NavigateToHelp();
                helpPage.EnterFirstName(firstname)
                    .EnterLastName(lastname)
                    .EnterEmail(email)
                    .SelectCountry(inquiry)
                    .EnterInquiry(msg)
                    .ClickSubmit();
                Assert.AreEqual("Your inquiry has been successfully submitted. Please expect a response within 1 - 2 business days.", helpPage.GetSuccessfullMsg(),
                    "The inquiry was not send successfully or the message is wrong");
            }
        }


    }
}
