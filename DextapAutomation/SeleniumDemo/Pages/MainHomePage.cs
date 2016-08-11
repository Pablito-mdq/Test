using System;
using System.Linq;
using System.Net;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests;
using SeleniumDemo.Tests.Pages;
using NUnit.Framework;
using WebDriverFramework.PageObject;
using Action = Gallio.Common.Action;

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

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'REDEEM')]")]
        private IWebElement _lnkNavigateToRedeemA;

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

        public GoToMallHomePage NavigateToRedeemA()
        {
            _lnkNavigateToRedeemA.Click();
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

        public NominationHomePage NavigateToNominationSpan()
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

        public bool GetResponse(string extension,string url)
        {
            string a = url + "/" + extension;
            HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create(a);
            // Sends the HttpWebRequest and waits for a response.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();
            if (myHttpWebResponse.StatusCode != HttpStatusCode.OK)
                Assert.Fail("\r\nResponse Status Code is not OK and StatusDescription is: {0}",
                    myHttpWebResponse.StatusDescription);
            // Releases the resources of the response.
            myHttpWebResponse.Close();
            return true;
        }

        public bool GetAllHttpLinkResponses(string url)
        {
            IWebElement a = Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(.,'REDEEM')]"));
            IWebElement b = Synchronization.WaitForElementToBePresent(By.LinkText("//span[contains(.,'HOME')]"));
            IWebElement c = Synchronization.WaitForElementToBePresent(By.LinkText("//span[contains(.,'RECOGNIZE')]"));
            IWebElement d = Synchronization.WaitForElementToBePresent(By.LinkText("//span[contains(.,'HELP')]"));
            IWebElement e = Synchronization.WaitForElementToBePresent(By.LinkText("//span[contains(.,'REPORTS')]"));
            IWebElement f = Synchronization.WaitForElementToBePresent(By.LinkText("//span[contains(.,'ADMIN')]"));
            IWebElement g = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Sign Out')]"));
            IWebElement h = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Go To Mall')]"));
            IWebElement i = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Recognize Someone')]"));
            IWebElement j = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Event Calendar')]"));
            IWebElement k = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Pending Approvals')]"));
            IWebElement l = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'My Awards')]"));
            IWebElement m = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'My Redemptions')]"));
            IWebElement n = Synchronization.WaitForElementToBePresent(By.XPath("//img[contains(@src,'company.png')]"));
            if (Synchronization.WaitForElementToBePresent(By.XPath("/html/body/div[2]/div/div[1]/div[7]")) != null)
                Synchronization.WaitForElementToBePresent(By.XPath("/html/body/div[2]/div/div[1]/div[7]")).Click();
            IWebElement o = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Creating Contest')]"));
            IWebElement p = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'iRecognize Program Overview')]"));
            IWebElement q = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Reward Award Guidelines')]"));
            IWebElement r = Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'REDEEM')]"));
            IWebElement s = Synchronization.WaitForElementToBePresent(By.LinkText("//a[contains(.,'HOME')]"));
            IWebElement t = Synchronization.WaitForElementToBePresent(By.LinkText("//a[contains(.,'RECOGNIZE')]"));
            IWebElement u = Synchronization.WaitForElementToBePresent(By.LinkText("//a[contains(.,'HELP')]"));
            IWebElement v = Synchronization.WaitForElementToBePresent(By.LinkText("//a[contains(.,'REPORTS')]"));
            IWebElement w = Synchronization.WaitForElementToBePresent(By.LinkText("//a[contains(.,'ADMIN')]"));
            // Creates an HttpWebRequest for the specified URL. 
            if ((a != null) || (h != null) || (r!=null))
                if (!GetResponse("mall", url))
                    return false;
            if ((b != null) || (n != null) || (s != null))
                if (!GetResponse("welcome", url))
                    return false;
            if ((c != null) || (i != null) || (t != null))
                if (!GetResponse("nomination", url))
                    return false;
            if ((d != null) || (u != null))
                if (!GetResponse("help", url))
                    return false;
            if ((e != null) || (v != null))
                if (!GetResponse("reports", url))
                    return false;
            if ((f != null) || (s != null))
                if (!GetResponse("proxy", url))
                    return false;
            if (g != null)
                if (!GetResponse("logout", url))
                    return false;
            if (j != null)
                if (!GetResponse("event_calendar", url))
                    return false;
            if (k != null)
                if (!GetResponse("approval", url))
                    return false;
            if (l != null)
                if (!GetResponse("my_awards", url))
                    return false;
            if (m != null)
                if (!GetResponse("my_redemptions", url))
                    return false;
            if (o != null)
                if (!GetResponse("resources/companies/irecognize//RecognitionToolkit/Creating_Contest.pdf", url))
                    return false;
            if (p != null)
                if (!GetResponse("resources/companies/irecognize//RecognitionToolkit/iRecognizeProgramOverview.pdf", url))
                    return false;
            if (q != null)
                if (!GetResponse("resources/companies/irecognize//RecognitionToolkit/RewardAwardGuidelines.pdf", url))
                    return false;
            return true;
        
      }

        public bool IsEveryoneSelected()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//p[contains(.,'Everyone')]")).Displayed;
        }

        public MainHomePage ClickCheers()
        {
            Actions.MoveToElement(Synchronization.WaitForElementsToBePresent(By.XPath("//h4[contains(@class,'center-align')]")).ElementAt(4));
            Actions.MoveToElement(Synchronization.WaitForElementsToBePresent(By.XPath("//h4[contains(@class,'center-align')]")).FirstOrDefault());
            Thread.Sleep(500);
            Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recContainer']/div[1]/div/div[8]/div/div[1]/div/h5")).Click();
            return NewPage<MainHomePage>();
        }

        public string CheersCount()
        {
            return Synchronization.WaitForElementToBePresent(By.Id("cheerCount502467")).Text;
        }

        public string CongratsCount()
        {
                  if(Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recContainer']/div[1]/div/div[5]/div[2]/div/div"))!=null)
                      return Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recContainer']/div[1]/div/div[5]/div[2]/div/div")).Text;
            return 0.ToString();
        }

        public MainHomePage ClickCongrats()
        {
            Actions.MoveToElement(Synchronization.WaitForElementsToBePresent(By.XPath("//h4[contains(@class,'center-align')]")).ElementAt(4));
            Actions.MoveToElement(Synchronization.WaitForElementsToBePresent(By.XPath("//h4[contains(@class,'center-align')]")).FirstOrDefault());
            Thread.Sleep(500);
            Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recContainer']/div[1]/div/div[8]/div/div[2]/div/h5")).Click();
            return NewPage<MainHomePage>();
        }

        public MainHomePage AddCongrats(string p)
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//textarea[contains(@class,'congratsInput')]")).SendKeys(p);
            return this;
        }

        public string GetCongratsMsg()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Your message has been sent!')]")).Text;
        }

        public MainHomePage SendCongrats()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//input[contains(@value,'Send')]")).Click();
            return NewPage<MainHomePage>();
        }

        public MainHomePage ClickFollow()
        {
            Actions.MoveToElement(Synchronization.WaitForElementsToBePresent(By.XPath("//h4[contains(@class,'center-align')]")).ElementAt(3));
            Actions.MoveToElement(Synchronization.WaitForElementsToBePresent(By.XPath("//h4[contains(@class,'center-align')]")).FirstOrDefault());
            Thread.Sleep(500);
            Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recContainer']/div[1]/div/div[2]/div/div[1]/div/h5")).Click();
            return NewPage<MainHomePage>();
        }

        public bool IsFollowBannerPresent()
        {
            Thread.Sleep(1500);
            Actions.MoveToElement(Synchronization.WaitForElementsToBePresent(By.XPath("//h4[contains(@class,'center-align')]")).ElementAt(3));
            Actions.MoveToElement(Synchronization.WaitForElementsToBePresent(By.XPath("//h4[contains(@class,'center-align')]")).FirstOrDefault());
            if (Synchronization.WaitForElementToBePresent(By.XPath("//div[contains(@class,'follow-ribbon')]")) != null)
                return
                    Synchronization.WaitForElementToBePresent(By.XPath("//div[contains(@class,'follow-ribbon')]"))
                        .Displayed;
            return false;
        }

        public string GetFollowingRibbonMsg()
        {
            Thread.Sleep(1500);
           return Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='recContainer']/div[1]/div/div[1]/div")).Text;
        }

        public int GetBudget()
        {
            var a = Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(@id,'navBudget')]")).Text;
            return Int32.Parse(a);
        }

        public string GetProxyLoginMsgSprint()
        {
            string a = Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(@class,'proxy-blurb')]")).Text;
            string b = Synchronization.WaitForElementToBePresent(By.XPath("//span[contains(@class,'proxy-user-name')]")).Text;
            return a + b;
        }

        public string CheersCountSungard()
        {
            return Synchronization.WaitForElementToBePresent(By.Id("cheerCount1148258")).Text;
        }
    }
}
