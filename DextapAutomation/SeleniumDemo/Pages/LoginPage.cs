using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebDriverFramework.PageObject;
using WebDriverFramework.WebDriver;

namespace SeleniumDemo.Pages
{
    public class LoginPage : AbstractWebPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
        private IWebElement _txtUsername;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement _txtPassword;

        [FindsBy(How = How.Id, Using = "loginSubmit")]
        private IWebElement _btnLogin;

        [FindsBy(How = How.Id, Using = "footer")]
        private IWebElement LblFooter;

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage Go()
        {
            Navigate("http://demo.workstride.com//");
            return this;
        }

        public LoginPage EnterUsername(string username)
        {
            _txtUsername.SendKeys(username);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            _txtPassword.SendKeys(password);
            return this;
        }

        public MainHomePage Login()
        {
            _btnLogin.Click();
            Synchronization.WaitForElementToBePresent(
                By.XPath(
                    "//img[contains(@src,'http://demoassets.workstride.com/resources/images/milestone_logo_newHire_120x120.png')]"));
            Synchronization.WaitForElementToBePresent(By.Id("modal"));
            FindElement(By.XPath("//*[@id='modal']/div/div/a")).Click();
            return NewPage<MainHomePage>();
        }


        public bool VerifyVersion()
        {
            return (LblFooter.Text == "Dextap - Version 2.21.0");
        }

        public LoginPage Logon()
        {
            _btnLogin.Click();
            return this;
        }

        public bool LoginErrorMsg()
        {
            return (FindElement(By.ClassName("validation-summary-errors")).Displayed);
        }

        public LoginPage Go2()
        {
            Navigate("http://puppies.herokuapp.com/");
            return this;
        }
    }
}
