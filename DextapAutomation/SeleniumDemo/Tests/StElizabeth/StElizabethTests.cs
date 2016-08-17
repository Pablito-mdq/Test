using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.StElizabeth
{
    internal class StElizabethTests : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");
        private static string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml", "Sungard");
        
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
                    award = AwardData.GetAwardName(_file), value = AwardData.GetAwardValue(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    msg = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToNominationSpan();
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
                NominationHomePage recognitionPage = InitialPage.Go().EnterId(client).Logon().ClickLogin().NavigateToNominationSpan();
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
