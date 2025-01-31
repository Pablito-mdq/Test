﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Pages.Login
{
    public class Register : AbstractWebPage
    {
        [FindsBy(How = How.Id, Using = "forgotPasswordSubmit")]
        private IWebElement _btnContinue;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'first_Name')]")]
        private IWebElement _txtFirstName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'last_Name')]")]
        private IWebElement _txtLastName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'company_Employee_Id')]")]
        private IWebElement _txtemployeeId;

        [FindsBy(How = How.Id, Using = "emailAddress")]
        private IWebElement _txtemailAddress;

        [FindsBy(How = How.XPath, Using = "//button[contains(@type,'submit')]")]
        private IWebElement _btnRegister;

        public Register(IWebDriver driver) : base(driver) { }

        public bool IsFirstNameFieldAvailable()
        {
            return _txtFirstName.Enabled && _txtFirstName.Displayed;
        }

        public bool IsLastNameAvailable()
        {
            return _txtLastName.Enabled && _txtLastName.Displayed;
        }

        public bool IsIDFieldAvailable()
        {
            return _txtemployeeId.Enabled && _txtemployeeId.Displayed;
        }

        public bool IsEmailFieldAvailable()
        {
            return _txtemailAddress.Enabled && _txtemailAddress.Displayed;
        }

        public bool IRegisterBtnAvailable()
        {
            return _btnRegister.Displayed && _btnRegister.Displayed;
        }

        public string GetName(string label)
        {
            return
                Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//label[contains(.,'{0}')]", label)))
                    .Text;
        }

        public Register EnterFirstName(string firstName)
        {
            _txtFirstName.SendKeys(firstName);
            return this;
        }

        public Register EnterLastName(string lastName)
        {
            _txtLastName.SendKeys(lastName);
            return this;
        }

        public Register EnterEmployeeID(string ID)
        {
            _txtemployeeId.SendKeys(ID);
            return this;
        }

        public Register EnterEmployeeEmail(string email)
        {
            _txtemailAddress.SendKeys(email);
            return this;
        }

        public Register ClickRegister()
        {
            _btnRegister.Click();
            return NewPage<Register>();
        }

        public string GetSuccessMsg()
        {
            Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[@id='ui-spinner-container']"));
            IWebElement msg = Synchronization.WaitForElementToBePresent(By.XPath("//p[contains(@id,'firstTimeDescription')]"));
            return msg.Text;
        }
    }
}
