using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu.MyRedemption
{
    public class MyRedemptions : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdmin;

        public MyRedemptions(IWebDriver driver) : base(driver) { }
    }
}
