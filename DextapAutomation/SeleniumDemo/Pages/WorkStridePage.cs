using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.LeftMenu.MyRedemption;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Pages.VisaCenter;
using SeleniumDemo.Tests;
using SeleniumDemo.Tests.HSS;
using SeleniumDemo.Tests.Pages;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Pages
{
    public class WorkStridePage : AbstractWebPage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'REDEEM')]")]
        private IWebElement _lnkNavigateReedem;
        
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'REPORTS')]")]
        private IWebElement _lnkReports;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Cart')]")]
        private IWebElement _lnkCart;

        [FindsBy(How = How.XPath, Using = "//li[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdminLi;
    
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/my_awards')]")]
        private IWebElement _lnkMyAwards;

        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'company.png')]")]
        private IWebElement _lnkHomePage;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdmin;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdminSpan;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/approval')]")]
        private IWebElement _lnkPending;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/my_redemptions')]")]
        private IWebElement _lnkMyRedemptions;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/customer_appreciation')]")]
        private IWebElement _lnkSendAppreciation;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'RECOGNIZE')]")]
        private IWebElement _lnkNomination;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'My Activity')]")]
        private IWebElement _lnkMyActivities;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'View Hierarchy')]")]
        private IWebElement _lnkViewHierarchy;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/social_stream')]")]
        private IWebElement _lnkSocialStream;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Recognition Training')]")]
        private IWebElement _lnkRecognitionTraining;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/report_builder')]")]
        private IWebElement _lnkReportBuilder;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'REPORTS')]")]
        private IWebElement _lnkReportsMain;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Visa Center')]")]
        private IWebElement _lnkVisaCenter;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Sign Out')]")]
        private IWebElement _lnkSignOut;

        public WorkStridePage(IWebDriver driver) : base(driver) { }

       public MainHomePage NavigateToHomePage()
       {
           Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[contains(@id,'ui-spinner-container')]"));
          _lnkHomePage.Click();
          return NewPage<MainHomePage>();
       }

       public ProxyHomePage NavigateToAdminHomePagePinnacola()
       {
           Synchronization.WaitForElementToBePresent(_lnkAdmin);
           if (_lnkAdmin.Displayed)
               _lnkAdmin.Click();
           return NewPage<ProxyHomePage>();
       }

       public AdminHomePage NavigateToAdminHomePage()
       {
           _lnkAdmin.Click();
           return NewPage<AdminHomePage>();
       }

       public ProxyHomePage NavigateToAdminHomePageSpan()
       {
           Synchronization.WaitForElementToBePresent(_lnkAdminSpan);
           _lnkAdminSpan.Click();
           return NewPage<ProxyHomePage>();
       }

        public RewardsHomePage NavigateToRewardsHomePage()
        {
            Synchronization.WaitForElementToBePresent(By.Id("modal"));
            FindElement(By.XPath("//*[@id='modal']/div/div/a")).Click();
            Synchronization.WaitForElementToBePresent(_lnkNavigateReedem);
            _lnkNavigateReedem.Click();
            return NewPage<RewardsHomePage>();
        }

        public MyAwards NavigateToMyAwards()
        {
            Synchronization.WaitForElementNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            Thread.Sleep(2500);
            Synchronization.WaitForElementToBePresent(_lnkMyAwards);
            _lnkMyAwards.Click();
            return NewPage<MyAwards>();
        }

        public ReportsPage NavigateToReports()
        {
            _lnkReports.Click();
            Synchronization.WaitForElementToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            Thread.Sleep(4500);
            Synchronization.WaitForElementNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            return NewPage<ReportsPage>();
        }

        public PendingApprovals NavigateToPendingApprovals()
        {
            _lnkPending.Click();
            return NewPage<PendingApprovals>();
        }

        public MyRedemptions NavigateToMyRedemptions()
        {
            _lnkMyRedemptions.Click();
            return NewPage<MyRedemptions>();
        }

        public SendAppreciationPage NavigateToSendAppreciation()
        {
            _lnkSendAppreciation.Click();
            return NewPage<SendAppreciationPage>();
        }

        public NominationHomePage NavigateToNominationCaregiver()
        {
            _lnkNomination.Click();
            return NewPage<NominationHomePage>();
        }


        public SocialStreamHomePage NavigateToSocialStream()
        {
            _lnkSocialStream.Click();
            return NewPage<SocialStreamHomePage>();
        }

        public MyActivityHomePage NavigateToMyActivity()
        {
            _lnkMyActivities.Click();
            return NewPage<MyActivityHomePage>();
        }

        public ViewHierarchyHomePage NavigateToViewHierarchy()
        {
            _lnkViewHierarchy.Click();
            return NewPage<ViewHierarchyHomePage>();
        }

        public TrainingHomePage NavigateToTraining()
        {
            _lnkRecognitionTraining.Click();
            return NewPage<TrainingHomePage>();
        }

        public ReportBuilderHomePage NavigateToReportBuilder()
        {
            _lnkReportBuilder.Click();
            return NewPage<ReportBuilderHomePage>();
        }

        public ReportsPage NavigateToReportsSpan()
        {
            _lnkReportsMain.Click();
            return NewPage<ReportsPage>();
        }

        public ProxyHomePage NavigateToAdminHomePageLi()
        {
            _lnkAdminLi.Click();
            return NewPage<ProxyHomePage>();
        }

        public VisaCenterHomePage NavigateToVisaCenter()
        {
            Synchronization.WaitForElementToBePresent(_lnkVisaCenter);
            _lnkVisaCenter.Click();
            return NewPage<VisaCenterHomePage>();
        }

        public CheckOutPage NavigateToCart()
        {
            Synchronization.WaitForElementToBePresent(_lnkCart);
            _lnkCart.Click();
            return NewPage<CheckOutPage>();
        }

        public LoginPage ClickSignOut()
        {
            _lnkSignOut.Click();
            return NewPage<LoginPage>();
        }
    }
}
