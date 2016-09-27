using System;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Tests.Sprint;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{
    internal class SocialStream : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();
        private static string url = ConfigUtil.ImportConfigURL(string.Format("Resources\\{0}\\Url.xml", client), client);



     
        [Category("Regression")]
        [Category("Sprint")]

        //WS_1184
        [Test]
        public void SocialStream_Cheers_WS_1185()
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
        public void SocialStream_Congrats_WS_1148()
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
        [Category("BAE")]
        //WS-1189
        [Test]
        public void SocialStream_FollowFeatures_WS_1190()
        {
            if (!DataParser.ReturnExecution("WS_1190"))
                Assert.Ignore();
            else
            {
                MainHomePage mainPage = InitialPage.Go().Logon().ClickLogin();
                Assert.IsTrue(mainPage.IsEveryoneSelected(), "Everyone is not selected in display options");
                if (mainPage.IsFollowBannerPresent())
                    mainPage.ClickFollow();
                mainPage.ClickFollow();
                Assert.IsTrue(mainPage.IsFollowBannerPresent(), "Follow banner is not present");
                mainPage = mainPage.NavigateToRedeemA().NavigateToHomePage();
                Assert.AreEqual("FOLLOWING", mainPage.GetFollowingRibbonMsg(),
                    "Following is not present or not spell well");
            }
        }

        [Category("Regression")]
        [Category("Sprint")]
        //WS_1299
        [Test]
        public void Proxy_ManagerAccess_WS_1299()
        {
            if (!DataParser.ReturnExecution("WS_1299"))
                Assert.Ignore();
            else
            {
                ProxyManagerHomePage proxy = InitialPage.Go().Logon().ClickLogin().NavigateToAdminHomePageSpan().
                    ClickOptionProxyManager();
                Assert.AreEqual("Proxy Management", proxy.GetTitlePage(), "The title is not Proxy Management");
            }
        }


        [Category("Regression")]
        [Category("StElizabeth")]
        //WS-1391
        [Test]
        public void SocialStream_Recognition_WS_1391()
        {
            if (!DataParser.ReturnExecution("WS_1391"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1391.xml";
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
                MainHomePage home = recognitionPage.ClickFinish();
                Assert.IsTrue(home.WasUserRewarded(user), user + "was not rewarded");
            }
        }

    }
}