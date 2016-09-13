using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.Reports
{
    public class ReportDetailsPage: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'All Awards')]")]
        private IWebElement _lnkAllAwardsLkn;

        public ReportDetailsPage(IWebDriver driver) : base(driver) { }

        public string GetTable(int row)
        {
            return
                Synchronization.WaitForElementToBePresent(
                    By.XPath(string.Format("//*[@id='modal']/div/div[1]/table[1]/tbody/tr[{0}]/td[2]", row))).Text;
        }

        public string GetIssuer()
        {
            return GetTable(1);
        }

        public string GetAward()
        {
            return GetTable(3);
        }

        public string GetRecipient()
        {
            return GetTable(2);
        }

        public string GetAwardTie()
        {
            return GetTable(3);
        }

        public string GetteamName()
        {
            if (GetTable(4) == string.Empty)
                return "NO";
            return GetTable(4);
        }

        public string Getdate()
        {
            return GetTable(5);
        }

        public string GetAmount()
        {
            return GetTable(6);
        }
    }
}
