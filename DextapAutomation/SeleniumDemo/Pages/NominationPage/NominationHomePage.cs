using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages.AdminPage;

namespace SeleniumDemo.Pages.NominationPage
{
    public class NominationHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/proxy')]")]
        private IWebElement _lnkProxy;

        [FindsBy(How = How.Name, Using = "employee-lookup")]
        private IWebElement _txtName;

        [FindsBy(How = How.Id, Using = "recog_PersonalizeImg2")]
        private IWebElement _imgRecognition2;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='REASON']")]
        private IWebElement _txtReason;

        public NominationHomePage (IWebDriver driver) : base(driver) { }

        public Step2 SearchEmployeeFound(string employee)
        {
            Synchronization.WaitForElementToBePresent(By.Name("employee-lookup"));
            _txtName.SendKeys(employee);
            Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='searchSlider']/div/div/div/img")).Click();
            return NewPage<Step2>();
        }

        
        public NominationHomePage SelectRecognition()
        {
            _imgRecognition2 = FindElement(By.XPath("//*[@id='recog_PersonalizeImg2']/img"));
            Synchronization.WaitForElementToBePresent(_imgRecognition2);
            if (_imgRecognition2.Displayed)
                _imgRecognition2.Click();
            return this;
        }

        public NominationHomePage PrintReward()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//div[contains(@data-id,'PRINT')]")).Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage EmailReward()
        {
            Synchronization.WaitForElementToBePresent
                (By.XPath("//div[contains(@data-id,'EMAIL')]")).Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage ClickSendRecognition()
        {
            IWebElement send =
                Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(.,'Send Recognition')]"));
            send.Click();
            Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Success!')]"));
            return NewPage<NominationHomePage>();
        }

        public string GetSuccesMsg()
        {
            IWebElement success = FindElement(By.XPath("//h3[contains(.,'Success!')]"));
            Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Success!')]"));
            return success.Text;
        }

        public string GetErrorEmployeeMsg()
        {
            IWebElement error = FindElement(By.XPath("//div[contains(@class,'no-results')]"));
            Synchronization.WaitForElementToBePresent(error);
            return error.Text;
        }

        public NominationHomePage SearchEmployeeNotFound(string employee)
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//div[contains(@class,'suggestTitle')]"));
             Synchronization.WaitForElementToBePresent(_txtName);
            _txtName.SendKeys(employee);
            return NewPage<NominationHomePage>();
        }

        public MainHomePage ClickFinish()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/welcome')]")).Click();
            return NewPage<MainHomePage>();
        }

        public string GetDeliverLabel(string deliver)
        {
            IWebElement[] deliveroption = FindElements(By.ClassName("deliverySelection")).ToArray();
            return deliver == "email" ? deliveroption[0].Text : deliveroption[1].Text;
        }

        public int GetCountEditLnk()
        {
            if (FindElement(By.XPath("//*[@id='recogStep3']/div[1]/span[2]"))!=null &&
                (FindElement(By.XPath("//*[@id='recogStep2']/div[1]/span[2]")) != null))
                return 2;
            return 0;
        }

        public string GetReadyToSendMsg()
        {
            return FindElement(By.XPath("//h3[contains(.,'Ready to send?')]")).Text;
        }

        public string GetBtnFinishLabel()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Finish')]")).Text.ToUpper();
        }

        public string GetBtnRecognizOtherLabel()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/nomination')]")).Text.ToUpper();
        }

        public NominationHomePage DeliverType(string deliver)
        {
            return deliver == "Print" ? PrintReward() : EmailReward();
        }

        public AdminHomePage ExitProxy()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Exit Proxy')]")).Click();
            return NewPage<AdminHomePage>();
        }

        public Step2 FillReason(string reason)
        {
            _txtReason.SendKeys(reason);
            return NewPage<Step2>();
        }

        public NominationHomePage ClickNext()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@class,'midBannerBtn submitAward')]"));
            FindElement(By.XPath("//button[contains(@class,'midBannerBtn submitAward')]")).Click();
            return NewPage<NominationHomePage>();
        }

        public string GetAwardName(int p)
        {
            throw new NotImplementedException();
        }

        public NominationHomePage SelectRecipientType(string type)
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//h4[contains(.,'Suggestions')]"));
            IWebElement[] recipient =
                Synchronization.WaitForElementsToBePresent(By.XPath("//span[contains(@class,'recipient-select-text')]"))
                    .ToArray();
            if (recipient[0].Displayed)
              if (type == "single")
                recipient[0].Click();
              else
                if (type == "multiple")
                    recipient[1].Click();
                else
                    recipient[2].Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage SearchEmployeeFoundMultiple(string user)
        {
            IWebElement element = Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//span[contains(.,'{0}')]",user)));
            if (element.Displayed)
                element.Click();
          return NewPage<NominationHomePage>();

        }

        public Step2 ClickNextStep2()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@class,'midBannerBtn submitAward')]"));
            FindElement(By.XPath("//button[contains(@class,'midBannerBtn submitAward')]")).Click();
            return NewPage<Step2>();
        }

        public NominationHomePage SelectSubAwardType()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//h4[@class='ecard-edit-heading']"));
            Synchronization.WaitForElementToBePresent(By.XPath("//div[contains(.,'Business')]")).Click();
            return NewPage<NominationHomePage>();
        }
    }
}
