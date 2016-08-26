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

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'btn-generic reload')]")]
        private IWebElement _btnReloadCard;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Check VISA Card Balance')]")]
        private IWebElement _btnCheckVisabalance;

        public VisaCenterHomePage(IWebDriver driver) : base(driver) { }

        public bool IsReloadYourCardPresent()
        {
            if  (FindElement(By.XPath("//div[contains(@class,'btn-generic reload')]")) != null)
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
    }
}
