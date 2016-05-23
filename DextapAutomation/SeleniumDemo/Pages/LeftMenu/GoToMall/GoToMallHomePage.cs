using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu.GoToMall
{
    public class GoToMallHomePage : WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "user-lookup")]
        private IWebElement _txtUserName;

        [FindsBy(How = How.Id, Using = "lookupMerchant")]
        private IWebElement _txtCompanyName;

        public GoToMallHomePage(IWebDriver driver) : base(driver) { }

        public string GetFilterChkTypeByPrice(int pos)
        {
            IWebElement[] items = FindElements(By.XPath("//span[contains(@class,'mallSelections price')]")).ToArray();
            return items[pos].Text;
        }

        public string GetFilterTitleText(int pos)
        {
            IWebElement[] subtitle = FindElements(By.XPath("//div[contains(@class,'collapseBtn content quickLinksBtn leftMenuLink')]")).ToArray();
            return subtitle[pos].Text;
        }

        public string GetFilterChkTypeByPurchase(int pos)
        {
            IWebElement[] items = FindElements(By.XPath("//span[contains(@class,'mallSelections type')]")).ToArray();
            return items[pos].Text;
        }

        public string GetFilterChkTypeByCategory(int pos)
        {
            IWebElement[] items = FindElements(By.XPath("//span[contains(@class,'mallSelections')]")).ToArray();
            return items[pos].Text;
        }

        public GoToMallHomePage SearchCompany(object name)
        {
            _txtCompanyName.SendKeys(name + Keys.Enter);
            return NewPage<GoToMallHomePage>();
        }

        public CompanyGiftCard SelectCompany()
        {
           FindElement(By.ClassName("vendorImage")).Click();
            return NewPage<CompanyGiftCard>();
        }

        
    }
}
