using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.StElizabeth
{
    internal class StElizabethTests : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");
        private static string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml", "StElizabeth");

        [Category("Regression")]
        [Category("StElizabeth")]
        //WS-1157
        [Test]
        public void WS_1157_Sample1()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample1"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1157_Sample1.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage =
                    InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToNominationSpan();
                recognitionPage
                    .SearchEmployeeFoundAngular(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .FillMsg(msg)
                    .ClickNextSprint();
                Assert.AreEqual("I want to Email this award.", recognitionPage.GetDeliverLabel("email"),
                    "Label is not correct");
                Assert.AreEqual("I want to Print this award", recognitionPage.GetDeliverLabel("print"),
                    "Label is not correct");
                recognitionPage.DeliverTypeAngular(printype).ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
            }
        }

        [Category("Regression")]
        [Category("StElizabeth")]
        //WS-1157
        [Test]
        public void WS_1157_Sample2()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample2"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1157_Sample2.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage =
                    InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToNominationSpan();
                recognitionPage
                    .SearchEmployeeFoundAngular(user)
                    .SelectAward(award)
                    .FillMsg(msg)
                    .ClickNextSprint();
                Assert.AreEqual("I want to Email this award.", recognitionPage.GetDeliverLabel("email"),
                    "Label is not correct");
                Assert.AreEqual("I want to Print this award", recognitionPage.GetDeliverLabel("print"),
                    "Label is not correct");
                recognitionPage.DeliverTypeAngular(printype).ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
            }
        }

        [Category("Regression")]
        [Category("StElizabeth")]
        [Category("BAE")]
        //WS-1306
        [Test]
        public void WS_1306()
        {
            if (!DataParser.ReturnExecution("WS_1306"))
                Assert.Ignore();
            else
            {
                GoToMallHomePage mallPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToMall();
                mallPage.CheckOptionPurchaseType("Email (Instant)");
                CompanyGiftCard giftCard = mallPage.SearchCompany("Buffalo").SelectCompany();
                CheckOutPage checkout =
                    giftCard.ClickPlusAmount().ClickAddToCart().ClickGoToCart().ClickCheckOut().ClickNext();
                Assert.AreEqual("This field is required.", checkout.GetErrorMsgFirstName(),
                    "Error msg is not show or incorrect in first name");
                Assert.AreEqual("This field is required.", checkout.GetErrorMsgLastName(),
                    "Error msg is not show or incorrect in last name");
                Assert.AreEqual("This field is required.", checkout.GetErrorMsgAddress(),
                    "Error msg is not show or incorrect in Address");
                Assert.AreEqual("This field is required.", checkout.GetErrorMsgCity(),
                    "Error msg is not show or incorrect in city");
                Assert.AreEqual("This field is required.", checkout.GetErrorMsgZip(),
                    "Error msg is not show or incorrect in Zip code");
                Assert.AreEqual("This field is required.", checkout.GetErrorMsgPhone(),
                    "Error msg is not show or incorrect in phone number");
            }
        }


        [Category("Regression")]
        [Category("StElizabeth")]
        [Category("BAE")]
        //WS-1307
        [Test]
        public void WS_1307()
        {
            if (!DataParser.ReturnExecution("WS_1307"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1307.xml";
                string company = RedeemData.GetRedeemCompany(_file),
                    firstname = RedeemData.GetRedeemFirstName(_file),
                    secondname = RedeemData.GetRedeemSecondName(_file),
                    address = RedeemData.GetRedeemAddress(_file),
                    city = RedeemData.GetRedeemCity(_file),
                    zip = RedeemData.GetRedeemZip(_file),
                    phone = RedeemData.GetRedeemPhone(_file),
                    state = RedeemData.GetRedeemState(_file);
                GoToMallHomePage mallPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToMall();
                mallPage.CheckOptionPurchaseType("Email (Instant)");
                CompanyGiftCard giftCard = mallPage.SearchCompany("Buffalo").SelectCompany();
                CheckOutPage checkout = giftCard.ClickPlusAmount().ClickAddToCart().ClickGoToCart().ClickCheckOut();
                checkout.FillName(firstname)
                    .FillLastName(secondname)
                    .FillAddress(address)
                    .FillCity(city)
                    .SelectState(state)
                    .FillZipCode(zip)
                    .FillPhoneNumber(phone);
                Assert.IsFalse(checkout.CannotEditEmail(), "Email txt field is editable");
                checkout.ClickNext();
                Assert.AreEqual("We got you covered Work Stride", checkout.GetNoCreditCardUseMsg(),
                    "The message is wrong or its possible to use the credit card");
                Assert.AreEqual("Your rewards have covered your balance.\r\nEnjoy your gift.",
                    checkout.GetNoCreditCardUseMsgSubtitle(),
                    "The message is wrong or its possible to use the credit card");
                checkout.ClickNextPayment().ClickCheckOut();
                // BUG not showing error msg 
            }
        }

        [Category("Regression")]
        [Category("StElizabeth")]
        [Category("BAE")]
        //WS-1307
        [Test]
        public void WS_1313()
        {
            if (!DataParser.ReturnExecution("WS_1313"))
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
        public void WS_1315()
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
        public void WS_1356()
        {
            if (!DataParser.ReturnExecution("WS_1356"))
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