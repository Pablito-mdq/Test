using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests;
using SeleniumDemo.Tests.Pages;

namespace SeleniumDemo.Pages
{
    public class MainHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'RECOGNIZE')]")]
        private IWebElement _lnkNomination;
        
        [FindsBy(How = How.XPath, Using = "//li[contains(.,'RECOGNIZE')]")]
        private IWebElement _lnkNominationSprint;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'RECOGNIZE')]")]
        private IWebElement _lnkNominationPinnacola;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'javascript:void(0);')]")]
        private IWebElement _lnkDisplayOpt;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Go To Mall')]")]
        private IWebElement _lnkNavigateToMall;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'REDEEM')]")]
        private IWebElement _lnkNavigateToRedeem;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'myAcctLink')]")]
        private IWebElement _lnkMyAccount;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Event Calendar')]")]
        private IWebElement _lnkEventCalendar;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdmin;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Sign Out')]")]
        private IWebElement _lnkSignOut;
        
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
            return Synchronization.WaitForElementToBePresent(By.XPath("/html/body/div[1]/p")).Text;
        }

        public NominationHomePage NavigateToNomination()
        {
            Synchronization.WaitForElementToBePresent(_lnkNomination);
            if (_lnkNomination.Displayed)
                _lnkNomination.Click();
            return NewPage<NominationHomePage>();
        }

        public GoToMallHomePage NavigateToRedeem()
        {
            _lnkNavigateToRedeem.Click();
            return NewPage<GoToMallHomePage>();
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
            return Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//label[contains(.,'{0}')]", opt))).Text;
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
            if (Synchronization.WaitForElementToBePresent(By.XPath("//img[contains(@class,'announcementIcon')]"))!=null)
            return Synchronization.WaitForElementToBePresent(By.XPath("//img[contains(@class,'announcementIcon')]")) .Displayed;
            return false;
        }

        public MainHomePage ClosePopUp()
        {
            Thread.Sleep(1000);
            Synchronization.WaitForElementToBePresent(
                By.XPath(
                    "//img[contains(@src,'http://demoassets.workstride.com/resources/images/milestone_logo_newHire_120x120.png')]"));
            Synchronization.WaitForElementToBePresent(By.Id("modal"));
            FindElement(By.XPath("//*[@id='modal']/div/div/a")).Click();
            Thread.Sleep(1000);
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

        public ProxyHomePage ExitProxy()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Exit Proxy')]")).Click();
            return NewPage<ProxyHomePage>();
        }

        public EventCalendar NavigateToEventCalendar()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'calendar')]"));
            if (_lnkEventCalendar.Displayed)
                _lnkEventCalendar.Click();
            return NewPage<EventCalendar>();
        }

        public ProxyHomePage NavigateToAdminHomePagePinnacola()
        {
            Synchronization.WaitForElementToBePresent(_lnkAdmin);
            Synchronization.WaitForElementToBePresent(_lnkAdmin);
            if (_lnkAdmin.Displayed)
                _lnkAdmin.Click();
            return NewPage<ProxyHomePage>();
        }

        public string GetProxyLoginMsgPinnacol()
        {
            return (Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(@class,'proxy-blurb')]")).Text) + (Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='proxy-header']/div[1]/span[3]/strong")).Text);
        }

        public NominationHomePage NavigateToNominationPinnacola()
        {
            Synchronization.WaitForElementToBePresent(_lnkNominationPinnacola);
            if (_lnkNominationPinnacola.Displayed)
                _lnkNominationPinnacola.Click();
            return NewPage<NominationHomePage>();
        }

        public int GetAwardPoint()
        {
            string a= Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(@class,'points-value')]")).Text;
            return Int32.Parse(a);
        }

        public string GetLeftMenuOpts(int opt)
        {
            switch (opt)
            {
                case 0:
                   return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Recognize Someone')]")).Text;
                case 1:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/event_calendar')]")).Text;
                case 2:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Go To Mall')]")).Text;
                case 3:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'My Awards')]")).Text;
                case 4:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Pending Approvals')]")).Text;
                case 5:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/my_redemptions')]")).Text;
                case 6:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/customer_appreciation')]")).Text;
                case 7:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Recognize Caregiver')]")).Text;
                case 8:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/social_stream')]")).Text;
                case 9:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/my_activities')]")).Text;
                case 10:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/hierarchy')]")).Text;
                case 11:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Recognition Training')]")).Text;
                case 12:
                    return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(@href,'/report_builder')]")).Text;
            }
            return "The option is not Available or present in this client";
        }

        public MainHomePage ExpandMenuPinnacol()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//div[@class='collapseBtn content quickLinksBtn leftMenuLink']")).Click();
            return NewPage<MainHomePage>();
        }

        public LoginPage ClickLogOut()
        {
            _lnkSignOut.Click();
            return NewPage<LoginPage>();
        }

        public bool GetAllHttpLinkResponses()
        {
            using (var client = new WebClient())
            {
                byte[] imageData = client.DownloadData("http://qabaeimpact.workstride.net/welcome");
            }
            IWebElement[] links = FindElements(By.TagName("href")).ToArray();
            WebResponse error = null;
            for (int i = 0; i < links.Length; i++)
            {
                if (!isValidURL(links[i].Text, error))
                    Assert.Fail(links[i].Text + "has a Http error " + error);
                    return false;
            }
            return true;
        }

        public static bool isValidURL(string url,WebResponse error) 
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse;
            try
            {
                webResponse = webRequest.GetResponse();
                error = webResponse;
            }
            catch //If exception thrown then couldn't get response from address
            {
                return false ;
            }
            return true ;
           }

    }
}
