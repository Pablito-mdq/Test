using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu.GoToMall
{
    public class CompanyGifCart : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'footlocker.png')]")]
        private IWebElement _imgFootLocker;

        [FindsBy(How = How.XPath, Using = "//a[@href='/mall/checkout']")]
        private IWebElement _btnCheckOut;

        public CompanyGifCart(IWebDriver driver) : base(driver){}

        public bool IsFootLockerAdded()
        {
            return _imgFootLocker.Displayed;
        }

        public CheckOutPage ClickCheckOut()
        {
            _btnCheckOut.Click();
            return NewPage<CheckOutPage>();
        }
    }

}
