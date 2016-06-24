using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.MyRedemption;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Tests;
using SeleniumDemo.Tests.Pages;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Pages
{
    public class WorkStridePage : AbstractWebPage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'REDEEM')]")]
        private IWebElement _lnkNavigateReedem;
        
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/report/awards')]")]
        private IWebElement _lnkReports;
    
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/my_awards')]")]
        private IWebElement _lnkMyAwards;

        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'company.png')]")]
        private IWebElement _lnkHomePage;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdmin;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdminSpan;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/approval')]")]
        private IWebElement _lnkPending;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/my_redemptions')]")]
        private IWebElement _lnkMyRedemptions;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/customer_appreciation')]")]
        private IWebElement _lnkSendAppreciation;

        public WorkStridePage(IWebDriver driver) : base(driver) { }

       public MainHomePage NavigateToHomePage()
       {
           Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[contains(@id,'ui-spinner-container')]"));
          _lnkHomePage.Click();
          return NewPage<MainHomePage>();
       }

       public ProxyHomePage NavigateToAdminHomePagePinnacola()
       {
           Synchronization.WaitForElementToBePresent(_lnkAdmin);
           if (_lnkAdmin.Displayed)
               _lnkAdmin.Click();
           return NewPage<ProxyHomePage>();
       }

       public AdminHomePage NavigateToAdminHomePage()
       {
           _lnkAdmin.Click();
           return NewPage<AdminHomePage>();
       }

       public ProxyHomePage NavigateToAdminHomePageSpan()
       {
           Synchronization.WaitForElementToBePresent(_lnkAdminSpan);
           _lnkAdminSpan.Click();
           return NewPage<ProxyHomePage>();
       }

        public RewardsHomePage NavigateToRewardsHomePage()
        {
            Synchronization.WaitForElementToBePresent(By.Id("modal"));
            FindElement(By.XPath("//*[@id='modal']/div/div/a")).Click();
            Synchronization.WaitForElementToBePresent(_lnkNavigateReedem);
            _lnkNavigateReedem.Click();
            return NewPage<RewardsHomePage>();
        }

        public MyAwards NavigateToMyAwards()
        {
            Synchronization.WaitForElementNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            Thread.Sleep(2500);
            Synchronization.WaitForElementToBePresent(_lnkMyAwards);
            _lnkMyAwards.Click();
            return NewPage<MyAwards>();
        }

        public ReportsPage NavigateToReports()
        {
            _lnkReports.Click();
            Synchronization.WaitForElementNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            return NewPage<ReportsPage>();
        }

        public PendingApprovals NavigateToPendingApprovals()
        {
            _lnkPending.Click();
            return NewPage<PendingApprovals>();
        }

        public MyRedemptions NavigateToMyRedemptions()
        {
            _lnkMyRedemptions.Click();
            return NewPage<MyRedemptions>();
        }

        public SendAppreciationPage NavigateToSendAppreciation()
        {
            _lnkSendAppreciation.Click();
            return NewPage<SendAppreciationPage>();
        }
    }
}
