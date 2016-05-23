using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages.AdminPage;

namespace SeleniumDemo.Pages
{
    public class PendingApprovals: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Approve')]")]
        private IWebElement _btnApprove;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Decline')]")]
        private IWebElement _btnDecline;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Exit Proxy')]")]
        private IWebElement _lnkExitProxy;

        [FindsBy(How = How.Id, Using = "Mdd")]
        private IWebElement TxtMddName;

        public PendingApprovals(IWebDriver driver) : base(driver) { }

        public string GetTitleMenu()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Pending Approvals')]")).Text;
        }

        public AwardDetailsPopUp ApproveAward()
        {
            _btnApprove.Click();
            return NewPage<AwardDetailsPopUp>();
        }

        public AdminHomePage ExitProxy()
        {
            Synchronization.WaitForElementToBePresent(_lnkExitProxy);
            ScrollTo(_lnkExitProxy);
            _lnkExitProxy.Click();
            return NewPage<AdminHomePage>();
        }

        public AwardDetailsPopUp DeclineAward()
        {
            _btnDecline.Click();
            return NewPage<AwardDetailsPopUp>();
        }
    }
}
