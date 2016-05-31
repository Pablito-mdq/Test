using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu.GoToMall
{
    public class CompanyGiftCard : WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "email")] private IWebElement _rbtnEmail;

        [FindsBy(How = How.Id, Using = "plastic")] private IWebElement _rbtnPerson; 
                 
        [FindsBy(How = How.Id, Using = "lookupMerchant")] private IWebElement _txtCompanyName;

        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'plus.png')]")]
        private IWebElement _btnPlusReward;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'itemqty')]")]
        private IWebElement _txtQty;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'itemamount')]")] private IWebElement _txtAmount;

        public CompanyGiftCard(IWebDriver driver) : base(driver) { }

        public CompanyGiftCard SelectDeliverMethod(string method)
        {
            if (method == "email")
                _rbtnEmail.Click();
            else
            {
                _rbtnPerson.Click();
            }
            return NewPage<CompanyGiftCard>();
        }

        public string GetAmount()
        {
            Synchronization.WaitForElementToBePresent(_txtAmount);
           return _txtAmount.GetAttribute("placeholder");
        }

        public CompanyGiftCard ClickPlusAmount()
        {
            _btnPlusReward.Click();
            return NewPage<CompanyGiftCard>();
        }

        public string GetDeliverMethod(string method)
        {
            Synchronization.WaitForElementToBePresent(By.XPath("//h3[contains(@class,'vendorOverlayTitle')]"));
            return method == "person" ? FindElement(By.XPath("//*[@id='plastic']/span")).Text : FindElement(By.XPath("//*[@id='email']/span")).Text;
        }

        public bool IsQtyAvailable()
        {
            return _txtQty.Displayed && _txtQty.Enabled;
        }
    }
}
