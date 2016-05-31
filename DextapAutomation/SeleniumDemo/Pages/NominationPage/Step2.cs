using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Pages.NominationPage
{
    public class Step2 : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@name='MESSAGE']")]
        private IWebElement _txtMsg;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='REASON']")]
        private IWebElement _txtReason;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'AMOUNT')]")]
        private IWebElement _cboValue;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'AMOUNT')]")]
        private IWebElement _txtValue;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'PROJECT_TASK')]")]
        private IWebElement _txtProjectTask;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'APPROVAL_FROM_TASK_OWNER')]")]
        private IWebElement _chkApproval;

        public Step2(IWebDriver driver) : base(driver){}

        public Step2 SelectAward(string award)
        {
            IWebElement step2 = Synchronization.WaitForElementToBePresent(By.Id("recogStep2"));
            Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//h4[contains(.,'{0}')]", award)));
            if ((step2.Displayed) && (FindElement(By.XPath(string.Format("//h4[contains(.,'{0}')]", award))).Displayed))
                Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//h4[contains(.,'{0}')]", award))).Click();
            return NewPage<Step2>();
        }

        public Step2 SelectValues(string value)
        {
            if (value!="")
                Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//span[contains(.,'{0}')]", value))).Click();
            return this;
        }

        public Step2 FillMsg(string msg)
        {
            _txtMsg.SendKeys(msg);
            return this;
        }

        public Step2 FillReason(string reason)
        {
            _txtReason.SendKeys(reason);
            return this;
        }

        public NominationHomePage ClickNext()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@class,'midBannerBtn submitAward')]"));
            FindElement(By.XPath("//button[contains(@class,'midBannerBtn submitAward')]")).Click();
            return NewPage<NominationHomePage>();
        }


        public Step2 SelectValueOfAward(string amount)
        {
            if (_cboValue!=null)
               if (amount!="")
                 new SelectElement(_cboValue).SelectByText(amount);
            return this;
        }

        public Step2 SelectProjectTask(string projectTask)
        {
          _txtProjectTask.SendKeys(projectTask);
          Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@tabindex,'-1')]")).Click();
            return this;
        }

        public Step2 ClickNextSameStep()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@class,'midBannerBtn submitWizard')]")).Click();
            return NewPage<Step2>();
        }

        public Step2 CheckProjectApproval()
        {
            _chkApproval.Click();
            return NewPage<Step2>();
        }

        public string GetAwardName(string name)
        {
             Synchronization.WaitForElementToBePresent(By.Id("recogStep2"));
            return
                Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//h4[contains(.,'{0}')]", name))).Text;
        }

        public Step2 SelectSecondAward(string award)
        {
            IWebElement a = Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//h4[contains(.,'{0}')]", award)));
            ScrollTo(FindElement(By.XPath("//span[contains(.,'2')]")));
            ScrollTo(FindElement(By.XPath("//span[contains(.,'1')]")));
            a.Click();
            return NewPage<Step2>();
        }

        public Step2 EnterValueAmount(int amount)
        {
            _txtValue.SendKeys(amount.ToString());
            return this;
        }

        public Step2 ChkCompanyValues(string companyValue)
        {
            FindElement(By.XPath(string.Format("//span[contains(.,'{0}')]",companyValue))).Click();
            return this;
        }
    }
}
