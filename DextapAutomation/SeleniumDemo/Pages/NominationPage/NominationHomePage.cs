using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Pages.NominationPage
{
    public class NominationHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/proxy')]")]
        private IWebElement _lnkProxy;

        [FindsBy(How = How.Name, Using = "employee-lookup")]
        private IWebElement _txtName;

        [FindsBy(How = How.Id, Using = "reward-detail-form-25-MESSAGE")]
        private IWebElement _txtMsg;

        [FindsBy(How = How.Id, Using = "reward-detail-form-25-REASON")]
        private IWebElement _txtReason;

        [FindsBy(How = How.Id, Using = "recog_PersonalizeImg2")]
        private IWebElement _imgRecognition2;

        public NominationHomePage (IWebDriver driver) : base(driver) { }

        public NominationHomePage SearchEmployee(string employee)
        {
            Synchronization.WaitForElementToBePresent(_txtName);
            _txtName.SendKeys(employee);
            Synchronization.WaitForElementToBePresent(By.XPath("//img[contains(@src,'http://demoassets.workstride.com/resources/companies/workstride/employeeUploads/default/profileDefault.jpg')]"));
            FindElement(By.XPath("//img[contains(@src,'http://demoassets.workstride.com/resources/companies/workstride/employeeUploads/default/profileDefault.jpg')]")).Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage SelectAward()
        {
            IWebElement step2 = FindElement(By.Id("recogStep2"));
            Synchronization.WaitForElementToBePresent(By.XPath("//h4[contains(.,'Thank You')]"));
            if (step2.Displayed)
                FindElement(By.XPath("//h4[contains(.,'Thank You')]")).Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage SelectValues()
        {
            FindElements(By.ClassName("radio")).First().Click();
            return this;
        }

        public NominationHomePage FillMsg()
        {
            _txtMsg.SendKeys("test");
            return this;
        }

        public NominationHomePage FillReason()
        {
            _txtReason.SendKeys("holahola");
            return this;
        }

        public NominationHomePage ClickNext()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@class,'midBannerBtn submitAward')]"));
            FindElement(By.XPath("//button[contains(@class,'midBannerBtn submitAward')]")).Click();
            return NewPage<NominationHomePage>();
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
            FindElement(By.XPath("//h4[contains(.,'I want to print this award.')]")).Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage SendRecognition()
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
    }
}
