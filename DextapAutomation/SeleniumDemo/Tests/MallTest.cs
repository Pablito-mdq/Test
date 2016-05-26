using System;
using NUnit.Framework;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.LeftMenu.GoToMall;

namespace SeleniumDemo.Tests
{
    [Category("Regression")]
    [Category("BAE")]
    [Category("Cleveland")]
    class MallTest : WorkStrideBaseTest<LoginPage>
    {

        [Test]
        public void WS_65()
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

        [Test] 
        public void WS_57()
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
    }
}
