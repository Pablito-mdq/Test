using NUnit.Framework;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.LeftMenu.MyRedemption;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;
using SeleniumDemo.Tests.HSS;


namespace SeleniumDemo.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [Category("Regression")]
    class HomePageTest : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();

        [Category("Regression")]
        [Category("BAE")]
        [Test]
        public void HomePage_LeftNavigationBar_WS_1302()
        {
            if (!DataParser.ReturnExecution("WS_1302"))
                Assert.Ignore();
            else
            {
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                Assert.IsTrue(home.IsMenuArrowExpanded(), "Arrow is not expanded to see the links");
            }
        }

        [Category("Regression")]
        [Category("HSS")]
        [Category("Pinnacol")]
        [Category("BAE")]
        [Category("Textron")]
        [Category("Akron")]
        [Category("GreatExpressions")]
        [Category("UC")]
        [Category("Eurest")]
        [Category("Sprint")]
        [Category("TRU")]
        [Category("Shawcor")]
        [Category("HealthAlliance")]
        [Category("WesternConnecticut")]
        //WS-1112
        [Test]
        public void General_IdentifyIncorrectLinks_WS_1112()
        {
            if (!DataParser.ReturnExecution("WS_1112"))
                Assert.Ignore();
            else
            {
                string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml", client);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                switch (client)
                {
                    case "HSS":
                        {
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNomination();
                            Assert.AreEqual(url + "nomination", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                            EventCalendar events = home.NavigateToEventCalendar();
                            Assert.AreEqual(url + "event_calendar", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = events.NavigateToHomePage();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" Pending Approvals", home.GetLeftMenuOpts(4),
                                "Link is Broken or not well written");
                            PendingApprovals pending = home.NavigateToPendingApprovals();
                            Assert.AreEqual(url + "approval", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = pending.NavigateToHomePage();
                            Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                            MyRedemptions redemption = home.NavigateToMyRedemptions();
                            Assert.AreEqual(url + "my_redemptions", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = redemption.NavigateToHomePage();
                            Assert.AreEqual(" Send Appreciation", home.GetLeftMenuOpts(6),
                                "Link is Broken or not well written");
                            SendAppreciationPage appreciation = home.NavigateToSendAppreciation();
                            Assert.AreEqual(url + "customer_appreciation", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                    case "Pinnacol":
                        {
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNominationSpan();
                            Assert.AreEqual(url + "nomination#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                            EventCalendar events = home.NavigateToEventCalendar();
                            Assert.AreEqual(url + "event_calendar#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = events.NavigateToHomePage();
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" Pending Approvals", home.GetLeftMenuOpts(4),
                                "Link is Broken or not well written");
                            PendingApprovals pending = home.NavigateToPendingApprovals();
                            Assert.AreEqual(url + "approval#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }

                    case "Textron":
                    case "Eurest":
                    case "BAE":
                        {
                            switch (client)
                            {
                                case "Textron":
                                    url = url.Substring(0, 39);
                                    break;
                            }
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNomination();
                            Assert.AreEqual(url + "nomination", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                            EventCalendar events = home.NavigateToEventCalendar();
                            Assert.AreEqual(url + "event_calendar", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = events.NavigateToHomePage();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" Pending Approvals", home.GetLeftMenuOpts(4),
                                "Link is Broken or not well written");
                            PendingApprovals pending = home.NavigateToPendingApprovals();
                            Assert.AreEqual(url + "approval", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = pending.NavigateToHomePage();
                            Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                            MyRedemptions redemption = home.NavigateToMyRedemptions();
                            Assert.AreEqual(url + "my_redemptions", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                    case "Akron":
                        {
                            Assert.AreEqual(" Recognize Caregiver", home.GetLeftMenuOpts(7),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNominationCaregiver();
                            Assert.AreEqual(url + "nomination", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                            EventCalendar events = home.NavigateToEventCalendar();
                            Assert.AreEqual(url + "event_calendar", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = events.NavigateToHomePage();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                            MyRedemptions redemption = home.NavigateToMyRedemptions();
                            Assert.AreEqual(url + "my_redemptions", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = redemption.NavigateToHomePage();
                            Assert.AreEqual(" Social Stream", home.GetLeftMenuOpts(8), "Link is Broken or not well written");
                            SocialStreamHomePage socialStream = home.NavigateToSocialStream();
                            Assert.AreEqual(url + "social_stream", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = socialStream.NavigateToHomePage();
                            Assert.AreEqual(" My Activity", home.GetLeftMenuOpts(9), "Link is Broken or not well written");
                            MyActivityHomePage myActivity = home.NavigateToMyActivity();
                            Assert.AreEqual(url + "my_activities", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = myActivity.NavigateToHomePage();
                            Assert.AreEqual(" View Hierarchy", home.GetLeftMenuOpts(10),
                                "Link is Broken or not well written");
                            ViewHierarchyHomePage hierarchy = home.NavigateToViewHierarchy();
                            Assert.AreEqual(url + "hierarchy", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = hierarchy.NavigateToHomePage();
                            Assert.AreEqual(" Recognition Training", home.GetLeftMenuOpts(11),
                                "Link is Broken or not well written");
                            TrainingHomePage training = home.NavigateToTraining();
                            Assert.AreEqual(url + "videos", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                    case "GreatExpressions":
                        {
                            url = url.Substring(0, 36);
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNomination();
                            Assert.AreEqual(url + "nomination", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" My Pending Approvals", home.GetLeftMenuOpts(4),
                                "Link is Broken or not well written");
                            PendingApprovals pending = home.NavigateToPendingApprovals();
                            Assert.AreEqual(url + "approval", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = pending.NavigateToHomePage();
                            Assert.AreEqual(" View Hierarchy", home.GetLeftMenuOpts(10),
                                "Link is Broken or not well written");
                            ViewHierarchyHomePage hierarchy = home.NavigateToViewHierarchy();
                            Assert.AreEqual(url + "hierarchy", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                    case "UC":
                        {
                            url = url.Substring(0, 32);
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNomination();
                            Assert.AreEqual(url + "nomination", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" My Activity", home.GetLeftMenuOpts(9), "Link is Broken or not well written");
                            MyActivityHomePage myActivity = home.NavigateToMyActivity();
                            Assert.AreEqual(url + "my_activities", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = myActivity.NavigateToHomePage();
                            Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                            MyRedemptions redemption = home.NavigateToMyRedemptions();
                            Assert.AreEqual(url + "my_redemptions", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = redemption.NavigateToHomePage();
                            Assert.AreEqual(" Report Builder", home.GetLeftMenuOpts(12),
                                "Link is Broken or not well written");
                            ReportBuilderHomePage report = home.NavigateToReportBuilder();
                            Assert.AreEqual(url + "report_builder", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                    case "TRU":
                    case "Shawcor":
                        {
                            switch (client)
                            {
                                case "TRU":
                                    url = url.Substring(0, 38);
                                    break;
                            }
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNominationSprint();
                            Assert.AreEqual(url + "nomination#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                            EventCalendar events = home.NavigateToEventCalendar();
                            Assert.AreEqual(url + "event_calendar#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = events.NavigateToHomePage();
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" Pending Approvals", home.GetLeftMenuOpts(4),
                                "Link is Broken or not well written");
                            PendingApprovals pending = home.NavigateToPendingApprovals();
                            Assert.AreEqual(url + "approval#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                            MyRedemptions redemption = home.NavigateToMyRedemptions();
                            Assert.AreEqual(url + "my_redemptions#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                    case "Sprint":
                        {
                            url = url.Substring(0, 35);
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNominationSprint();
                            Assert.AreEqual(url + "ng#/recognize", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                            EventCalendar events = home.NavigateToEventCalendar();
                            Assert.AreEqual(url + "ng#/event_calendar", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = events.NavigateToHomePage();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" Pending Approvals", home.GetLeftMenuOpts(4),
                                "Link is Broken or not well written");
                            PendingApprovals pending = home.NavigateToPendingApprovals();
                            Assert.AreEqual(url + "ng#/approval", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                            MyRedemptions redemption = home.NavigateToMyRedemptions();
                            Assert.AreEqual(url + "my_redemptions#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                    case "HealthAlliance":
                        {
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNominationSprint();
                            Assert.AreEqual(url + "nomination", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" Pending Approvals", home.GetLeftMenuOpts(4),
                                "Link is Broken or not well written");
                            PendingApprovals pending = home.NavigateToPendingApprovals();
                            Assert.AreEqual(url + "approval", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                            MyRedemptions redemption = home.NavigateToMyRedemptions();
                            Assert.AreEqual(url + "my_redemptions", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                    case "WesternConnecticut":
                        {
                            home.ExpandMenuPinnacol();
                            Assert.AreEqual(" Recognize Someone", home.GetLeftMenuOpts(0),
                                "Link is Broken or not well written");
                            NominationHomePage nomination = home.NavigateToNominationSprint();
                            Assert.AreEqual(url + "nomination#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = nomination.NavigateToHomePage();
                            Assert.AreEqual(" Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                            EventCalendar events = home.NavigateToEventCalendar();
                            Assert.AreEqual(url + "event_calendar#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = events.NavigateToHomePage();
                            Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                            GoToMallHomePage mall = home.NavigateToMall();
                            Assert.AreEqual(url + "mall#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = mall.NavigateToHomePage();
                            Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                            MyAwards awards = home.NavigateToMyAwards();
                            Assert.AreEqual(url + "my_awards#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" Pending Approvals", home.GetLeftMenuOpts(4),
                                "Link is Broken or not well written");
                            PendingApprovals pending = home.NavigateToPendingApprovals();
                            Assert.AreEqual(url + "approval#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                            MyRedemptions redemption = home.NavigateToMyRedemptions();
                            Assert.AreEqual(url + "my_redemptions#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            home = awards.NavigateToHomePage();
                            Assert.AreEqual(" My Activity", home.GetLeftMenuOpts(9), "Link is Broken or not well written");
                            MyActivityHomePage myActivity = home.NavigateToMyActivity();
                            Assert.AreEqual(url + "my_activities#/", home.GetCurrentUrl(),
                                "Url is Broken or not well written or redirects to other pages");
                            break;
                        }
                }
            }
        }

        [Category("HealthAlliance")]
        [Category("WellCare")]
        [Category("Pinnacol")]
        [Category("BAE")]
        [Category("StElizabeth")]
        //WS-1359
        [Test]
        public void WS_1359()
        {
            if (!DataParser.ReturnExecution("WS_1359"))
                Assert.Ignore();
            else
            {
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();

                switch (client)
                {
                    case "HSS":
                        {
                            var promobox = home.GetPromoBoxHref("Left");
                            home.ClickPromoBoxBtn("Left");
                            Assert.AreEqual(promobox, home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                    case "WellCare":
                        {
                            var promobox = home.GetPromoBoxHref("Left");
                            home.ClickPromoBoxBtn("Left");
                            Assert.AreEqual(promobox + "#/", home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                    case "Pinnacol":
                        {
                            var promobox = home.GetPromoBoxHrefAngular("Left");
                            home.ClickPromoBoxBtnAngular("Left");
                            Assert.AreEqual(promobox + "#/", home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                    case "BAE":
                        {
                            var promobox = home.GetPromoBoxHref("Left");
                            home.ClickPromoBoxBtn("Left");
                            Assert.AreEqual(promobox, home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                    case "StElizabeth":
                        {
                            var promobox = home.GetPromoBoxHrefAngular("Left");
                            home.ClickPromoBoxBtnAngular("Left");
                            Assert.AreEqual(promobox + "#/", home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                }
            }
        }

        [Category("HealthAlliance")]
        [Category("WellCare")]
        [Category("Pinnacol")]
        [Category("BAE")]
        [Category("StElizabeth")]
        //WS-1359
        [Test]
        public void WS_1360()
        {
            if (!DataParser.ReturnExecution("WS_1360"))
                Assert.Ignore();
            else
            {
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();

                switch (client)
                {
                    case "HSS":
                        {
                            var promobox = home.GetPromoBoxHref("Right");
                            home.ClickPromoBoxBtn("Right");
                            Assert.AreEqual(promobox, home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                    case "WellCare":
                        {
                            var promobox = home.GetPromoBoxHref("Right");
                            home.ClickPromoBoxBtn("Right");
                            Assert.AreEqual(promobox, home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                    case "Pinnacol":
                        {
                            var promobox = home.GetPromoBoxHrefAngular("Right");
                            home.ClickPromoBoxBtnAngular("Right");
                            Assert.AreEqual(promobox + "#/", home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                    case "BAE":
                        {
                            var promobox = home.GetPromoBoxHref("Right");
                            home.ClickPromoBoxBtn("Right");
                            Assert.AreEqual(promobox, home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                    case "StElizabeth":
                        {
                            var promobox = home.GetPromoBoxHrefAngular("Right");
                            home.ClickPromoBoxBtnAngular("Right");
                            Assert.AreEqual(promobox, home.GetCurrentUrl(), "The urls are not the same");
                            break;
                        }
                }
            }
        }
        /// <summary>
        /// WS_XXX
        /// </summary>
        /// 
        /*
        [Test]
        public void WS_120()
        {
            if (!Utils.DataParser.ReturnExecution("WS_120"))
                Assert.Ignore();
            else
            {
                string option = "Relevant to Me", option1 = "Everyone", option2 = "Following", option3, option4;
                MainHomePage mainPage = InitialPage.Go().Logon().ClickLogin().ClickDisplayOptions();
                Assert.AreEqual(option, mainPage.GetShowOptTxt(option), "The label option is not the correct");
                Assert.AreEqual(option1, mainPage.GetShowOptTxt(option1), "The label option is not the correct");
                Assert.AreEqual(option2, mainPage.GetShowOptTxt(option2), "The label option is not the correct");
                option = "Anniversary";
                option1 = "Recognition";
                option2 = "New Hires";
                option3 = "Birthday";
                option4 = "First Time Login";
                Assert.AreEqual(option, mainPage.GetShowOptTxt(option), "The user exists or the msg is not the correct");
                Assert.AreEqual(option1, mainPage.GetShowOptTxt(option1),
                    "The user exists or the msg is not the correct");
                Assert.AreEqual(option2, mainPage.GetShowOptTxt(option2),
                    "The user exists or the msg is not the correct");
                Assert.AreEqual(option3, mainPage.GetShowOptTxt(option3),
                    "The user exists or the msg is not the correct");
                Assert.AreEqual(option4, mainPage.GetShowOptTxt(option4),
                    "The user exists or the msg is not the correct");
                Assert.IsTrue(mainPage.IDatePickerAvailable(), "Date picker is not available");
            }
        }*/
    }
}
