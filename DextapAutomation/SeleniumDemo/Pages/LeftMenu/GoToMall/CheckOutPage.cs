using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Pages.LeftMenu.GoToMall
{
    public class CheckOutPage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'FootLocker.png')]")] private IWebElement _imgFootLocker;

        [FindsBy(How = How.XPath, Using = "//a[@href='/mall/checkout']")] private IWebElement _btnCheckOut;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'sfname')]")]
        private IWebElement _txtfirstName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'slname')]")]
        private IWebElement _txtLastName;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'saddress1')]")]
        private IWebElement _txtAddres;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'scity')]")]
        private IWebElement _txtcity;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'szip')]")]
        private IWebElement _txtZip;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'sphone')]")]
        private IWebElement _txtphone;

        [FindsBy(How = How.XPath, Using = "//a[@class='content alignCenter midBannerBtn shipAddressBtn']")]
        private IWebElement _btnNext;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'cardnumber')]")]
        private IWebElement _txtCardNumber;

        public CheckOutPage(IWebDriver driver) : base(driver){}

        public CheckOutPage FillName(string word)
        {
            _txtfirstName.Clear();
            _txtfirstName.SendKeys(word);
            return this;
        }

        public CheckOutPage FillLastName(string word)
        {
            _txtLastName.Clear();
            _txtLastName.SendKeys(word);
            return this;
        }

        public CheckOutPage FillAddress(string word)
        {
            _txtAddres.Clear();
            _txtAddres.SendKeys(word);
            return this;
        }

        public CheckOutPage FillCity(string word)
        {
            _txtcity.Clear();
            _txtcity.SendKeys(word);
            return this;
        }

        public CheckOutPage FillZipCode(string word)
        {
            _txtZip.Clear();
            _txtZip.SendKeys(word);
            return this;
        }

        public CheckOutPage FillPhoneNumber(string word)
        {
            _txtphone.Clear();
            _txtphone.SendKeys(word);
            return this;
        }

        public CheckOutPage ClickNext()
        {
            _btnNext.Click();
            return NewPage<CheckOutPage>();
        }

        public bool IsPaymentOptionAvailable()
        {
            Synchronization.WaitForElementToBePresent(_txtCardNumber);
            return _txtCardNumber.Enabled && _txtCardNumber.Displayed;
        }

        public string GetErrorMsgFirstName()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//label[contains(@id,'sfname-error')]")).Text;
        }


        public string GetErrorMsgLastName()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//label[contains(@id,'slname-error')]")).Text;
        }
    }
}
