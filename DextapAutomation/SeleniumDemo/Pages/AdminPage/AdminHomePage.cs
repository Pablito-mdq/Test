using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Tests;
using SeleniumDemo.Tests.Pages;
using WebDriverFramework.PageObject;


namespace SeleniumDemo.Pages.AdminPage
{
    public class AdminHomePage : WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "Mdd")]
        private IWebElement TxtMddFileUpload;

        [FindsBy(How = How.XPath, Using = "//a[@href='/proxy']")] private IWebElement _lnkProxy;


        public AdminHomePage(IWebDriver driver) : base(driver) { }


        public AdminHomePage CopyMDDFile(string mmdName)
        {
            //ChkAutoCopyMDD.Click();
            //TxtMddName.SendKeys(mmdName);
            IWebElement BtnCopyMdd = FindElement(By.Id("AutoCopyStartButton"));
            BtnCopyMdd.Click();
            Synchronization.WaitForElementNotToBePresent(By.Id("progress-indicator"));
            return this;
        }

        public string GetTimeZone()
        {
            return new SelectElement(TxtMddFileUpload).SelectedOption.Text;
        }

        public string GetMddError()
        {
            Synchronization.WaitForElementToBePresent(By.Id("UploadDiv"));
            return (FindElement(By.Id("UploadDiv")).Text);
        }

        public string GetEmailJob()
        {
            return FindElement(By.Name("Emails[0].Address")).Text;
        }

        public string GetOpCo()
        {
            return new SelectElement(TxtMddFileUpload).SelectedOption.Text;
        }

        public string GetRegion()
        {
            return new SelectElement(TxtMddFileUpload).SelectedOption.Text;
        }

        public string GetDataMsg()
        {
            return TxtMddFileUpload.GetAttribute(GetTitle());
        }

        public ProxyHomePage LoginProxyAsuser()
        {
            _lnkProxy.Click();
            return NewPage<ProxyHomePage>();
        }
    }
}
