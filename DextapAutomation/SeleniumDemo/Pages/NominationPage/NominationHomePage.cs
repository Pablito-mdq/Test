using System;
using System.Linq;
using System.Threading;
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

        [FindsBy(How = How.Id, Using = "ccUserLookupInput")]
        private IWebElement _txtCCEmail;

        [FindsBy(How = How.Id, Using = "reward-detail-form--FUTURE_DATE")]
        private IWebElement _txtFutureDate;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'employeeMultiSelect selected')]")]
        private IWebElement _btnMulti;

        public NominationHomePage (IWebDriver driver) : base(driver) { }

        public Step2 SearchEmployeeFound(string employee)
        {
            Synchronization.WaitForElementToBePresent(By.Name("employee-lookup"));
            _txtName.Clear();
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
                (By.XPath("//div[contains(@data-id,'EMAIL')]"));
            Synchronization.WaitForElementToBePresent
                (By.XPath("//div[contains(@data-id,'EMAIL')]")).Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage ClickSendRecognition()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(.,'Send Recognition')]"));
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
            Synchronization.WaitForElementToBePresent(By.XPath("//label[contains(.,'Search for an employee:')]"));
            Synchronization.WaitForElementToBePresent(By.Name("employee-lookup"));
            _txtName.Clear();
            _txtName.SendKeys(user);
            Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//span[contains(.,'{0}')]",user))).Click();
          return NewPage<NominationHomePage>();

        }

        public Step2 ClickNextStep2()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@class,'btn-generic submitEmployees')]"));
            FindElement(By.XPath("//button[contains(@class,'btn-generic submitEmployees')]")).Click();
            return NewPage<Step2>();
        }

        public NominationHomePage SelectSubAwardType(string type,string type2)
        {
            Synchronization.WaitForElementsToBePresent(By.XPath("//div[contains(@class,'ecard-selection-name')]"));
            Synchronization.WaitForElementsToBePresent(By.XPath("//div[contains(@class,'ecard-selection-name')]")).FirstOrDefault().Click();
            Synchronization.WaitForElementsToBePresent(By.XPath("//div[contains(@class,'ecard-selection-name')]"));
            IWebElement[] selections =Synchronization.WaitForElementsToBePresent(By.XPath("//div[contains(@class,'ecard-selection-name')]")).ToArray();
            Synchronization.WaitForElementsToBePresent(By.XPath("//div[contains(@class,'ecard-selection-name')]"));
            selections[2].Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage FillEditCardEditor(string message)
        {
            IWebElement msg = Synchronization.WaitForElementToBePresent(
                By.XPath("//textarea[contains(@ng-repeat,'textarea in recognize.ecard.template.layoutDetails.desktop_textareas')]"));
            msg.SendKeys(message);
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage EnterUserCCEmail(string ccEmail)
        {
            Synchronization.WaitForElementToBePresent(_txtCCEmail);
            _txtCCEmail.SendKeys(ccEmail);
            Synchronization.WaitForElementToBePresent(By.XPath("//div[contains(@class,'typeahead-user-name')]")).Click();
            return this;
        }

        public NominationHomePage EnterFutureDate(string futureDate)
        {
            Synchronization.WaitForElementToBePresent(_txtFutureDate);
            _txtCCEmail.SendKeys(futureDate);
            return this;
        }

        public NominationHomePage ClickNextFillCard()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@ng-click,'ecardNext()')]")).Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage ClickNextStep()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(.,'Next Step')]")).Click();
            return NewPage<NominationHomePage>();
            
        }

        public string GetBtnSendRecognition()
        {
            return
                Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@ng-click,'submitRecognition()')]"))
                    .Text;
        }

        public NominationHomePage ClickNextGeneric()
        {
           Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(.,'Next')]")).Click();
           return NewPage<NominationHomePage>();
        }

        public NominationHomePage ClickEdit()
        {
            IWebElement edit = Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recogStep1']/div[1]/span[2]"));
            Thread.Sleep(1500);
            Synchronization.WaitForElementToBePresent(edit);
            edit.Click();
            Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(@class,'stepNumber')]"));
            return NewPage<NominationHomePage>();
        }

        public bool BringToStep1()
        {
            Thread.Sleep(2500);
          IWebElement step= Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(@class,'stepNumber')]"));
          var color = step.GetCssValue("background-color");
           return color == ("rgba(114, 122, 127, 1)");
        }

        public NominationHomePage ClickMultipleRecipients()
        {
            IWebElement multi = Synchronization.WaitForElementToBePresent(By.XPath("//div[contains(@class,'employeeMultiSelect')]"));
            if (multi.Displayed)
                multi.Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage ClickRemove(int p)
        {
            IWebElement[] list =Synchronization.WaitForElementsToBePresent(By.XPath("//div[contains(@class,'remove')]")).ToArray();
            list[0].Click();
            return NewPage<NominationHomePage>();
        }

        public bool IsFirstUserAddedPresent(string user)
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recogStep1']/div[1]/span[2]")).Click();
            IWebElement element = Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//div[contains(.,'Aaron {0}')]",user)));
            if (element != null)
                return false;
            return true;
        }

        internal object GetValueAward()
        {
            throw new NotImplementedException();
        }
    }
}
