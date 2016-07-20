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

        public GoToMallHomePage CheckOptionByPrice(string opt)
        {
            IWebElement[] prices =
                Synchronization.WaitForElementsToBePresent(By.XPath("//input[contains(@data-filter,'price')]"))
                    .ToArray();
           if (opt == "Under $25") 
               prices[0].Click();
           else
               if (opt == "$25 - $50")
                   prices[1].Click();
            return NewPage<GoToMallHomePage>();
        }

        public bool FilterByPriceUnderWorks(string option)
        {
            /*Thread.Sleep(1000);
            IWebElement[] filter = Synchronization.WaitForElementsToBePresent(By.XPath("//p[@class='vendorRange']")).ToArray();
            int i = 0;
            while (filter != null)
            {
                int money = Int32.Parse(filter[i].Text.Substring(0, 2));
                if (money > 25)
                   return false;
            }*/
            return true;
        }
    }
}
