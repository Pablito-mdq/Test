using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.Sprint
{
    class SprintTest  : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        [Category("Regression")]
        [Category("Sprint")]
        [Test]
        //WS_1118
        public void WS_1118()
        {
            if (!Utils.DataParser.ReturnExecution("WS_1118"))
                Assert.Ignore();
            else
            {
            string name = "Foot Locker", deliver = "email";
            GoToMallHomePage mallPage = InitialPage.Go().Logon().ClickLogin().NavigateToRedeem();
            CompanyGiftCard giftCardPage = mallPage.SearchCompany(name).SelectCompany();
            Assert.AreEqual("10",giftCardPage.GetAmount(),"10 is not the default amount");
            giftCardPage.ClickPlusAmount().ClickPlusAmount().ClickPlusAmount();
            Assert.IsTrue(giftCardPage.IsQtyAvailable(),"Quantity field is available");
            CompanyGifCart cartPage =   giftCardPage.ClickAddToCart().ClickGoToCart();
            Assert.IsTrue(cartPage.IsFootLockerAdded(),"FootLocker was not added to the cart");
            CheckOutPage checkout = cartPage.ClickCheckOut();
                checkout.FillName("A")
                    .FillLastName("A")
                    .FillAddress("123 Test");
                Assert.AreEqual("Please enter at least 2 characters.", checkout.GetErrorMsgFirstName(), "The Error Message is not present or show");
                Assert.AreEqual("Please enter at least 2 characters.", checkout.GetErrorMsgLastName(), "The Error Message is not present or show");
             }
        }

        [Category("Regression")]
        [Category("Sprint")]
        [Test]
        //WS_1120
        public void WS_1120()
        {
            if (!Utils.DataParser.ReturnExecution("WS_1120"))
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
             Assert.IsTrue(checkout.IsPaymentOptionAvailable(),"Payment option is not available");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //SPRIN-67
        [Test]
        public void Sprin_67()
        {
            if (!DataParser.ReturnExecution("Sprin_67"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\Sprin_67.xml";
                string user = AwardData.GetAwardUserName(_file),msg =  AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file), subAward1 =  AwardData.GetAwardSubType1(_file),
                    printype = AwardData.GetAwardDeliverType(_file), subAward2 =  AwardData.GetAwardSubType2(_file),
                    ccEmail = AwardData.GetAwardCCEmail(_file),
                    futureDate = AwardData.GetAwardFutureDate(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().EnterId().ClickLogin().NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple(user)
                    .ClickNextStep2()
                    .SelectAwardMultiple(award)
                    .SelectSubAwardType(subAward1,subAward2)
                    .ClickNextFillCard()
                    .FillEditCardEditor(msg)
                    .ClickNextStep()
                    .EnterUserCCEmail(ccEmail).EnterFutureDate(futureDate).ClickNextGeneric();
               Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
               Assert.AreEqual("SEND RECOGNITION",recognitionPage.GetBtnSendRecognition(),"Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", recognitionPage.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
                Assert.Fail("Missing steps DUE to bug, ticket name SPRIN-91");
            }
        }
    }
}
