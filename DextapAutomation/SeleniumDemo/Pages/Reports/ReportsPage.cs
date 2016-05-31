using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.Reports
{
    public class ReportsPage: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'All Awards')]")]
        private IWebElement _lnkAllAwardsLkn;

        public ReportsPage(IWebDriver driver) : base(driver) { }

        public AllAwards clickAllAwards()
        {
            Synchronization.WaitForElementToBePresent(_lnkAllAwardsLkn);
            _lnkAllAwardsLkn.Click();
            return NewPage<AllAwards>();
        }

       
    }
}
