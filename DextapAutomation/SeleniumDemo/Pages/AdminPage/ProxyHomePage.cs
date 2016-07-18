using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages;
using SeleniumDemo.Tests.Sprint;

namespace SeleniumDemo.Tests.Pages
{
    public class ProxyHomePage : WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "user-lookup")]
        private IWebElement _txtUserName;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement _btnProxy;

        [FindsBy(How = How.XPath, Using = "//button[contains(@type,'submit')]")]
        private IWebElement _btnProxySprint;

        [FindsBy(How = How.Id, Using = "proxy_user-lookup")]
        private IWebElement _txtUserNameSprint;

        public ProxyHomePage(IWebDriver driver) : base(driver) { }

        public ProxyHomePage EnterUserName(string name)
        {
            _txtUserName.SendKeys(name);
            if (Synchronization.WaitForElementToBePresent(By.Id("ui-id-1")) != null)
                Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//div[contains(.,'{0}')]", name))).Click();
            else
                Assert.Fail("User was not found");
            return this;
        }

        public MainHomePage ProxyToMainHomePage()
        {
            Synchronization.WaitForElementNotToBePresent(By.Id("ui-id-1"));
            _btnProxy.Click();
            return NewPage<MainHomePage>();
        }

        public bool IsAdminLoginUsernameLevel(string preferedName)
        {
            if (FindElement(By.XPath(string.Format("//b[contains(.,'{0}')]", preferedName))) != null)
                return FindElement(By.XPath(string.Format("//b[contains(.,'{0}')]", preferedName))).Displayed;
            return false;
        }

        public ProxyHomePage ClickOptionProxy(string s)
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//i[contains(@class,'fa fa-3x fa-user-secret')]"));
            IWebElement[] a = Synchronization.WaitForElementsToBePresent(By.XPath("//div[contains(@class,'valign center')]")).ToArray();
            if (s == "Proxy")
                a[0].Click();
            return NewPage<ProxyHomePage>();
        }

        public BulkAward ClickOptionBulk(string s)
        {
            Thread.Sleep(1500);
            Synchronization.WaitForElementToBePresent(By.XPath("//i[contains(@class,'fa fa-3x fa-user-secret')]"));
            if (s == "Bulk Award Upload")
                Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//*[@id='container']/div/div/div/div[1]/div/div/div", s))).Click();
            return NewPage<BulkAward>();
        }


        public MainHomePage ProxyToMainHomePageSprint()
        {
            Synchronization.WaitForElementNotToBePresent(By.Id("ui-id-1"));
            _btnProxySprint.Click();
            return NewPage<MainHomePage>();
        }

        public ProxyHomePage EnterUserNameProxySprint2(string user)
        {
            _txtUserNameSprint.SendKeys(user);
            if (Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//li[@class='proxy_user-result']", user))) != null)
                Synchronization.WaitForElementToBePresent(By.XPath("//li[@class='proxy_user-result']")).Click();
            else
                Assert.Fail("User was not found");
            return this;
        }
    }
}
