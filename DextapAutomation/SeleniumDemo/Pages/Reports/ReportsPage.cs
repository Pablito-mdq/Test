using System.Threading;
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
            Thread.Sleep(1500);
            Synchronization.WaitForElementToBePresent(_lnkAllAwardsLkn);
            _lnkAllAwardsLkn.Click();
            return NewPage<AllAwards>();
        }

        public string GetAwardName(int row, int col)
        {
            return Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}]", row, col))).Text;
        }
    }
}
