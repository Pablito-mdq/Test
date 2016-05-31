using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Pages.Login
{
    public class ForgotPassword : AbstractWebPage
    {
        [FindsBy(How = How.XPath, Using = "//a[@href='/logout']")]
        private IWebElement _lnkSignout;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _txtEmail;

        [FindsBy(How = How.Id, Using = "forgotPasswordSubmit")]
        private IWebElement _btnContinue;

        [FindsBy(How = How.Id, Using = "forgotError")]
        private IWebElement _lblChangepwd;

        public ForgotPassword(IWebDriver driver) : base(driver) { }

        public bool IsEmailFieldAvailable()
        {
            return _txtEmail.Enabled && _txtEmail.Displayed;
        }

        public bool IsBtnContinueAvailable()
        {
            return _btnContinue.Enabled && _btnContinue.Displayed;
        }

        public string GetLabelTitle()
        {
            return FindElement(By.XPath("//*[@id='innerPasswordReset']/h3")).Text;
        }

        public string GetLabelSubTitle()
        {
            return _lblChangepwd.Text;
        }

        public string GetBtnContinueTxt()
        {
            return _btnContinue.GetAttribute("value");
        }
    }
}
