using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebDriverFramework.WebPage;

namespace SeleniumDemo.Pages.Reports
{
    public class ReportsPage: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'All Awards')]")]
        private IWebElement _lnkAllAwardsLkn;

        [FindsBy(How = How.Id, Using = "report-table-container")]
        private IWebElement _tableReports;

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

        public bool LoadTakesMoreThan10sec()
        {
            for (int i = 0; i < 11; i++)
            {
                Thread.Sleep(999);
            }
            if (FindElement(By.XPath("//div[contains(@class,'loader')]"))!= null)
                return FindElement(By.XPath("//div[contains(@class,'loader')]")).Displayed;
            return false;
        }

        public ReportsPage ClickHeader(int header)
        {
            IWebElement a =FindElement(By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[1]/tr/th[{0}]",header)));
            a.Click();
            return NewPage<ReportsPage>();
        }
    }
}
