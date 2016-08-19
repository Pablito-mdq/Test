using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebDriverFramework.WebPage;

namespace SeleniumDemo.Pages.Reports
{
    public class ReportsPage: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'All Awards')]")]
        private IWebElement _lnkAllAwardsLkn;

        [FindsBy(How = How.Id, Using = "report-table-container")]
        private IWebElement _tableReports;

        [FindsBy(How = How.XPath, Using = "//h4[contains(.,'▶ Filters: ')]")]
        private IWebElement _lnkFilters;

        [FindsBy(How = How.Id, Using = "report-page-size")]
        private IWebElement _cboPageSize;

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
                Thread.Sleep(9999);
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

        public bool IsOptLeftMenuNameDisplayed(string opt)
        {
            Synchronization.WaitForElementNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            return Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//a[contains(.,'{0}')]",opt))).Displayed;
        }

        public ReportsPage ClickLeftMenu(string p)
        {
            Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//a[contains(.,'{0}')]",p))).Click();
            return NewPage<ReportsPage>();
        }

        public ReportsPage ClickFilter()
        {
            Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            _lnkFilters.Click();
            return NewPage<ReportsPage>();
        }

        public ReportsPage EnterStartDate(string date)
        {
            Synchronization.WaitForElementToBePresent(By.Id("report-filter-send_date_start")).SendKeys(date);
            return this;
        }

        public ReportsPage EnterFinishDate(string finishDate)
        {
            Synchronization.WaitForElementToBePresent(By.Id("report-filter-send_date_end")).SendKeys(finishDate);
            return this;
        }

        public ReportsPage ClickSubmit()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//input[contains(@value,'Submit')]")).Click();
            Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            return NewPage<ReportsPage>();
        }

        public string GetDate(int p)
        {
            IWebElement[] a = Synchronization.WaitForElementsToBePresent(By.XPath("//p[contains(@class,'filter-tag')]")).ToArray();
            return a[p].Text;
        }

        public bool IsCellFull(int row, int col)
        {
            IWebElement a =
                Synchronization.WaitForElementToBePresent(
                    By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}])", row, col)));
            return a.Text.Length != 0;
        }

        public ReportsPage SelectPageSize(string quant)
        {
            Synchronization.WaitForElementToBePresent(_cboPageSize);
            new SelectElement(_cboPageSize).SelectByValue(quant);
            Thread.Sleep(2500);
            Synchronization.WaitForElementNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            return NewPage<ReportsPage>();
        }
    }
}
