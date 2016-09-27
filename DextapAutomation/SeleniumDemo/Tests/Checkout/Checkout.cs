using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.VisaCenter;
using SeleniumDemo.Utils;
using SeleniumDemo.Pages.LeftMenu.GoToMall;

namespace SeleniumDemo.Tests
{ 
    class Checkout : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();

        [Category("Regression")]
        [Category("Quantum")]
        //WS_1273
        
        [Test]
        public void VisaCard_ReloadWithoutBalance_WS_1273()
        {
            if (!DataParser.ReturnExecution("WS_1273"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1273.xml";
                string proxy_name = ProxyData.GetProxyUserName(_file);
                 MainHomePage home = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageLi().ClickOptionProxy("Proxy")
                    .EnterUserNameProxySprint2(proxy_name).ClickProxyBtn();
                Thread.Sleep(1500);
                Assert.AreEqual("0.00", home.GetRewardsBalance(),
                    "The rewards balance is not 0");
                VisaCenterHomePage visaPage = home.NavigateToVisaCenter();
                Assert.IsTrue(visaPage.IsSubmitAClaimPresent(),"Option is not present");
                Assert.IsFalse(visaPage.IsReloadYourCardPresent(),"Reload your card option is present");
                Assert.IsFalse(visaPage.IsCheckVisaCardBalance(), "Check Visa Card Balance option is present");
            }
        }

        [Category("Regression")]
        [Category("Quantum")]
        //WS_1278

        [Test]
        public void VisaCard_ReloadWithBalance_WS_1279()
        {
            if (!DataParser.ReturnExecution("WS_1279"))
                Assert.Ignore();
            else
            {
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                Thread.Sleep(1500);
                Assert.LessOrEqual("25.00", home.GetRewardsBalance(),
                    "The rewards balance is less than $25");
                VisaCenterHomePage visaPage = home.NavigateToVisaCenter();
                Assert.IsFalse(visaPage.IsSubmitAClaimPresent(), "Option is not present");
                Assert.IsTrue(visaPage.IsReloadYourCardPresent(), "Reload your card option is present");
                Assert.IsTrue(visaPage.IsCheckVisaCardBalance(), "Check Visa Card Balance option is present");
                var balance = visaPage.GetBalance();
                Assert.IsTrue(visaPage.IsAmountFieldAvl(),"Amount field is not available");
                visaPage.EnterAmount("100").ClickReloadCard();
                Assert.AreEqual(balance - 100,visaPage.GetBalance(),"Balance was not right decresing the amount");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-1201
        [Test]
        public void CheckOut_InsufficientFunds_WS_1199()
        {
            if (!DataParser.ReturnExecution("WS_1199"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1199.xml";
                string company = RedeemData.GetRedeemCompany(_file),
                    creditcardnumber = RedeemData.GetRedeemCreditCardNumber(_file)
                    ,
                    creditcardname = RedeemData.GetRedeemCreditCardName(_file),
                    creditcardexpiremonth = RedeemData.GetRedeemCreditCardExpireMonth(_file),
                    creditcardexpireyear = RedeemData.GetRedeemCreditCardExpireYear(_file)
                    ,
                    creditcardCDI = RedeemData.GetRedeemCreditCardCDI(_file),
                    firstname = RedeemData.GetRedeemFirstName(_file),
                    secondname = RedeemData.GetRedeemSecondName(_file),
                    address = RedeemData.GetRedeemAddress(_file),
                    city = RedeemData.GetRedeemCity(_file),
                    zip = RedeemData.GetRedeemZip(_file),
                    phone = RedeemData.GetRedeemPhone(_file),
                    state = RedeemData.GetRedeemState(_file);
                MainHomePage mall = InitialPage.Go().Logon().ClickLogin();
                var gif = mall.NavigateToRedeemA().SearchCompany(company);
                Assert.AreEqual("Amazon.com", gif.GetGifCardTitle(), "The gif card is not amazon");
                var gifcard = gif.SelectCompany().ClickPlusAmount().ClickPlusQuantity(20).ClickAddToCart();
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
                checkout.ClickNext().FillCreditCardNumber(creditcardnumber)
                    .FillCreditCardName(creditcardname)
                    .SelectExpireDate(creditcardexpiremonth, creditcardexpireyear)
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
        public void CheckOut_InssuficientRewardsFunds_WS_1198()
        {
            if (!DataParser.ReturnExecution("WS_1198"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1198.xml";
                string company = RedeemData.GetRedeemCompany(_file),
                    firstname = RedeemData.GetRedeemFirstName(_file),
                    secondname = RedeemData.GetRedeemSecondName(_file),
                    address = RedeemData.GetRedeemAddress(_file),
                    city = RedeemData.GetRedeemCity(_file),
                    zip = RedeemData.GetRedeemZip(_file),
                    phone = RedeemData.GetRedeemPhone(_file),
                    state = RedeemData.GetRedeemState(_file);
                MainHomePage mall = InitialPage.Go().Logon().ClickLogin();
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
        [Category("Sprint")]
        [Test]
        //WS_1120
        public void Checkout_ShippingValidateFullNamePT2_WS_1120()
        {
            if (!DataParser.ReturnExecution("WS_1120"))
                Assert.Ignore();
            else
            {
                string name = "Foot Locker", deliver = "email";
                GoToMallHomePage mallPage = InitialPage.Go().Logon().ClickLogin().NavigateToRedeem();
                CompanyGiftCard giftCardPage = mallPage.SearchCompany(name).SelectCompany();
                Assert.AreEqual("10", giftCardPage.GetAmount(), "10 is not the default amount");
                giftCardPage.ClickPlusAmount().ClickPlusAmount().ClickPlusAmount();
                Assert.IsTrue(giftCardPage.IsQtyAvailable(), "Quantity field is available");
                CompanyGifCart cartPage = giftCardPage.ClickAddToCart().ClickGoToCart();
                Assert.IsTrue(cartPage.IsFootLockerAdded(), "FootLocker was not added to the cart");
                CheckOutPage checkout = cartPage.ClickCheckOut();
                //SCENARIO B
                checkout.FillName("Test")
                    .FillLastName("Test")
                    .FillAddress("123 Test Street")
                    .FillCity("Test")
                    .FillZipCode("11101")
                    .FillPhoneNumber("111 111 1111")
                    .ClickNext();
                Assert.IsTrue(checkout.IsPaymentOptionAvailable(), "Payment option is not available");
            }
        }


        [Category("Regression")]
        [Category("Sprint")]
        [Test]
        //WS_1118
        public void Checkout_ShippingValidateFullNamePT1_WS_1118()
        {
            if (!DataParser.ReturnExecution("WS_1118"))
                Assert.Ignore();
            else
            {
                string name = "Foot Locker", deliver = "email";
                GoToMallHomePage mallPage = InitialPage.Go().Logon().ClickLogin().NavigateToRedeem();
                CompanyGiftCard giftCardPage = mallPage.SearchCompany(name).SelectCompany();
                Assert.AreEqual("10", giftCardPage.GetAmount(), "10 is not the default amount");
                giftCardPage.ClickPlusAmount().ClickPlusAmount().ClickPlusAmount();
                Assert.IsTrue(giftCardPage.IsQtyAvailable(), "Quantity field is available");
                CompanyGifCart cartPage = giftCardPage.ClickAddToCart().ClickGoToCart();
                Assert.IsTrue(cartPage.IsFootLockerAdded(), "FootLocker was not added to the cart");
                CheckOutPage checkout = cartPage.ClickCheckOut();
                checkout.FillName("A")
                    .FillLastName("A")
                    .FillAddress("123 Test");
                Assert.AreEqual("Please enter at least 2 characters.", checkout.GetErrorMsgFirstName(),
                    "The Error Message is not present or show");
                Assert.AreEqual("Please enter at least 2 characters.", checkout.GetErrorMsgLastName(),
                    "The Error Message is not present or show");
            }
        }

        [Category("Regression")]
        [Category("StElizabeth")]
        [Category("BAE")]
        //WS-1306
        [Test]
        public void CheckOut_NoAddresValidation_WS_1306()
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
        public void CheckOut_WrongZip_WS_1307()
        {
            if (!DataParser.ReturnExecution("WS_1307"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1307.xml";
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
        [Category("Sungard")]
        //WS-1201
        [Test]
        public void CheckOut_UseSufficientFunds_WS_1198()
        {
            if (!DataParser.ReturnExecution("WS_1198"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1198.xml";
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



    }
}
