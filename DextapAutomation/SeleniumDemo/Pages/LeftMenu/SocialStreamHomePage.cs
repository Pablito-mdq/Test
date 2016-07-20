using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu
{
    public class SocialStreamHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='report-table-container']")]
        private static IWebElement _tableAwards;

        public SocialStreamHomePage(IWebDriver driver) : base(driver) { }

    }
}
