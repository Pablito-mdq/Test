using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Pages
{
   public class AwardDetailsPopUp: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'submit')]")]
        private IWebElement _btnApprove;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'submit')]")]
        private IWebElement _btnDecline;

        [FindsBy(How = How.XPath, Using = "//select[contains(@id,'reward-detail-form-AMOUNT')]")]
        private IWebElement _cboValue;

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

        public AwardDetailsPopUp ChangeValue()
        {
            new SelectElement(_cboValue).SelectByText("$50.00");
            return this;
        }

        public PendingApprovals ClickUpgrade()
        {
            ScrollTo(_btnDecline);
            ScrollTo(FindElement(By.XPath("//button[contains(@data-type,'upgrade')]")));
            _btnApprove.Click();
            if (FindElement(By.Id("modal")) == null)
                Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[@id='ui-spinner-container']"));
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Exit Proxy')]"));
            return NewPage<PendingApprovals>();
        }

       public AwardDetailsPopUp ApproveAllorDeclineAll()
       {
           Synchronization.WaitForElementToBePresent(By.XPath("//textarea[contains(@name,'approvalComment')]")).SendKeys("QA Test");
           Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@class,'btn btn-generic')]")).Click();
           return NewPage<AwardDetailsPopUp>();
       }

       public bool IsPopUpPresent()
       {
           return Synchronization.WaitForElementToBePresent(By.XPath("//div[@class='approvaltool-modal-innerwrapper']"))
               .Displayed;
       }

       public string GetSuccesfullMsg()
       {
           return Synchronization.WaitForElementToBePresent(By.XPath("//p[contains(@class,'approvaltool_modal-successmsg')]")).Text;
       }

       public PendingApprovals ClickClose()
       {
           Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(.,'Close')]")).Click();
           return NewPage<PendingApprovals>();
       }
    }
}
