using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Pages.LeftMenu.MyRedemption
{
    public class SendAppreciationPage: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdmin;

        public SendAppreciationPage(IWebDriver driver) : base(driver) { }
    }
}
