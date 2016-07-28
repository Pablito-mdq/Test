﻿using System.Linq;
using System.Threading;
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

        [FindsBy(How = How.XPath, Using = "//h3[contains(@class,'mall-welcome-message')]")]
        private IWebElement _lblWelcomeMsg;

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
            Thread.Sleep(5000);
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
        public string GetWelcomeMsg()
        {
            return _lblWelcomeMsg.Text;
        }

        public string GetImgFirstCreditCard()
        {
            return Synchronization.WaitForElementToBePresent(By.XPath("//img[contains(@src,'http://qaassets.workstride.net/resources/images/vendors/vendorimages_workstridediscoverprepaidcard.png')]")).GetAttribute("src");
        }

        public string GetImgSecondCreditCard()
        {
            IWebElement a = Synchronization.WaitForElementToBePresent(By.Id("316")).FindElement(By.XPath("//img[contains(@src,'workstridemilestoneprepaidcard.png')]"));
            return a.GetAttribute("src");
        }
    }
}
