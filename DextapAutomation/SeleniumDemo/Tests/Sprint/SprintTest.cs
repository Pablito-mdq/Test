using System;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.Sprint
{
    internal class SprintTest : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");
        private static string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml", "Sprint");

        [Category("Regression")]
        [Category("Sprint")]
        [Test]
        //WS_1118
        public void WS_1118()
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
        [Category("Sprint")]
        [Test]
        //WS_1120
        public void WS_1120()
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

        //SPRIN-67
        [Test]
        public void WS_1024()
        {
            if (!DataParser.ReturnExecution("WS_1024"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1024.xml";
                string user = AwardData.GetAwardUserName(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    subAward1 = AwardData.GetAwardSubType1(_file),
                    subAward2 = AwardData.GetAwardSubType2(_file),
                    ccEmail = AwardData.GetAwardCCEmail(_file),
                    futureDate = AwardData.GetAwardFutureDate(_file);
                NominationHomePage recognitionPage =
                    InitialPage.GoSpecial("WS_1024", client, _file)
                        .Logon()
                        .EnterId(client)
                        .ClickLogin()
                        .NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple(user)
                    .ClickNextStep2()
                    .SelectAwardMultiple(award, 0)
                    .SelectSubAwardTypeSprint(subAward1, subAward2)
                    .ClickNextFillCard()
                    .FillEditCardEditor(msg)
                    .ClickNextStep()
                    .EnterUserCCEmail(ccEmail).EnterFutureDate(futureDate).ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognition(),
                    "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelSprint(),
                    "Button finish its not correct write");
                Assert.Fail("Missing steps DUE to bug, ticket name SPRIN-91");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1130
        [Test]
        public void WS_1130()
        {
            if (!DataParser.ReturnExecution("WS_1130"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1130.xml";
                string user = AwardData.GetAwardUserName(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    begindate = AwardData.GetAwardBeginDate(_file),
                    endate = AwardData.GetAwardEndDate(_file),
                    description = AwardData.GetAwardDescription(_file),
                    Criteria = AwardData.GetAwardCriteria(_file),
                    subCriteria = AwardData.GetSubCriteria(_file),
                    value = AwardData.GetAwardAmountValue(_file),
                    ccEmail = AwardData.GetAwardCCEmail(_file),
                    proxyname = AwardData.GetApprovalUserName(_file);
                MainHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxy("Proxy").EnterUserNameProxySprint2(user).ProxyToMainHomePageSprint().ClosePopUp();
                NominationHomePage recognitionPage = proxy.NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple("Brenda Michel")
                    .SearchEmployeeFoundMultiple("Adri Johnson")
                    .SearchEmployeeFoundMultiple("Ada Pitocco")
                    .SearchEmployeeFoundMultiple("Alex Alvarado")
                    .ClickNextStep2()
                    .SelectAwardMultiple(award, 2)
                    .SelectValueOfAwardSprint(value)
                    .EnterBeginDate(begindate)
                    .EnterEndDate(endate)
                    .SelectValues(Criteria)
                    .SelectValues(subCriteria)
                    .FillDescription(description)
                    .FillMsg(msg)
                    .ClickNextSprint()
                    .EnterUserCCEmail(ccEmail).ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognition(),
                    "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelSprint(),
                    "Button finish its not correct write");
                recognitionPage.ExitProxy2();
                Thread.Sleep(1000);
                proxy =
                    proxy.NavigateToAdminHomePageSpan()
                        .ClickOptionProxy("Proxy")
                        .EnterUserNameProxySprint2(proxyname)
                        .ProxyToMainHomePageSprint()
                        .ClosePopUp();
                var pending = proxy.NavigateToPendingApprovals();
                Assert.AreEqual(user, pending.GetFirstUserApproval(), user + " is not present");
                var popUp = pending.ClickThumpsUp();
                Assert.IsTrue(popUp.IsPopUpPresent(), "Pop Up To Approve or Decline was not present");
                popUp.ApproveAllorDeclineAll();
                Assert.AreEqual("Successfully approved!", popUp.GetSuccesfullMsg(), "Successfull message is not present");
                popUp.ClickClose();
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1130
        [Test]
        public void WS_1135()
        {
            if (!DataParser.ReturnExecution("WS_1135"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1135.xml";
                string user = AwardData.GetAwardUserName(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    begindate = AwardData.GetAwardBeginDate(_file),
                    endate = AwardData.GetAwardEndDate(_file),
                    description = AwardData.GetAwardDescription(_file),
                    Criteria = AwardData.GetAwardCriteria(_file),
                    subCriteria = AwardData.GetSubCriteria(_file),
                    value = AwardData.GetAwardAmountValue(_file),
                    ccEmail = AwardData.GetAwardCCEmail(_file),
                    proxyname = AwardData.GetApprovalUserName(_file);
                MainHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxy("Proxy").EnterUserNameProxySprint2(user).ProxyToMainHomePageSprint().ClosePopUp();
                NominationHomePage recognitionPage = proxy.NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple("Brenda Michel")
                    .SearchEmployeeFoundMultiple("Adri Johnson")
                    .SearchEmployeeFoundMultiple("Ada Pitocco")
                    .SearchEmployeeFoundMultiple("Alex Alvarado")
                    .ClickNextStep2()
                    .SelectAwardMultiple(award, 2)
                    .SelectValueOfAwardSprint(value)
                    .EnterBeginDate(begindate)
                    .EnterEndDate(endate)
                    .SelectValues(Criteria)
                    .SelectValues(subCriteria)
                    .FillDescription(description)
                    .FillMsg(msg)
                    .ClickNextSprint()
                    .EnterUserCCEmail(ccEmail).ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognition(),
                    "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelSprint(),
                    "Button finish its not correct write");
                recognitionPage.ExitProxy2();
                Thread.Sleep(1000);
                proxy =
                    proxy.NavigateToAdminHomePageSpan()
                        .ClickOptionProxy("Proxy")
                        .EnterUserNameProxySprint2(proxyname)
                        .ProxyToMainHomePageSprint()
                        .ClosePopUp();
                var pending = proxy.NavigateToPendingApprovals();
                Assert.AreEqual(user, pending.GetFirstUserApproval(), user + " is not present");
                var popUp = pending.ClickThumpsDown();
                Assert.IsTrue(popUp.IsPopUpPresent(), "Pop Up To Approve or Decline was not present");
                popUp.ApproveAllorDeclineAll();
                Assert.AreEqual("Successfully declined!", popUp.GetSuccesfullMsg(), "Successfull message is not present");
                popUp.ClickClose();
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1155
        [Test]
        public void WS_1155()
        {
            if (!DataParser.ReturnExecution("WS_1155"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1155.xml";
                string path = GeneralData.path(_file);
                BulkAward bulk = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionBulk("Bulk Award Upload");
                bulk.UploadFile();
                foreach (char a in path)
                {
                    SendKeys.SendWait(a.ToString());
                    Thread.Sleep(30);
                }
                SendKeys.SendWait("{ENTER}");
                bulk.WaitForFileToUpload();
                Assert.IsTrue(bulk.WasFileSuccessfullyUpload(), "The file was not successfully upload");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]
        //WS-1133
        [Test]
        public void WS_1145()
        {
            if (!DataParser.ReturnExecution("WS_1145"))
                Assert.Ignore();
            else
            {
                MainHomePage mainPage = InitialPage.Go().Logon().ClickLogin();
                Assert.IsTrue(mainPage.GetAllHttpLinkResponses(url), "No all Responses Get an successfully validation");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1177
        [Test]
        public void WS_1177()
        {
            if (!DataParser.ReturnExecution("WS_1177"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1177.xml";
                string user = AwardData.GetAwardUserName(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    subAward1 = AwardData.GetAwardSubType1(_file),
                    subAward2 = AwardData.GetAwardSubType2(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple(user)
                    .ClickNextStep2()
                    .SelectAwardMultiple(award, 0)
                    .SelectSubAwardTypeSprint(subAward1, subAward2)
                    .ClickNextFillCard()
                    .FillEditCardEditor(msg)
                    .ClickNextStep()
                    .ClickNextGeneric();
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognition(),
                    "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelSprint(),
                    "Button finish its not correct write");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1184
        [Test]
        public void WS_1185()
        {
            if (!DataParser.ReturnExecution("WS_1185"))
                Assert.Ignore();
            else
            {
                MainHomePage mainHomePage = InitialPage.Go().Logon().ClickLogin();
                Assert.IsTrue(mainHomePage.IsEveryoneSelected(), "Everyone is not selected in display options");
                mainHomePage.ClickCheers();
                if (mainHomePage.CheersCount() == "-1")
                    mainHomePage.ClickCheers();
                Assert.AreEqual("1", mainHomePage.CheersCount(), "Cheers is not 1");
                mainHomePage.NavigateToRedeem().NavigateToHomePage();
                Assert.AreEqual("1", mainHomePage.CheersCount(), "Cheers is not 1");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1148
        [Test]
        public void WS_1148()
        {
            if (!DataParser.ReturnExecution("WS_1148"))
                Assert.Ignore();
            else
            {
                MainHomePage mainHomePage = InitialPage.Go().Logon().ClickLogin();
                Assert.IsTrue(mainHomePage.IsEveryoneSelected(), "Everyone is not selected in display options");
                int quantComments = Int32.Parse(mainHomePage.CongratsCount());
                mainHomePage.ClickCongrats();
                mainHomePage.AddCongrats("QA Test Submision").SendCongrats();
                Assert.AreEqual("Your message has been sent!", mainHomePage.GetCongratsMsg(),
                    "Congrats msg was not sent");
                Assert.AreEqual(quantComments + 1, Int32.Parse(mainHomePage.CongratsCount()),
                    "Congrats was not plus well 1");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1206
        [Test]
        public void WS_1206()
        {
            if (!DataParser.ReturnExecution("WS_1206"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1206.xml";
                string user = AwardData.GetAwardUserName(_file);
                MainHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxy("Proxy").EnterUserNameProxySprint2(user).ProxyToMainHomePageSprint().ClosePopUp();
                Assert.AreEqual("You are proxied in as:" + user, proxy.GetProxyLoginMsgSprint(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", proxy.GetExitMsg(), "The exit proxy link is not present");
                Assert.IsFalse(proxy.IsAdmLnkPresent(),"Admin link is present");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1206
        [Test]
        public void WS_1204()
        {
            if (!DataParser.ReturnExecution("WS_1204"))
                Assert.Ignore();
            else
            {
                ProxyHomePage admin = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan();
                Assert.IsTrue(admin.IsBulkAwardOptPresent(), "Bulk Award Upload is not present");
                Assert.IsTrue(admin.IsProxyOptPresent(), "Proxy is not present");
                Assert.IsTrue(admin.IsBudgetToolOptPresent(), "Budget tool is not present");
                Assert.IsTrue(admin.IsPendingApprovalsOptPresent(), "Pending Approvals is not present");
                Assert.IsTrue(admin.IsEditRewardCartUserMessageOptPresent(), "Edit Reward Cart User Message is not present");
                Assert.IsTrue(admin.IsProxyManagerOptPresent(), "Proxy Manager is not present");
                Assert.IsTrue(admin.IsDeletedUnusedAwardOptPresent(), "Deleted Unused Award is not present");
                Assert.IsTrue(admin.IsEditPendingAwardsOptPresent(), "Edit Pending Awards is not present");
                Assert.IsTrue(admin.IsDebugRuleOptPresent(), "Debug Rule is not present");
                Assert.IsTrue(admin.IsDebugReportOptPresent(), "Debug Report is not present");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]

        //WS_1208
        [Test]
        public void WS_1208()
        {
            if (!DataParser.ReturnExecution("WS_1208"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1208.xml";
                string user = AwardData.GetAwardUserName(_file);
                MainHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxy("Proxy").EnterUserNameProxySprint2(user).ProxyToMainHomePageSprint().ClosePopUp();
                Assert.AreEqual("You are proxied in as:" + user, proxy.GetProxyLoginMsgSprint(),
                    "The message of proxy login is not correct");
                Assert.AreEqual("Exit Proxy", proxy.GetExitMsg(), "The exit proxy link is not present");
                ProxyHomePage admin = proxy.NavigateToAdminHomePageSpan();
                Assert.IsTrue(admin.IsBulkAwardOptPresent(), "Bulk Award Upload is not present");
                Assert.IsTrue(admin.IsProxyOptPresent(), "Proxy is not present");
                Assert.IsTrue(admin.IsBudgetToolOptPresent(), "Budget tool is not present");
                Assert.IsTrue(admin.IsPendingApprovalsOptPresent(), "Pending Approvals is not present");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]
        //WS-1157
        [Test]
        public void WS_1157_Sample3()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample3"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1157_Sample3.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNominationSpan();
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
        [Category("Sprint")]
        //WS-1157
        [Test]
        public void WS_1157_Sample5()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample5"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\WS_1157_Sample5.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNominationSpan();
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
    }
}