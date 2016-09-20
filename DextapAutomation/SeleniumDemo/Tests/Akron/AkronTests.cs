using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.Akron
{
    class NominationTests : WorkStrideBaseTest<LoginPage>
    {
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml"); string _file = null;

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
                Assert.IsTrue(home.IsPopUpRecognitionShow(),"Pop up recognition is not showing up");
                MyAwards awards = home.ClosePopUp().NavigateToMyAwards();
                Assert.AreEqual(award,awards.GetAwardName(1,5),"The last award that someone gave you is not present");
                awards.OpenDetailsAward(1,8);
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
                for (var i=0 ;i < 5; i++)
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
    }
}
