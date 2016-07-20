using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Tests.Pages;

namespace SeleniumDemo.Pages.AdminPage
{
    public class AdminHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='/proxy']")] private IWebElement _lnkProxy;


        public AdminHomePage(IWebDriver driver) : base(driver) { }

        public string GetMddError()
        {
            Synchronization.WaitForElementToBePresent(By.Id("UploadDiv"));
            return (FindElement(By.Id("UploadDiv")).Text);
        }

        public string GetEmailJob()
        {
            return FindElement(By.Name("Emails[0].Address")).Text;
        }

        public ProxyHomePage LoginProxyAsuser()
        {
            Synchronization.WaitForElementToBePresent(_lnkProxy);
            if (_lnkProxy.Displayed)
                 _lnkProxy.Click();
            return NewPage<ProxyHomePage>();
        }

        public bool IsShowNameAdmin(string preferredName)
        {
            if (
                Synchronization.WaitForElementToBePresent(
                    By.XPath(string.Format("//b[contains(.,'{0}')]", preferredName))) != null)
                return
                    Synchronization.WaitForElementToBePresent(
                        By.XPath(string.Format("//b[contains(.,'{0}')]", preferredName))).Text == preferredName;
            return false;

        }

        public MainHomePage ClosePopUp()
        {
           Synchronization.WaitForElementToBePresent(By.ClassName("closeParent")).Click();
            Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(.,'ADMIN')]"));
            return NewPage<MainHomePage>();
        }
    }
}
