using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Pages
{
    public class HelpHomePage: WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "contact_us_first_name")]
        private IWebElement _txtFirstName;

        [FindsBy(How = How.Id, Using = "contact_us_last_name")]
        private IWebElement _txtLastName;

        [FindsBy(How = How.Id, Using = "contact_us_email")]
        private IWebElement _txtEmail;

        [FindsBy(How = How.Id, Using = "contact_us_nature_of_inquiry")]
        private IWebElement _cboInquiry;

        [FindsBy(How = How.Id, Using = "contact_us_comments")]
        private IWebElement _txtComments;

        [FindsBy(How = How.Id, Using = "contact_us_submit")]
        private IWebElement _btnSubmit;

        [FindsBy(How = How.Id, Using = "contact_us_order_id")]
        private IWebElement _txtOrderId;

        [FindsBy(How = How.Id, Using = "contact_us_month")]
        private IWebElement _cboMonth;

        [FindsBy(How = How.Id, Using = "contact_us_day")]
        private IWebElement _cboDay;

        [FindsBy(How = How.Id, Using = "contact_us_year")]
        private IWebElement _cboYear;

        [FindsBy(How = How.Id, Using = "contact_us_submission_success")]
        private IWebElement _lblSuccessfull;

        public HelpHomePage(IWebDriver driver) : base(driver) { }

        public HelpHomePage EnterFirstName(string firstname)
        {
            _txtFirstName.SendKeys(firstname);
            return this;
        }

        public HelpHomePage EnterLastName(string lastname)
        {
            _txtLastName.SendKeys(lastname);
            return this;
        }

        public HelpHomePage EnterEmail(string email)
        {
            _txtEmail.SendKeys(email);
            return this;
        }

        public HelpHomePage SelectCountry(string inquiry)
        {
            new SelectElement(_cboInquiry).SelectByText(inquiry);
            return this;
        }

        public HelpHomePage EnterInquiry(string inquiry)
        {
            _txtComments.SendKeys(inquiry);
            return this;
        }

        public HelpHomePage ClickSubmit()
        {
            _btnSubmit.Click();
            return NewPage<HelpHomePage>();
        }

        public string GetSuccessfullMsg()
        {
            Thread.Sleep(1500);
            Synchronization.WaitForElementToBePresent(_lblSuccessfull);
           return _lblSuccessfull.Text;
        }
    }
}
