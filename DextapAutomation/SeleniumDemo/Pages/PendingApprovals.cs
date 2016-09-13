using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages.AdminPage;

namespace SeleniumDemo.Pages
{
    public class PendingApprovals: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Approve')]")]
        private IWebElement _btnApprove;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Decline')]")]
        private IWebElement _btnDecline;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Exit Proxy')]")]
        private IWebElement _lnkExitProxy;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Change')]")]
        private IWebElement _btnChange;

        public PendingApprovals(IWebDriver driver) : base(driver) { }

        public string GetTitleMenu()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Pending Approvals')]")).Text;
        }

        public AwardDetailsPopUp ApproveAward()
        {
            _btnApprove.Click();
            return NewPage<AwardDetailsPopUp>();
        }

        public AdminHomePage ExitProxy()
        {
            Synchronization.WaitForElementToBePresent(_lnkExitProxy);
            ScrollTo(_lnkExitProxy);
            _lnkExitProxy.Click();
            return NewPage<AdminHomePage>();
        }

        public AwardDetailsPopUp DeclineAward()
        {
            _btnDecline.Click();
            return NewPage<AwardDetailsPopUp>();
        }

        public AwardDetailsPopUp ChangeAward()
        {
            _btnChange.Click();
            return NewPage<AwardDetailsPopUp>();
        }

        public string GetStatusMsg()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Pending Approvals')]"));
            return Synchronization.WaitForElementToBePresent(By.XPath("//td[contains(@class,'alignCenter approval-response-message')]")).Text;
        }

        public MainHomePage ExitProxyToMainPage()
        {
            Synchronization.WaitForElementToBePresent(_lnkExitProxy);
            ScrollTo(_lnkExitProxy);
            _lnkExitProxy.Click();
            return NewPage<MainHomePage>();
        }

        public string GetFirstUserApproval()
        {
            return
                Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='DataTables_Table_0']/tbody/tr[1]/td[2]"))
                    .Text;
        }

        public AwardDetailsPopUp ClickThumpsUp()
        {
            Synchronization.WaitForElementsToBePresent(By.XPath("//button[@uib-tooltip='Approve']")).FirstOrDefault().Click();
            return NewPage<AwardDetailsPopUp>();
        }

        public AwardDetailsPopUp ClickThumpsDown()
        {
            Synchronization.WaitForElementsToBePresent(By.XPath("//button[@uib-tooltip='Decline']")).FirstOrDefault().Click();
            return NewPage<AwardDetailsPopUp>();
        }

        public string GetPendingApprovalsUrl()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//a[contains(.,'Pending Approvals')]")).GetAttribute("href");
        }
    }
}