using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Models;
using SeleniumDemo.Pages.Login;
using SeleniumDemo.Utils;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Pages
{
    public class LoginPage : AbstractWebPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@name='username']")] private IWebElement _txtUsername;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")] private IWebElement _txtPassword;

        [FindsBy(How = How.Id, Using = "loginSubmit")] private IWebElement _btnLogin;

        [FindsBy(How = How.Id, Using = "passwordSelect")] private IWebElement _lnkForgotpassword;

        [FindsBy(How = How.Id, Using = "registerSelect")] private IWebElement _lnkJoinNow;

        [FindsBy(How = How.XPath, Using = "//a[@href='/logout']")]
        private IWebElement _lnkSignout;

        [FindsBy(How = How.Id, Using = "languageSelect")]
        private IWebElement _lnkLanguage;

        [FindsBy(How = How.Id, Using = "contactUsLink")]
        private IWebElement _lnkContactUs;

        [FindsBy(How = How.XPath, Using = "//label[contains(@for,'username')]")] private IWebElement _lblUsername;

        [FindsBy(How = How.XPath, Using = "//label[contains(@for,'password')]")]
        private IWebElement _lblPassword;

        [FindsBy(How = How.Id, Using = "companyId")]
        private IWebElement _txtCompnayId;

        [FindsBy(How = How.Id, Using = "homebody")]
        private IWebElement _imgHome;


        public LoginPage(IWebDriver driver) : base(driver){}

        public LoginPage Go()
        {
            string client = ConfigUtil.ImportClient("Resources\\Config.xml");
            Navigate(client != ""
                ? string.Format("{0}", ConfigUtil.ImportConfigURL("Resources\\" + client + "\\Url.xml", client))
                : ConfigUtil.ImportConfigURL("Resources\\Url.xml", "WorkStride"));
            return this;
        }

        public string GetUrl(string file)
        {
            return GeneralData.GetUrl(file);
        }

        public LoginPage GoSpecial(string file)
        {
            Navigate(string.Format("{0}",GetUrl(file)));
            return this;
        }

        public LoginPage EnterUsername()
        {
            _txtUsername.SendKeys(ConfigUtil.ImportConfigUsername("Resources\\Config.xml"));
            return this;
        }

        public LoginPage EnterPassword()
        {
            _txtPassword.SendKeys(ConfigUtil.ImportConfigPassword("Resources\\Config.xml"));
            return this;
        }

        public MainHomePage ClickLogin()
        {
            _btnLogin.Click();
            if (FindElement(
                By.XPath(
                    "//img[contains(@src,'http://demoassets.workstride.com/resources/images/milestone_logo_newHire_120x120.png')]")) !=
                null)
            {
                Synchronization.WaitForElementToBePresent(By.Id("modal"));
                FindElement(By.XPath("//*[@id='modal']/div/div/a")).Click();
            }
            return NewPage<MainHomePage>();
        }

        public LoginPage Logon()
        {
            EnterUsername();
            EnterPassword();
            return this;
        }

        public bool LoginErrorMsg()
        {
            return (FindElement(By.ClassName("validation-summary-errors")).Displayed);
        }

        public bool Imlogin()
        {
            if (FindElement(By.XPath("//span[@class='name']"))!= null)
            {
                FindElement(By.XPath("//span[@class='name']")).Click();
                return Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(.,'Sign Out')]")).Displayed;
            }
           return _lnkSignout.Displayed;
        }

        public string GetFailLoginMsg()
        {
            return FindElement(By.ClassName("errormessage")).Text;
        }

        public LoginPage FailLogon()
        {
            _txtUsername.SendKeys("failogin@workstride.com");
            _txtPassword.SendKeys("Fail");
            return this;
        }

        public ForgotPassword ClickForgotPassword()
        {
            _lnkForgotpassword.Click();
            return NewPage<ForgotPassword>();
        }

        public Register ClickJoinNow()
        {
            _lnkJoinNow.Click();
            return NewPage<Register>();
        }

        public Language ClickLanguage()
        {
            _lnkLanguage.Click();
            return NewPage<Language>();
        }

        public ContactUs ClickContactUs()
        {
            _lnkContactUs.Click();
            return NewPage<ContactUs>();
        }

        public string GetUsernameTitle()
        {
            return _lblUsername.Text;
        }

        public bool IsUsernameFieldAvl()
        {
           return _txtUsername.Displayed && _txtUsername.Enabled;
        }

        public bool IsPasswordFieldAvl()
        {
            return _txtPassword.Displayed && _txtPassword.Enabled;
        }

        public string GetPasswordTitle()
        {
            return _lblPassword.Text;
        }

        public string GetUsernameTitleGeneric()
        {
            return FindElement(By.XPath("//label[contains(.,'Email Address')]")).Text;
        }

        public string GetPasswordTitleGeneric()
        {
            return FindElement(By.XPath("//label[contains(.,'Password')]")).Text;
        }

        public bool WasFailLogin()
        {
            RefreshPOM();
            return
                Synchronization.WaitForElementToBePresent(
                    By.XPath(
                        "//img[contains(@src,'/uniquesige701280c033979c9e76c0de72cbdb3f8/uniquesig0/InternalSite/images/customupdate/textron.jpg')]"))
                    .Displayed;
        }

        public object GetFailLoginMsgTextron()
        {
            return FindElement(By.ClassName("errormsg")).Text;
        }

        public LoginPage FailLogonTextron()
        {
            FindElement(By.XPath("//input[@id='user_name']")).SendKeys("failogin@workstride.com");
            FindElement(By.XPath("//input[@name='password']")).SendKeys("Fail");
            return this;
        }

        public LoginPage ClickLoginTextron()
        {
            FindElement(By.XPath("//input[@id='submit_button']")).Click();
            return this;
        }

        public LoginPage EnterId(string client)
        {
            if (client == "Sprint")
            _txtCompnayId.SendKeys("474");
            if (client == "Sungard")
                _txtCompnayId.SendKeys("478");
            return this;
        }
       
        public bool IshomePageLoadingRightImg(string p)
        {
            var src = _imgHome.GetAttribute("style");
            return src.Contains(p);
        }

        public bool ImgVisible()
        {
            return _imgHome.Displayed && _imgHome.Enabled;
        }
    }
}
