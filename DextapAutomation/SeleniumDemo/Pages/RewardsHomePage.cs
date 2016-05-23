using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Tests
{
    public class RewardsHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//legend[., contains('Download an MDD')]")]
        private IWebElement LblPageTitle;

        [FindsBy(How = How.Id, Using = "Mdd")]
        private IWebElement TxtMddName;

        [FindsBy(How = How.Id, Using = "ServerType")]
        private IWebElement CboServerTypes;

        [FindsBy(How = How.Id, Using = "DBServer")]
        private IWebElement CboDBServer;

        [FindsBy(How = How.Id, Using = "save")]
        private IWebElement BtnDownloadMdd;

        public RewardsHomePage(IWebDriver driver) : base(driver) { }

        public bool IsPresent()
        {
            return !(LblPageTitle == null);
        }

        public bool MddNameTextField()
        {
            return(TxtMddName.Enabled & TxtMddName.Displayed);
        }

        public bool ServerTypesDisplayed()
        {
            return (CboServerTypes.Displayed);
        }

        public bool DatabaseServers()
        {
            return (CboServerTypes.Displayed);
        }

        public RewardsHomePage SelectServerType(string serverType)
        {
            new SelectElement(CboServerTypes).SelectByText(serverType);
            return this;
        }

        public string GetServerTypeSelected()
        {
            return new SelectElement(CboServerTypes).SelectedOption.Text;
        }

        public RewardsHomePage SelectDatabaseServers(string database)
        {
            new SelectElement(CboDBServer).SelectByText(database);
            return this;
        }

        public RewardsHomePage EnterMddName(string mddName)
        {
            TxtMddName.SendKeys(mddName);
            return this;
        }

        public RewardsHomePage ClickDownload()
        {
            BtnDownloadMdd.Click();
            return this;
        }

        public RewardsHomePage Wait()
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(.,'Featured Brands')]"));
            return NewPage<RewardsHomePage>();
        }
    }
}
