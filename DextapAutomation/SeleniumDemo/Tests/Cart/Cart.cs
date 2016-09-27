using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{
    internal class Cart : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = DataParser.Getclient();
        private static string url = ConfigUtil.ImportConfigURL(string.Format("Resources\\{0}\\Url.xml", client), client);



        [Category("Regression")]
        [Category("StElizabeth")]
        [Category("BAE")]
        //WS-1307
        [Test]
        public void Cart_DeleteItem_WS_1313()
        {
            if (false)
                Assert.Ignore();
            else
            {
                GoToMallHomePage mallPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToMall();
                mallPage.CheckOptionPurchaseType("Email (Instant)");
                CompanyGiftCard giftCard = mallPage.SearchCompany("Groupon").SelectCompany();
                CompanyGifCart gifcart = giftCard.ClickPlusAmount().ClickAddToCart().ClickGoToCart();
                Assert.IsTrue(gifcart.IsGrouponAdded(), "Groupon was not added");
                gifcart.ClickMinusQuant();
                Thread.Sleep(1000);
                Assert.IsFalse(gifcart.IsGrouponAdded(), "Groupon was not added");
                gifcart.Refresh();
                Assert.IsFalse(gifcart.IsGrouponAdded(), "Groupon was not added");
            }
        }

        [Category("Regression")]
        [Category("StElizabeth")]
        //WS-1315
        [Test]
        public void Cart_PayCalculation_WS_1315()
        {
            if (!DataParser.ReturnExecution("WS_1315"))
                Assert.Ignore();
            else
            {
                GoToMallHomePage mallPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToMall();
                mallPage.CheckOptionPurchaseType("Email (Instant)");
                CompanyGiftCard giftCard = mallPage.SearchCompany("Groupon").SelectCompany();
                CompanyGifCart gifcart = giftCard.ClickPlusAmount().ClickAddToCart().ClickGoToCart();
                int total = gifcart.GetTotal(), quant = gifcart.GetQuantity(), amount = gifcart.GetAmount();
                Assert.AreEqual(total, quant*amount, "Is not equal");
                gifcart.ClickPlusQuant();
                gifcart.Refresh();
                total = gifcart.GetTotal();
                quant = gifcart.GetQuantity();
                amount = gifcart.GetAmount();
                Assert.AreEqual(total, quant*amount, "Is not equal");
            }
        }

        [Category("StElizabeth")]
        //WS-1356
        [Test]
        public void Cart_BackToMall_WS_1356()
        {
            if (false)
                Assert.Ignore();
            else
            {
                CheckOutPage checkout = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToCart();
                GoToMallHomePage mall = checkout.ClickBackToMall();
                Assert.AreEqual(url + "mall#/", mall.GetCurrentUrl(),"You are not stand in the mall page");
            }
        }

    }
}