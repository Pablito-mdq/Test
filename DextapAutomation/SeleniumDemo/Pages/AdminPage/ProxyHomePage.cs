using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Tests.Pages
{
    public class ProxyHomePage : WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "user-lookup")]
        private IWebElement _txtUserName;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement _btnProxy;

        public ProxyHomePage(IWebDriver driver) : base(driver) { }

        public ProxyHomePage EnterUserName(string name)
        {
            _txtUserName.SendKeys(name);
            Synchronization.WaitForElementToBePresent(By.Id("ui-id-1")).Click();
            return this;
        }

        public MainHomePage ProxyToMainHomePage()
        {
            Synchronization.WaitForElementNotToBePresent(By.Id("ui-id-1"));
           _btnProxy.Click();
            return NewPage<MainHomePage>();
        }
    }
}
