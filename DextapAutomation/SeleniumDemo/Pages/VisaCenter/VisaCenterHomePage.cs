using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.VisaCenter
{
    public class VisaCenterHomePage: WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "password_again")]
        private IWebElement _txtConfirmPassword;

        [FindsBy(How = How.Id, Using = "profile_submit")]
        private IWebElement _btnSubmit;

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'RELOAD YOUR CARD')]")]
        private IWebElement _btnReloadCard;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Check VISA Card Balance')]")]
        private IWebElement _btnCheckVisabalance;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'balance')]")]
        private IWebElement _lblBalance;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'amount')]")]
        private IWebElement _txtEnterAmount;

        public VisaCenterHomePage(IWebDriver driver) : base(driver) { }

        public bool IsReloadYourCardPresent()
        {
            if (FindElement(By.XPath("//button[contains(.,'RELOAD YOUR CARD')]")) != null)
                return true;
            return false;
        }

        public bool IsCheckVisaCardBalance()
        {
            if (FindElement(By.XPath("//a[contains(.,'Check VISA Card Balance')]")) != null)
                return true;
            return false; 
        }

        public bool IsSubmitAClaimPresent()
        {
             if  (FindElement(By.XPath("//div[contains(@ui-sref,'challenges')]" ))!= null)
                return true;
            return false;
        }

        public float GetBalance()
        {
            var a = _lblBalance.Text;
            var b = a.Substring(30, 7);
            return float.Parse(b);
        }

        public bool IsAmountFieldAvl()
        {
            return _txtEnterAmount.Displayed && _txtEnterAmount.Enabled;
        }

        public VisaCenterHomePage EnterAmount(string p)
        {
            _txtEnterAmount.SendKeys(p);
            return this;
        }

        public VisaCenterHomePage ClickReloadCard()
        {
            _btnReloadCard.Click();
            Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(.,'OK')]")).Click();
            Synchronization.WaitForElementsNotToBePresent(By.XPath("//button[contains(@class,'btn-generic reload loading')]"));
            Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(@class,'btn-generic reload success')]"));
            Refresh();
            return NewPage<VisaCenterHomePage>();
        }
    }
}
