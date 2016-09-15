using System.Threading;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests.TRU
{
    class TRUTests : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");
        private static string url = ConfigUtil.ImportConfigURL("Resources\\Url.xml", "TRU");

       
        [Category("Regression")]
        [Category("TRU")]
        [Test]
        //WS_1057
        public void WS_1057()
        {
            if (!DataParser.ReturnExecution("WS_1057"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1057.xml";
                string user = AwardData.GetAwardUserName(_file), msg = AwardData.GetAwardMessage(_file),
                    award = AwardData.GetAwardName(_file), value = AwardData.GetAwardValue(_file);
                NominationHomePage recognitionPage = InitialPage.Go().Logon().ClickLogin().NavigateToNominationSpan();
                Thread.Sleep(1500);
                recognitionPage
                    .SearchEmployeeFound(user)
                    .SelectAward(award)
                    .SelectValues(value)
                    .FillMsg(msg)
                    .ClickNext()
                    .EmailReward();
                    Assert.AreEqual("Ready to send?", recognitionPage.GetReadyToSendMsg(),
                     "The message is not ready to send");
                Assert.AreEqual("SEND RECOGNITION", recognitionPage.GetBtnSendRecognitionAward(), "Submit button is not well written");
                recognitionPage.ClickSendRecognition();
                Assert.AreEqual("Success!", recognitionPage.GetSuccesMsg(), "Message its not success");
                Assert.AreEqual("FINISH", recognitionPage.GetBtnFinishLabel(), "Button finish its not correct write");
                Assert.AreEqual("RECOGNIZE SOMEONE ELSE", recognitionPage.GetBtnRecognizOtherLabelXpath(),
                    "Button finish its not correct write");
                ReportsPage details = recognitionPage.NavigateToReportsSpan().NavigateToReports();
                Assert.AreEqual(award, details.GetAwardTable(1, 6), award + "award was not given");
                Assert.AreEqual(user, details.GetAwardTable(1,3), user + "user was not given or present");
                var proxypage =
                    details.NavigateToAdminHomePageSpan()
                        .ClickOptionProxy("Proxy")
                        .EnterUserName(user)
                        .ProxyToMainHomePage().ClosePopUp();
                Thread.Sleep(300);
                var myawards = proxypage.NavigateToMyAwards();
                Assert.AreEqual(award, myawards.GetAwardName(1, 5), award + "award was not given");
           }
        }
    }
}
