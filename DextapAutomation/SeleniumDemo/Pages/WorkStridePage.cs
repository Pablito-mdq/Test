using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Tests;
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

        public WorkStridePage(IWebDriver driver) : base(driver) { }

       public MainHomePage NavigateToHomePage()
       {
          _lnkHomePage.Click();
          return NewPage<MainHomePage>();
       }

       public AdminHomePage NavigateToAdminHomePage()
       {
           _lnkAdmin.Click();
           return NewPage<AdminHomePage>();
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

    }
}
