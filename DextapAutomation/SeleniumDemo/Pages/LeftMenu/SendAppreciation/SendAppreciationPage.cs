using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu.MyRedemption
{
    public class SendAppreciationPage: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdmin;

        public SendAppreciationPage(IWebDriver driver) : base(driver) { }
    }
}
