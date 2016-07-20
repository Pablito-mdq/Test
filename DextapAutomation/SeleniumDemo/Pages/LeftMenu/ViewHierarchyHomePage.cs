using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu
{
    public class ViewHierarchyHomePage: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='report-table-container']")]
        private static IWebElement _tableAwards;

        public ViewHierarchyHomePage(IWebDriver driver) : base(driver) { }
    }
}
