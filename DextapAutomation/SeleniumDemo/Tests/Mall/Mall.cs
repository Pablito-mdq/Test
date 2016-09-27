using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Pages.LeftMenu.GoToMall;

namespace SeleniumDemo.Tests
{
    class Mall : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();


        [Category("Regression")]
        [Category("BAE")]
        [Category("Cleveland")]
        [Test]
        //WS-65
        public void Mall_LeftPanelFilters_WS_65()
        {
            if (false)
                Assert.Ignore();
            else
            {
                MainHomePage menuPage = InitialPage.Go().Logon().ClickLogin();
                GoToMallHomePage mallPage = menuPage.NavigateToMall();
                Assert.AreEqual(" By Price:", mallPage.GetFilterTitleText(0), "The subtitle is not the right one");
                Assert.AreEqual("  Under $25", mallPage.GetFilterChkTypeByPrice(0),
                    "The category to filter it's wrong labeled");
                Assert.AreEqual("  $25 - $50", mallPage.GetFilterChkTypeByPrice(1),
                    "The category to filter it's wrong labeled");
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
        public void Mall_VerifyPageLoads_WS_61()
        {
            if (!DataParser.ReturnExecution("WS_61"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_61.xml";
                string url = GeneralData.GetUrl(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                home.NavigateToMall();
                Assert.AreEqual(url, home.GetCurrentUrl(), "The URL is not correct");
            }
        }


        [Category("Regression")]
        [Category("BAE")]
        //WS-1189
        [Test]
        public void Mall_WSBrandedCards_WS_1187()
        {
            if (!DataParser.ReturnExecution("WS_1187"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1187.xml";
                string creditcard1 = GeneralData.GetPathCreditCard1Img(_file),
                    creditcard2 = GeneralData.GetPathCreditCard2Img(_file);
                GoToMallHomePage redeem = InitialPage.Go().Logon().ClickLogin().NavigateToRedeemA();
                Assert.AreEqual("Welcome to the Mall!", redeem.GetWelcomeMsg(),
                    "Welcome Msg is not present or well written");
                redeem.SearchCompany("Work");
                Assert.AreEqual(creditcard1, redeem.GetImgFirstCreditCard(), "Credit Card 1 source is not the same");
                Assert.AreEqual(creditcard2, redeem.GetImgSecondCreditCard(), "Credit Card 2 source is not the same");
            }
        }


        [Category("Regression")]
        [Category("BAE")]
        //WS-1202
        [Test]
        public void Mall_BrokenImages_WS_1202()
        {
            if (false)
                Assert.Ignore();
            else
            {
                GoToMallHomePage mall = InitialPage.Go().Logon().ClickLogin().NavigateToRedeemA();
                Assert.IsTrue(mall.AreAllImagesDisplayed(), "No all images all ok Get an successfully validation");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1291
        [Test]
        public void Mall_NonMIlestone_WS_1291()
        {
            if (!DataParser.ReturnExecution("WS_1291"))
                Assert.Ignore();
            else
            {
                GoToMallHomePage mallpage = InitialPage.Go().Logon().ClickLogin().NavigateToRedeemA();
                Assert.AreEqual("Welcome to the Mall!", mallpage.GetWelcomeMsg(), "You are not in the Welcome page");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        [Test]
        public void Mall_MilestoneRecipient_WS_1293()
        {
            if (!DataParser.ReturnExecution("WS_1293"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1293.xml";
                string username = ProxyData.GetProxyUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                ProxyHomePage proxyPage = home.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(username);
                home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + username, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", home.GetExitMsg(), "The exit proxy link is not present");
                Assert.AreEqual("SPEND SERVICE AWARD", home.GetServiceMsg(), "Service spend award msg is not correct");
            }
        }


    }
}
