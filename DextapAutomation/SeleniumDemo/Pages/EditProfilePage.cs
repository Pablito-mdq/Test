using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private IWebElement CboRegion;

        [FindsBy(How = How.Id, Using = "First")]
        private IWebElement TxtFirstName;

        [FindsBy(How = How.Id, Using = "Last")]
        private IWebElement TxtLastName;

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
            new SelectElement(CboRegion).SelectByText(region);
            return this;
        }

        public bool AreFieldsCorrectEnable()
        {
            if ((TxtFirstName.Enabled) && (TxtLastName.Enabled) && (CboOpCo.Enabled) && (CboRegion.Enabled))
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
               return new SelectElement(CboRegion).SelectedOption.Text;
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
    }
}
