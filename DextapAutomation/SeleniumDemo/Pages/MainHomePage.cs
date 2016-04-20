using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.NominationPage;

namespace SeleniumDemo.Pages
{
    public class MainHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdmin;

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'RECOGNIZE')]")]
        private IWebElement _lnkNomination;

        [FindsBy(How = How.Id, Using = "jobs_length")]
        private IWebElement LblEntries;

        public MainHomePage(IWebDriver driver) : base(driver) { }

        public string GetJobName()
        {
            return (FindElement(By.XPath("//jobs[@href='/Edit/6315'")).Text);
        }

        public bool ShowsEntriesDisplayed()
        {
            return LblEntries.Displayed;
        }

        public MainHomePage SelectShowEntries(string entries)
        {
            new SelectElement(_lnkNomination).SelectByText(entries);
            return this;
        }

        public string GetShowEntries()
        {
            return new SelectElement(_lnkNomination).SelectedOption.Text;
        }

        public AdminHomePage NavigateToAdminHomePage()
        {
            Synchronization.WaitForElementsNotToBePresent(By.Id("modal"));
            _lnkAdmin.Click();
            return NewPage<AdminHomePage>();
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
    }
}
