using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.Reports
{
    public class ReportDetailsPage: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'All Awards')]")]
        private IWebElement _lnkAllAwardsLkn;

        public ReportDetailsPage(IWebDriver driver) : base(driver) { }
    }
}
