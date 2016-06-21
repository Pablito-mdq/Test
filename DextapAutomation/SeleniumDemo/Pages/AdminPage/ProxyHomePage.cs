using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages;

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
            if (Synchronization.WaitForElementToBePresent(By.Id("ui-id-1"))!=null)
                Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//div[contains(.,'{0}')]",name))).Click();
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
    }
}
