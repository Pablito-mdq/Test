using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Tests;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Pages
{
    public class WorkStridePage : AbstractWebPage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'REDEEM')]")]
        private IWebElement _lnkNavigateReedem;
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/MyJobs']")]
        private IWebElement LnkMyJobs;

        [FindsBy(How = How.XPath, Using = "//a[@href='/Jobs']")]
        private IWebElement LnkAllJobs;

        
        [FindsBy(How = How.XPath, Using = "//a[@href='/Queue']")]
        private IWebElement LnkQueue;

        [FindsBy(How = How.XPath, Using = "//a[@href='/?Length=6']")]
        private IWebElement LnkTools;

        [FindsBy(How = How.XPath, Using = "//a[@href='/Profile']")]
        private IWebElement LnkProfile;

        [FindsBy(How = How.XPath, Using = "//a[@href='/Dextap/Mdd?Length=6']")]
        private IWebElement LnkDownloadMdd;

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
        public EditProfilePage NavigateToolsProfile()
        {
            LnkTools.Click();
            LnkProfile.Click();
            return NewPage <EditProfilePage>();
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
            Synchronization.WaitForElementToBePresent(_lnkMyAwards);
            _lnkMyAwards.Click();
            return NewPage<MyAwards>();
        }

    }
}
