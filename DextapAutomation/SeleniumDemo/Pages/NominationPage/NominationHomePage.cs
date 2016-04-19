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
         [FindsBy(How = How.Id, Using = "Mdd")]
        private IWebElement TxtMddFileUpload;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/proxy')]")]
        private IWebElement _lnkProxy;

        [FindsBy(How = How.Name, Using = "employee-lookup")]
        private IWebElement _txtName;

        [FindsBy(How = How.Id, Using = "25")]
        private IWebElement _iconThankYou;

        [FindsBy(How = How.ClassName, Using = "content employeeSelection")]
        private IWebElement _lnkEmployeeSelection;

        [FindsBy(How = How.Id, Using = "reward-detail-form-25-MESSAGE")]
        private IWebElement _txtMsg;

        [FindsBy(How = How.Id, Using = "reward-detail-form-25-REASON")]
        private IWebElement _txtReason;

        public NominationHomePage (IWebDriver driver) : base(driver) { }

        public NominationHomePage SearchEmployee(string employee)
        {
            Synchronization.WaitForElementToBePresent(_txtName);
            _txtName.SendKeys(employee);
            _lnkEmployeeSelection.Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage SelectAward()
        {
            Synchronization.WaitForElementsToBePresent(By.ClassName("content awardSelection recogAward"));
            _iconThankYou.Click();
            return NewPage<NominationHomePage>();
        }

        public NominationHomePage SelectValues()
        {
            IReadOnlyCollection<IWebElement> opciones = FindElements(By.ClassName("radioAward"));
            opciones.FirstOrDefault().Click();
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
    }
}
