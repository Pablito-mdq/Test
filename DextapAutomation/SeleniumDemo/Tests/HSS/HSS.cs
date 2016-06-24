using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemo.Pages;
using SeleniumDemo.Utils;
using NUnit.Framework;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.LeftMenu.MyRedemption;
using SeleniumDemo.Pages.NominationPage;

namespace SeleniumDemo.Tests.HSS
{
    internal class HSS : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");
        private static string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml",client);

        [Category("Regression")]
        [Category("HSS")]
        //WS-1112
        [Test]
        public void WS_1112()
        {
            if (!DataParser.ReturnExecution("WS_1112"))
                Assert.Ignore();
            else
            {
                string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml",client);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                Assert.AreEqual(" Recognize Someone",home.GetLeftMenuOpts(0),"Link is Broken or not well written");
                NominationHomePage nomination = home.NavigateToNomination();
                Assert.AreEqual(url + "nomination", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = nomination.NavigateToHomePage();
                Assert.AreEqual(" Event Calendar", home.GetLeftMenuOpts(1), "Link is Broken or not well written");
                EventCalendar events = home.NavigateToEventCalendar();
                Assert.AreEqual(url + "event_calendar", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = events.NavigateToHomePage();
                Assert.AreEqual(" Go To Mall", home.GetLeftMenuOpts(2), "Link is Broken or not well written");
                GoToMallHomePage mall = home.NavigateToMall();
                Assert.AreEqual(url + "mall", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = mall.NavigateToHomePage();
                Assert.AreEqual(" My Awards", home.GetLeftMenuOpts(3), "Link is Broken or not well written");
                MyAwards awards = home.NavigateToMyAwards();
                Assert.AreEqual(url + "my_awards", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = awards.NavigateToHomePage();
                Assert.AreEqual(" Pending Approvals", home.GetLeftMenuOpts(4), "Link is Broken or not well written");
                PendingApprovals pending = home.NavigateToPendingApprovals();
                Assert.AreEqual(url + "approval", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = pending.NavigateToHomePage();
                Assert.AreEqual(" My Redemptions", home.GetLeftMenuOpts(5), "Link is Broken or not well written");
                MyRedemptions redemption = home.NavigateToMyRedemptions();
                Assert.AreEqual(url + "my_redemptions", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                home = redemption.NavigateToHomePage();
                
                switch (client)
                {
                    case "HSS":
                    {
                        Assert.AreEqual(" Send Appreciation", home.GetLeftMenuOpts(6), "Link is Broken or not well written");
                        SendAppreciationPage appreciation = home.NavigateToSendAppreciation();
                        Assert.AreEqual(url + "customer_appreciation", home.GetCurrentUrl(), "Url is Broken or not well written or redirects to other pages");
                        break;
                    }
                }
            }
        }
    }
}
