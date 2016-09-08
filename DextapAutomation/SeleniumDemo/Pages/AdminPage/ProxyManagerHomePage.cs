using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Tests.Sprint
{
     public class ProxyManagerHomePage: WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "user-lookup")]
        private IWebElement _txtUserName;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement _btnProxy;

        [FindsBy(How = How.XPath, Using = "//button[contains(@type,'submit')]")]
        private IWebElement _btnProxySprint;

        [FindsBy(How = How.Id, Using = "proxy_user-lookup")]
        private IWebElement _txtUserNameSprint;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'proxy_submit-btn')]")]
        private IWebElement _btnProxyToMain;

        public ProxyManagerHomePage(IWebDriver driver) : base(driver) { }

        public string GetTitlePage()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(@id,'actionbar-pagename')]")).Text;
        }
    }
}
