using System;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.LeftMenu.MyRedemption;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{
    internal class SungardTests : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();


        [Category("Regression")]
        [Category("Sungard")]
        //WS-1345
        [Test]
        public void Award_Wizard_WS_1345_Sample1()
        {
            if (!DataParser.ReturnExecution("WS_1345_Sample1"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1345_Sample1.xml";
                string user = AwardData.GetAwardUserName(_file),
                    award = AwardData.GetAwardName(_file), financialImpact = AwardData.GetAwardFinancialImpact(_file),
                    bussinesImpact = AwardData.GetAwardBussinesImpact(_file);
                NominationHomePage recognitionPage = InitialPage.GoSpecial(_file).Logon().ClickLogin()
                    .NavigateToNominationSpan();
                recognitionPage
                    .SearchEmployeeFoundAngular(user)
                    .SelectAward(award).SelectValues(bussinesImpact).SelectValues(financialImpact);
                Assert.AreEqual("I want to Email this award.", recognitionPage.GetDeliverLabel("email"),
                    "Label is not correct");
            }
        }
    }
}
