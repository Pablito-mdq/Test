using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Tests
{
    public class EditProfilePage : WorkStridePage
    {
        [FindsBy(How = How.ClassName, Using = "readonlylabelstyle")]
        private IWebElement LblRole;

        [FindsBy(How = How.Id, Using = "Timezone")]
        private IWebElement CboTimeZones;

        [FindsBy(How = How.Id, Using = "save")]
        private IWebElement BtnSave;

        [FindsBy(How = How.Id, Using = "ui-dialog-title-dialog-modal")]
        private IWebElement ScrPopUp;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement TxtEmail;

        [FindsBy(How = How.XPath, Using = "//a[@href='/?Length=6']")]
        private IWebElement LnkTools;

        [FindsBy(How = How.XPath, Using = "//a[@href='/Profile']")]
        private IWebElement LnkProfile;

        [FindsBy(How = How.Id, Using = "Opco")]
        private IWebElement CboOpCo;

        [FindsBy(How = How.Id, Using = "Region")]
        private IWebElement _cboRegion;

        [FindsBy(How = How.Id, Using = "First")]
        private IWebElement TxtFirstName;

        [FindsBy(How = How.Id, Using = "Last")]
        private IWebElement TxtLastName;

        [FindsBy(How = How.Id, Using = "preferred_name")]
        private IWebElement _txtPreferredName;

        [FindsBy(How = How.Id, Using = "password_again")]
        private IWebElement _txtConfirmPassword;

        [FindsBy(How = How.Id, Using = "profile_submit")]
        private IWebElement _btnSubmit;
        
       public EditProfilePage(IWebDriver driver) : base(driver) { }

        public bool ScreenDisplay()
        {
            return LblRole.Displayed;
        }

        public bool TimeZonesDisplay()
        {
            return CboTimeZones.Displayed;
        }

        public EditProfilePage SelectTimezone(string timeZone)
        {
            new SelectElement(CboTimeZones).SelectByText(timeZone);
            return this;
        }

        public EditProfilePage Save()
        {
            BtnSave.Click();
            return this;
        }
        public EditProfilePage PopupConfirm()
        {
            IWebElement BtnOK = FindElement(By.XPath("//span[contains(@class, 'ui-button-text')]"));
            BtnOK.Click();
            return this;
        }

        public bool PopUpShows()
        {
            return (ScrPopUp.Displayed);
        }

        public EditProfilePage SelectOpCo(string opCo)
        {
            new SelectElement(CboOpCo).SelectByText(opCo);
            return this;
        }

        public EditProfilePage SelectRegion(string region)
        {
            new SelectElement(_cboRegion).SelectByText(region);
            return this;
        }

        public bool AreFieldsCorrectEnable()
        {
            if ((TxtFirstName.Enabled) && (TxtLastName.Enabled) && (CboOpCo.Enabled) && (_cboRegion.Enabled))
                if ((TxtEmail.Enabled) && (CboTimeZones.Enabled))
                             return true;
            return false;
        }

           public EditProfilePage EnterFirstName(string firstName)
           {
               TxtFirstName.Clear();
               TxtFirstName.SendKeys(firstName);
               return this;
           }
           public EditProfilePage EnterLastName(string lastName)
           {
               TxtLastName.Clear();
               TxtLastName.SendKeys(lastName);
               return this;
           }

           public bool IsErrorMsgShow()
           {
               return (FindElement(By.Id("validation-summary-errors")).Displayed);
           }
           public string GetTimeZone()
           {
               return new SelectElement(CboTimeZones).SelectedOption.Text;
           }

           public string GetEmailJob()
           {
               return TxtEmail.Text;
           }

           public string GetOpCo()
           {
               return new SelectElement(CboOpCo).SelectedOption.Text;
           }

           public string GetRegion()
           {
               return new SelectElement(_cboRegion).SelectedOption.Text;
           }

           public string GetFirstName()
           {
               return TxtFirstName.Text;
           }
           public string GetLastName()
           {
               return TxtLastName.Text;
           }

           public string PopUpMessageSpell()
           {
               return (FindElement(By.Id("dialog-modal")).Text);
           }

           public string GetTitleName(string title)
           {
               return Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Profile Settings')]")).Text;
           }

           public EditProfilePage EnterPreferedName(string preferredName)
           {
               _txtConfirmPassword.SendKeys("Demo9494");
               _txtPreferredName.SendKeys(preferredName);
               return this;
           }

           public EditProfilePage ClickSubmit()
           {
               _btnSubmit.Click();
               Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[@id='ui-spinner-container']"));
               return NewPage<EditProfilePage>();
           }

           public string GetShowName(string preferredName)
           {
               return
                   Synchronization.WaitForElementToBePresent(
                       By.XPath(string.Format("//b[contains(.,'{0}')]", preferredName))).Text;
           }
    }
}
