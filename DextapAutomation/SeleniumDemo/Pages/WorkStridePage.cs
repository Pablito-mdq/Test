using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFramework.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Tests;

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

        [FindsBy(How = How.XPath, Using = "//a[@href='/AlertHistory']")]
        private IWebElement LnkAlertHistory;
     

        public WorkStridePage(IWebDriver driver) : base(driver) { }
        
        public AdminHomePage NavigateNewJob ()
          {
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
        public bool ToolsOptions()
        {
            LnkTools.Click();
            return (LnkAlertHistory.Displayed && LnkDownloadMdd.Displayed && LnkProfile.Displayed);
        }
    }
}
