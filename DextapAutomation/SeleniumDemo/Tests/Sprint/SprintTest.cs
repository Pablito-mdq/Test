using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
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
