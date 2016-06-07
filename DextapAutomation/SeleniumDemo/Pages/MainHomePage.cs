using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests;

namespace SeleniumDemo.Pages
{
    public class MainHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'RECOGNIZE')]")]
        private IWebElement _lnkNomination;
        
        [FindsBy(How = How.XPath, Using = "//li[contains(.,'RECOGNIZE')]")]
        private IWebElement _lnkNominationSprint;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'javascript:void(0);')]")]
        private IWebElement _lnkDisplayOpt;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Go To Mall')]")]
        private IWebElement _lnkNavigateToMall;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'myAcctLink')]")]
        private IWebElement _lnkMyAccount;

        public MainHomePage(IWebDriver driver) : base(driver) { }

        public MainHomePage SelectShowEntries(string entries)
        {
            new SelectElement(_lnkNomination).SelectByText(entries);
            return this;
        }

        public string GetShowEntries()
        {
            return new SelectElement(_lnkNomination).SelectedOption.Text;
        }

        public string GetProxyLoginMsg()
        {
            return FindElement(By.XPath("/html/body/div[1]/p")).Text;
        }

        public NominationHomePage NavigateToNomination()
        {
            Synchronization.WaitForElementToBePresent(_lnkNomination);
            if (_lnkNomination.Displayed)
                _lnkNomination.Click();
            return NewPage<NominationHomePage>();
        }

        public GoToMallHomePage NavigateToMall()
        {
            _lnkNavigateToMall.Click();
           return NewPage<GoToMallHomePage>();
        }

        public string GetExitMsg()
        {
            return FindElement(By.XPath("//a[contains(.,'Exit Proxy')]")).Text;
        }

        public MainHomePage ClickDisplayOptions()
        {
            _lnkDisplayOpt.Click();
            return NewPage<MainHomePage>();
        }

        public bool IDatePickerAvailable()
        {
            IWebElement calendar = FindElement(By.XPath("//input[@name='relativeDate']"));
            calendar.Click();
            return Synchronization.WaitForElementToBePresent(By.ClassName("ui-datepicker-calendar")).Displayed;
        }

        public string GetShowOptTxt(string opt)
        {
            return FindElement(By.XPath(string.Format("//label[contains(.,'{0}')]", opt))).Text;
        }

        public MainHomePage ClickSocialStream()
        {
            FindElements(By.XPath("//img[contains(@src,'http://demoassets.workstride.com/resources/companies/workstride/employeeUploads/default/profileDefault.jpg')]")).FirstOrDefault().Click();
            return NewPage<MainHomePage>();
        }

        public bool IsDetailsBtnAvalb()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recContainer']/div[2]/div/div[2]/div/div[2]/div/h5")).Displayed;
        }

        public MainHomePage ClickDetails()
        {
            FindElement(By.XPath("//*[@id='recContainer']/div[2]/div/div[2]/div/div[2]/div/h5")).Click();
            return NewPage<MainHomePage>();
        }

        public bool IsbtnSeeMoreAvl()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//button[contains(.,'See More')]")).Displayed;
        }

        public bool IsPopUpRecognitionShow()
        {
            return
                Synchronization.WaitForElementToBePresent(By.XPath("//img[contains(@class,'announcementIcon')]"))
                    .Displayed;
        }

        public MainHomePage ClosePopUp()
        {
            FindElement(
                By.XPath(
                    "//img[contains(@src,'http://demoassets.workstride.com/resources/images/milestone_logo_newHire_120x120.png')]"));
            Synchronization.WaitForElementToBePresent(By.Id("modal"));
            FindElement(By.XPath("//*[@id='modal']/div/div/a")).Click();
            return NewPage<MainHomePage>();
        }

        public PendingApprovals ClickHereAwardPopUp()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Click Here')]")).Click();
            return NewPage<PendingApprovals>();
        }

        public NominationHomePage NavigateToNominationSprint()
        {
            Synchronization.WaitForElementToBePresent(_lnkNominationSprint);
            if (_lnkNominationSprint.Displayed)
                _lnkNominationSprint.Click();
            return NewPage<NominationHomePage>();
        }

        public EditProfilePage EditProfile()
        {
            _lnkMyAccount.Click();
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/settings')]")).Click();
            return NewPage<EditProfilePage>();
        }

        public string GetWelcomeTitle()
        {
            return Synchronization.WaitForElementToBePresent(By.ClassName("mall-top-link")).Text;
        }

        public bool IsAdmLnkPresent()
        {
            if (FindElement(By.XPath("//a[contains(.,'ADMIN')]")) != null)
                return FindElement(By.XPath("//a[contains(.,'ADMIN')]")).Displayed;
            return false;
        }
    }
}
