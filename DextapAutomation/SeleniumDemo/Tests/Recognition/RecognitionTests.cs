using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{ 
    class Recognition : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = DataParser.Getclient();
        private static string url = ConfigUtil.ImportConfigURL(string.Format("Resources\\{0}\\Url.xml", client), client);


        /// <summary>
        /// 
        /// </summary>
        [Category("Regression")]
        [Category("Akron")]
        //WS-218
        [Test]
        public void Recognition_AwardDeliveryTypes_WS_218()
        {
            if (!DataParser.ReturnExecution("WS_218"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_218.xml";
                AwardData.GetAwardImpact(_file);
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    amount = AwardData.GetAwardAmountValue(_file), printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNomination();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValueOfAward(amount)
                    .SelectValues(value)
                    .FillMsg(msg)
                    .FillReason(reason).ClickNext();
                Assert.AreEqual("I want to Email this award.", recognitionPage.GetDeliverLabel("email"),
                    "Label is not correct");
                Assert.AreEqual("I want to print this award.", recognitionPage.GetDeliverLabel("print"),
                    "Label is not correct");
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", recognitionPage.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
            }
        }
        [Category("Regression")]
        [Category("Akron")]
        //WS-956
        [Test]
        public void Recognition_AkronNonMonetary_WS_956()
        {
            if (!DataParser.ReturnExecution("WS_956"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_956.xml";
                AwardData.GetAwardImpact(_file);
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    amount = AwardData.GetAwardAmountValue(_file), printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                proxy_name = ProxyData.GetProxyUserName(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNomination();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValueOfAward(amount)
                    .SelectValues(value)
                    .FillMsg(msg)
                    .FillReason(reason).ClickNext();
                Assert.AreEqual("I want to email this award.", recognitionPage.GetDeliverLabel("email"),
                    "Label is not correct");
                Assert.AreEqual("I want to print this award.", recognitionPage.GetDeliverLabel("print"),
                    "Label is not correct");
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", recognitionPage.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
                ProxyHomePage proxyPage = recognitionPage.NavigateToAdminHomePage().LoginProxyAsuser();
                proxyPage.EnterUserName(proxy_name);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(award, awards.GetAwardName(1, 5), "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 8);
            }
        }

        [Category("Regression")]
        [Category("Akron")]
        //WS-218
        [Test]
        public void Recognition_UploadAttachments_WS_1166_Sample1()
        {
            if (!DataParser.ReturnExecution("WS_1166"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1166.xml";
                AwardData.GetAwardImpact(_file);
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    secondvalue = AwardData.GetAwardSecondValue(_file),
                    file_name = GeneralData.GetFileName(_file),
                    path_file_wrong = GeneralData.GetPathWrongFile(_file).Trim(),
                    reason = AwardData.GetAwardMessage(_file),
                    path_file = GeneralData.GetPathFile(_file).Trim(),
                    proxy_name = ProxyData.GetProxyUserName(_file);

                //Scenario 1
                NominationHomePage recognitionPage =
                    InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage().LoginProxyAsuser()
                        .EnterUserName(proxy_name).ProxyToMainHomePage().ClosePopUp().NavigateToNomination();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .SelectValues(secondvalue)
                    .FillReason(reason);
                recognitionPage.ClickUploadFile();
                foreach (char a in path_file)
                {
                    SendKeys.SendWait(a.ToString());
                    Thread.Sleep(30);
                }
                SendKeys.SendWait("{ENTER}");
                Assert.IsTrue(recognitionPage.WasFileUploadedCorrectly(file_name), "The file was not upload");
            }
        }

        [Category("Regression")]
        [Category("Akron")]
        //WS-218
        [Test]
        public void Recognition_UploadAttachments_WS_1166_Sample2()
        {
            if (!DataParser.ReturnExecution("WS_1166"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1166.xml";
                AwardData.GetAwardImpact(_file);
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    secondvalue = AwardData.GetAwardSecondValue(_file),
                    file_name = GeneralData.GetFileName(_file),
                    path_file_wrong = GeneralData.GetPathWrongFile(_file).Trim(),
                    reason = AwardData.GetAwardMessage(_file),
                    path_file = GeneralData.GetPathFile(_file).Trim(),
                proxy_name = ProxyData.GetProxyUserName(_file);
                //Scenario 2
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage().LoginProxyAsuser()
                .EnterUserName(proxy_name).ProxyToMainHomePage().ClosePopUp().NavigateToNomination();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .SelectValues(secondvalue)
                    .FillReason(reason);
                recognitionPage.ClickUploadFile();
                foreach (char a in path_file_wrong)
                {
                    SendKeys.SendWait(a.ToString());
                    Thread.Sleep(30);
                }
                SendKeys.SendWait("{ENTER}");
                Assert.AreEqual("You can't upload files of this type.", recognitionPage.GetErrorMsguploadFile(), "The file was upload correctly or the msg is not right");
            }
        }

        [Category("Regression")]
        [Category("Akron")]
        //WS-218
        [Test]
        public void Recognition_UploadAttachments_WS_1166_Sample3()
        {
            if (!DataParser.ReturnExecution("WS_1166"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1166.xml";
                AwardData.GetAwardImpact(_file);
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    secondvalue = AwardData.GetAwardSecondValue(_file),
                    file_name = GeneralData.GetFileName(_file),
                    reason = AwardData.GetAwardMessage(_file),
                    path_file = GeneralData.GetPathFile(_file).Trim(),
                proxy_name = ProxyData.GetProxyUserName(_file);
                //Scenario 2
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage().LoginProxyAsuser()
                .EnterUserName(proxy_name).ProxyToMainHomePage().ClosePopUp().NavigateToNomination();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .SelectValues(secondvalue)
                    .FillReason(reason);
                recognitionPage.ClickUploadFile();
                for (var i = 0; i < 5; i++)
                {
                    foreach (char a in path_file)
                    {
                        SendKeys.SendWait(a.ToString());
                        Thread.Sleep(30);
                    }
                    SendKeys.SendWait("{ENTER}");
                }
                Assert.AreEqual("You can not upload any more files", recognitionPage.GetErrorMsgupload5Files(), "The file was upload correctly or the msg is not right");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-921
        [Test]
        public void Recognition_ApprovalNonMon_WS_921()
        {
            if (!DataParser.ReturnExecution("WS_921"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_921.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    value = AwardData.GetAwardValue(_file),
                    amount = AwardData.GetAwardAmountValue(_file),
                    impact = AwardData.GetAwardImpact(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(proxy_name);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                NominationHomePage recognitionPage = home.NavigateToNomination();
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .FillMsg(msg);
                if (reason != "")
                    recognitionPage.FillReason(reason);
                recognitionPage.ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                    "The message is not ready to send");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE", recognitionPage.GetBtnRecognizOtherLabel(),
                    "Button finish its not correct write");
                AdminHomePage proxy = recognitionPage.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(user).ProxyToMainHomePage();
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(award, awards.GetAwardName(1, 4), "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 7);
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-924
        [Test]
        public void Recognition_ApprovalMon_WS_924()
        {
            if (!DataParser.ReturnExecution("WS_924"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_924.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    secondAward = AwardData.GetSecondAwardName(_file),
                    populationImpact = AwardData.GetAwardPopulationImpact(_file),
                    financialImpact = AwardData.GetAwardFinancialImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file);
                int amount = AwardData.GetAwardAmountValueNumbers(_file);
                string printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    reason = AwardData.GetAwardReason(_file),
                    companyValue = AwardData.GetAwardCompanyValue(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file),
                    approval_name = AwardData.GetApprovalUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(proxy_name);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + proxy_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                NominationHomePage recognitionPage = home.NavigateToNomination()
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .EnterValueAmount(amount)
                    .FillReason(reason)
                    .ChkCompanyValues(companyValue)
                    .SelectValues(populationImpact)
                    .SelectValues(bussinesImpact)
                    .SelectValues(financialImpact)
                    .FillMsg(msg)
                    .ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                AdminHomePage proxy = recognitionPage.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + approval_name, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                PendingApprovals pending = home.ClickHereAwardPopUp();
                Assert.AreEqual("Pending Approvals", pending.GetTitleMenu(), "Title is not pending approval");
                pending.ApproveAward().ClickApprove();
                proxy = pending.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(user).ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + user, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(secondAward, awards.GetAwardName(1, 4),
                    "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 7);
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-317
        [Test]
        public void Recognition_EmployeeLookUp_WS_69()
        {
            if (!DataParser.ReturnExecution("WS_69"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_69.xml";
                username = AwardData.GetAwardUserName(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                NominationHomePage recognitionPage = home.NavigateToNomination();
                //SCENARIO 1
                recognitionPage.SearchEmployeeFound(username);
                recognitionPage.ClickEdit();
                Assert.IsTrue(recognitionPage.BringToStep1(), "You didnt go back to step 1");
                //SCENARIO 2
                recognitionPage = home.NavigateToNomination();
                recognitionPage.ClickMultipleRecipients()
                    .SearchEmployeeFoundMultiple(username)
                    .SearchEmployeeFoundMultiple("John");
                recognitionPage.ClickNextGeneric().ClickEdit().ClickRemove(0);
                Assert.IsFalse(recognitionPage.IsFirstUserAddedPresent(username),
                    "First User still in the list selected");

            }
        }

        [Category("Regression")]
        [Category("BAE")]

        [Test]
        public void Recognition_RealTimeValidations_WS_1161()
        {
            if (!DataParser.ReturnExecution("WS_1161"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1161.xml";
                string user = AwardData.GetAwardUserName(_file),
                    user1 = AwardData.GetAwardUserName1(_file)
                    ,
                    user2 = AwardData.GetAwardUserName2(_file),
                    user3 = AwardData.GetAwardUserName3(_file),
                    user4 = AwardData.GetAwardUserName4(_file),
                    user5 = AwardData.GetAwardUserName5(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file);

                //Scenario 1
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNomination();
                recognitionPage.ClickMultipleRecipients()
                    .SearchEmployeeFoundMultiple(user)
                    .SearchEmployeeFoundMultiple(user1)
                    .SearchEmployeeFoundMultiple(user2).SearchEmployeeFoundMultiple(user3).ClickNextGeneric();
                Assert.IsTrue(recognitionPage.IsStep2Block(), "Step2 is not blocked");

                //Scenario 2
                MainHomePage mainPage =
                    recognitionPage.NavigateToAdminHomePage()
                        .LoginProxyAsuser()
                        .EnterUserName(proxy_name)
                        .ProxyToMainHomePage();
                Step2 ste2 = mainPage.NavigateToNomination().SearchEmployeeFound(user4);
                Assert.AreEqual("Rave", ste2.GetAwardName("Rave"), "Rave Award is not present");
                Assert.AreEqual("Pioneer Award", ste2.GetAwardName("Pioneer Award"), "Pioneer Award is not present");
                Assert.AreEqual("Pathfinder Award", ste2.GetAwardName("Pathfinder Award"),
                    "Pathfinder Award is not present");
                Assert.AreEqual("Trailblazer Award", ste2.GetAwardName("Trailblazer Award"),
                    "Trailblazer Award is not present");

                //Scenario 3
                ste2.Refresh();
                ste2 = recognitionPage.SearchEmployeeFound(user5);
                Assert.AreEqual("Rave", ste2.GetAwardName("Rave"), "Rave Award is not present");
                Assert.IsFalse(ste2.IsAwardPresent("Pioneer Award"), "Pioneer Award is  present");
                Assert.IsFalse(ste2.IsAwardPresent("Pathfinder Award"), "Pathfinder Award not present");
                Assert.IsFalse(ste2.IsAwardPresent("Trailblazer Award"), "Trailblazer Award not present");
            }
        }


        [Category("Regression")]
        [Category("Sprint")]

        //SPRIN-67
        [Test]
        public void Recognition_DistributionList_WS_1024()
        {
            if (!DataParser.ReturnExecution("WS_1024"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1024.xml";
                string user = AwardData.GetAwardUserName(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file),
                    subAward1 = AwardData.GetAwardSubType1(_file),
                    subAward2 = AwardData.GetAwardSubType2(_file),
                    ccEmail = AwardData.GetAwardCCEmail(_file),
                    futureDate = AwardData.GetAwardFutureDate(_file);
                NominationHomePage recognitionPage =
                    InitialPage.GoSpecial(_file)
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
        //WS-1157
        [Test]
        public void Recognition_NonMonAndMon_WS_1157_Sample3()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample3"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1157_Sample3.xml";
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
        public void Recognition_NonMonAndMon_WS_1157_Sample5()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample5"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1157_Sample5.xml";
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
        [Category("StElizabeth")]
        //WS-1157
        [Test]
        public void Recognition_NonMonAndMon_WS_1157_Sample1()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample1"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1157_Sample1.xml";
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
        public void Recognition_NonMonAndMon_WS_1157_Sample2()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample2"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1157_Sample2.xml";
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
        [Category("Sungard")]
        //WS-927
        [Test]
        public void Recognition_TextronStandardMonetary_WS_927()
        {
            if (!DataParser.ReturnExecution("WS_927"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_927.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    secondAward = AwardData.GetSecondAwardName(_file),
                    populationImpact = AwardData.GetAwardPopulationImpact(_file),
                    financialImpact = AwardData.GetAwardFinancialImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file),
                    amount = AwardData.GetAwardAmountValue(_file),
                    objetives = AwardData.GetAwardObjetives(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file),
                    projectTask = AwardData.GetAwardProjectTask(_file),
                    reason = AwardData.GetAwardReason(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file),
                    approval_name = AwardData.GetApprovalUserName(_file);
                ProxyHomePage proxyPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToAdminHomePage()
                    .LoginProxyAsuser().EnterUserName(user);
                MainHomePage home = proxyPage.ProxyToMainHomePage();
                Assert.AreEqual("You are proxied in under: " + user, home.GetProxyLoginMsg(),
                    "The message of proxy login is not correct");
                Step2 step2 = home.NavigateToNominationSpan()
                    .SearchEmployeeFound(proxy_name)
                    .SelectAward(award)
                    .SelectValues(populationImpact)
                    .SelectValues(financialImpact)
                    .SelectValues(bussinesImpact)
                    .ClickNextSameStep();
                Assert.AreEqual("Appreciation Award", step2.GetAwardName("Appreciation Award"),
                    "Award is not the same as expected");
                Assert.AreEqual("Honors Award", step2.GetAwardName("Honors Award"), "Award is not the same as expected");
                Assert.AreEqual("Excellence Award", step2.GetAwardName("Excellence Award"),
                    "Award is not the same as expected");
                Assert.AreEqual("Distinction Award", step2.GetAwardName("Distinction Award"),
                    "Award is not the same as expected");
                NominationHomePage recognitionPage = step2.SelectSecondAward(secondAward).SelectValueOfAward(amount)
                    .SelectProjectTask(projectTask)
                    .CheckProjectApproval()
                    .SelectValues(objetives)
                    .FillMsg(msg)
                    .FillReason(reason)
                    .ClickNext();
                recognitionPage.DeliverType(printype);
                Assert.AreEqual(2, recognitionPage.GetCountEditLnk(), "Edit links are not two");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                AdminHomePage proxy = recognitionPage.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(approval_name).ProxyToMainHomePage();
                Assert.IsTrue(home.IsPopUpRecognitionShow(), "Pop up recognition is not showing up");
                PendingApprovals pending = home.ClickHereAwardPopUp();
                Assert.AreEqual("Pending Approvals", pending.GetTitleMenu(), "Title is not pending approval");
                pending.ApproveAward().ClickApprove();
                proxy = pending.ExitProxy();
                home = proxy.LoginProxyAsuser().EnterUserName(proxy_name).ProxyToMainHomePage();
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(secondAward, awards.GetAwardName(1, 6),
                    "The last award that someone gave you is not present");
                awards.OpenDetailsAward(1, 7);
            }
        }

        [Category("Regression")]
        [Category("Sungard")]

        [Test]
        public void Recognition_RealTimeValidation_WS_1161()
        {
            if (!DataParser.ReturnExecution("WS_1161"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1161.xml";
                string user = AwardData.GetAwardUserName(_file),
                    user1 = AwardData.GetAwardUserName1(_file)
                    ,
                    user2 = AwardData.GetAwardUserName2(_file),
                    user3 = AwardData.GetAwardUserName3(_file),
                    user4 = AwardData.GetAwardUserName4(_file),
                    user5 = AwardData.GetAwardUserName5(_file),
                    proxy_name = ProxyData.GetProxyUserName(_file);

                //Scenario 1
                NominationHomePage recognitionPage =
                    InitialPage.Go().EnterId(client).EnterId(client).Logon().ClickLogin().NavigateToNominationSpan();
                recognitionPage.ClickMultipleRecipients()
                    .SearchEmployeeFoundMultiple(user)
                    .SearchEmployeeFoundMultiple(user1)
                    .SearchEmployeeFoundMultiple(user2).SearchEmployeeFoundMultiple(user3).ClickNextGeneric();
                Assert.IsTrue(recognitionPage.IsStep2Block(), "Step2 is not blocked");

                //Scenario 2
                MainHomePage mainPage =
                    recognitionPage.NavigateToAdminHomePage()
                        .LoginProxyAsuser()
                        .EnterUserName(proxy_name)
                        .ProxyToMainHomePage();
                Step2 ste2 = mainPage.NavigateToNominationSpan().SearchEmployeeFound(user4);
                Assert.AreEqual("Rave", ste2.GetAwardName("Rave"), "Rave Award is not present");
                Assert.AreEqual("Pioneer Award", ste2.GetAwardName("Pioneer Award"), "Pioneer Award is not present");
                Assert.AreEqual("Pathfinder Award", ste2.GetAwardName("Pathfinder Award"),
                    "Pathfinder Award is not present");
                Assert.AreEqual("Trailblazer Award", ste2.GetAwardName("Trailblazer Award"),
                    "Trailblazer Award is not present");

                //Scenario 3
                ste2.Refresh();
                ste2 = recognitionPage.SearchEmployeeFound(user5);
                Assert.AreEqual("Rave", ste2.GetAwardName("Rave"), "Rave Award is not present");
                Assert.IsFalse(ste2.IsAwardPresent("Pioneer Award"), "Pioneer Award is  present");
                Assert.IsFalse(ste2.IsAwardPresent("Pathfinder Award"), "Pathfinder Award not present");
                Assert.IsFalse(ste2.IsAwardPresent("Trailblazer Award"), "Trailblazer Award not present");
            }
        }
              
        [Category("Regression")]
        [Category("Sungard")]
        //WS-1157
        [Test]
        public void Recognition_NonMonAndMon_WS_1157_Sample4()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample4"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1157_Sample4.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    proxyname = ProxyData.GetProxyUserName(_file),
                    msg = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().
                    NavigateToAdminHomePageSpan().ClickOptionProxy("Proxy1").EnterUserNameProxySprint2(proxyname).ClickProxyBtn().NavigateToNominationSpan();
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
        [Category("Sungard")]
        //WS-1157
        [Test]
        public void Recognition_NonMonAndMon_WS_1157_Sample6()
        {
            if (!DataParser.ReturnExecution("WS_1157_Sample6"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1157_Sample6.xml";
                string user = AwardData.GetAwardUserName(_file), value = AwardData.GetAwardValue(_file),
                    amountvalue = AwardData.GetAwardAmountValue(_file), reason = AwardData.GetAwardReason(_file),
                   award = AwardData.GetAwardName(_file),
                   printype = AwardData.GetAwardDeliverType(_file),
                   proxyname = ProxyData.GetProxyUserName(_file),
                   msg = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().
                    NavigateToAdminHomePageSpan().ClickOptionProxy("Proxy1").EnterUserNameProxySprint2(proxyname).ClickProxyBtn().NavigateToNominationSpan();
                recognitionPage
                    .SearchEmployeeFoundAngular(user)
                    .SelectAward(award).SelectValueOfAward(amountvalue).SelectValues(value)
                    .FillMsg(msg).FillReason(reason)
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
