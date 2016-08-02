using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Pages.LeftMenu.GoToMall
{
    public class CheckOutPage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'FootLocker.png')]")] private IWebElement _imgFootLocker;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Checkout')]")]
        private IWebElement _btnCheckOut;


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

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'cardholder')]")]
        private IWebElement _txtCardName;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'cardmonth')]")]
        private IWebElement _cboCardMonth;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'cardyear')]")]
        private IWebElement _cboCardYear;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'cardcsc')]")]
        private IWebElement _txtCardCDI;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'sameAddress')]")]
        private IWebElement _chkBillingAddress;

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'sstate')]")]
        private IWebElement _cboState;

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
            Synchronization.WaitForElementToBePresent(_btnNext);
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

        public CheckOutPage FillCreditCardNumber(string creditcardnumber)
        {
            _txtCardNumber.SendKeys(creditcardnumber);
            return NewPage<CheckOutPage>();
        }

        public CheckOutPage FillCreditCardName(string creditcardname)
        {
            _txtCardName.SendKeys(creditcardname);
            return NewPage<CheckOutPage>();
        }

        public CheckOutPage SelectExpireDate(string month, string year)
        {
           new SelectElement(_cboCardMonth).SelectByText(month);
           new SelectElement(_cboCardYear).SelectByText(year);
           return this;
        }

        public CheckOutPage FillCreditCardCDI(string creditcardCDI)
        {
            _txtCardCDI.SendKeys(creditcardCDI);
            return this;
        }

        public CheckOutPage CheckSameBillingAddress()
        {
            _chkBillingAddress.Click();
            return this;
        }

        public string GetLastStep()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Review items')]")).Text;
        }

        public CheckOutPage ClickCheckOut()
        {
           _btnCheckOut.Click();
           Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[contains(@id,'ui-spinner-container')]"));
           return NewPage<CheckOutPage>();
        }

        public bool CannotEditEmail()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//input[contains(@type,'email')]")).GetAttribute("readonly").Equals("");
        }

        public CheckOutPage SelectState(string state)
        {
            new SelectElement(_cboState).SelectByText(state);
            return this;
        }

        public string GetNoCreditCardUseMsg()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(@class,'alignCenter ')]")).Text;
        }

        public string GetNoCreditCardUseMsgSubtitle()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//h5[contains(@class,'alignCenter ')]")).Text;
        }

        public string GetAmountChecked()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//h4[contains(.,'$25')]")).Text;
        }

        public string GetQuantityChecked()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//h4[contains(.,'1')]")).Text;
        }

        public CheckOutPage ClickNextPayment()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@class,'content alignCenter midBannerBtn billingNotRequiredBtn')]")).Click();
            return NewPage<CheckOutPage>();
        }
    }
}
