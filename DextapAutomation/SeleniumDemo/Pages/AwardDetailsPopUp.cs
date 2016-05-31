using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages
{
   public class AwardDetailsPopUp: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'submit')]")]
        private IWebElement _btnApprove;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'submit')]")]
        private IWebElement _btnDecline;

        public AwardDetailsPopUp(IWebDriver driver) : base(driver) { }

        public PendingApprovals ClickApprove()
        {
            ScrollTo(_btnApprove);
            ScrollTo(FindElement(By.XPath("//button[contains(@data-type,'approve')]")));
            _btnApprove.Click();
            if (FindElement(By.Id("modal")) == null)
                Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[@id='ui-spinner-container']"));
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Exit Proxy')]"));
            return NewPage<PendingApprovals>();
        }

        public PendingApprovals ClickDeclined()
        {
            ScrollTo(_btnDecline);
            ScrollTo(FindElement(By.XPath("//button[contains(@data-type,'decline')]")));
            _btnApprove.Click();
            if (FindElement(By.Id("modal")) == null)
                Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[@id='ui-spinner-container']"));
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Exit Proxy')]"));
            return NewPage<PendingApprovals>();
        }
    }
}
