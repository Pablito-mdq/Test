using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.Textron
{
    public class MainHomePageFail : WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "user_name")]
        private IWebElement _txtUsername;

        [FindsBy(How = How.XPath, Using = "password")]
        private IWebElement _txtPassword;

        [FindsBy(How = How.XPath, Using = "submit_button")]
        private IWebElement _btnLogon;

        public MainHomePageFail(IWebDriver driver) : base(driver) { }


        public MainHomePageFail FailLogon()
        {
            EnterUsername("failogin@workstride.com");
            EnterPassword("josecanseco");
            return this;
        }

        public MainHomePageFail EnterUsername(string username)
        {
            _txtUsername.SendKeys(username);
            return this;
        }

        public MainHomePageFail EnterPassword(string password)
        {
            _txtPassword.SendKeys(password);
            return this;
        }

        public MainHomePageFail ClickLogon(string password)
        {
            _btnLogon.Click();
            return this;
        }
    }
}
