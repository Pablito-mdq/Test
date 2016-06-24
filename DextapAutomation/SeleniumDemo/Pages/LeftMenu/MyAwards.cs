using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu
{
    public class MyAwards : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='report-table-container']")]
        private static IWebElement _tableAwards;

        public MyAwards(IWebDriver driver) : base(driver){}

        public string GetAwardName(int row,int col)
        {
            Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[contains(@id,'ui-spinner-container')]"));
            return Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}]", row, col))).Text;
        }

        public DetailsAward OpenDetailsAward(int row,int col)
        {
            Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[contains(@id,'ui-spinner-container')]"));
            IWebElement details =
                Synchronization.WaitForElementToBePresent(
                    By.XPath(string.Format(
                        "//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}]/a[1]/img",row,col)));               
            details.Click();
            return NewPage<DetailsAward>();
            }
    }
}
