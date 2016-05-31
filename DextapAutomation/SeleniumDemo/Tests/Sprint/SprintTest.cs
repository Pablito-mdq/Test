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
/*
        [Category("Regression")]
        [Category("Sprint")]

        //SPRIN-67
        [Test]
        public void Sprint_DISTRIBUTION_LISTS()
        {
            if (!DataParser.ReturnExecution("Sprint_DISTRIBUTION_LISTS"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\TestsData\\" + client + "\\Sprint_DISTRIBUTION_LISTS.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file),
                    printype = AwardData.GetAwardDeliverType(_file),
                    ccEmail = AwardData.GetAwardMessage(_file),
                    futureDate = AwardData.GetAwardMessage(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().EnterId().ClickLogin().NavigateToNominationSprint();
                recognitionPage
                    .SelectRecipientType("multiple")
                    .SearchEmployeeFoundMultiple(user)
                    .ClickNextStep2()
                    .SelectAward(award)
                    .ClickNext()
                    .SelectSubAwardType()
                    .ClickNext()
                    .FillEditCardEditor()
                    .ClickNext()
                    .EnterUserCCEmail(ccEmail).EnterFutureDate(futureDate).ClickNext();
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
            }
        }*/
    }
}
