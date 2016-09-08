using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu.GoToMall
{
    public class CompanyGifCart : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'footlocker.png')]")]
        private IWebElement _imgFootLocker;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/mall/checkout')]")]
        private IWebElement _btnCheckOut;

        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'http://qaassets.workstride.net/resources/images/button_minus.png')]")]
        private IWebElement _btnMinus;

        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'http://qaassets.workstride.net/resources/images/button_plus.png')]")]
        private IWebElement _btnPlus;

        public CompanyGifCart(IWebDriver driver) : base(driver){}

        public bool IsFootLockerAdded()
        {
            try
            {
                return _imgFootLocker.Displayed;
            }
            catch (Exception)
            {
                return FindElement(By.XPath("//img[contains(@src,'footlocker.png')]")) != null;
            }
            
        }

        public CheckOutPage ClickCheckOut()
        {
            _btnCheckOut.Click();
            return NewPage<CheckOutPage>();
        }

        public CompanyGifCart ClickMinusQuant()
        {
            _btnMinus.Click();
            return NewPage<CompanyGifCart>();
        }

        public bool IsGrouponAdded()
        {
            try
            {
                return Synchronization.WaitForElementToBePresent(By.XPath("//img[contains(@src,'groupon.png')]")).Displayed;
            }
            catch (Exception)
            {
                return FindElement(By.XPath("//img[contains(@src,'groupon.png')]")) != null;
            }
        }

        public int GetTotal()
        {
            return Int32.Parse(Synchronization.WaitForElementToBePresent(By.XPath("//span[@id='cartRewardsTotal']")).Text.Substring(1,3));
        }

        public int GetQuantity()
        {
            var a = (Synchronization.WaitForElementToBePresent(By.XPath("//input[contains(@class,'mallOverlayInput quantityInput')]")).GetAttribute("value"));
            return Int32.Parse(a);
        }

        public int GetAmount()
        {
            return Int32.Parse((Synchronization.WaitForElementToBePresent(By.XPath("//h4[contains(.,'$10.00')]")).Text.Substring(1, 2)));
        }

        public int GetBalance()
        {
            return Int32.Parse(Synchronization.WaitForElementToBePresent(By.XPath("//h4[contains(@class,'alignCenter')]")).Text.Substring(1, 3));
        }

        public CompanyGifCart ClickPlusQuant()
        {
           _btnPlus.Click();
            return NewPage<CompanyGifCart>();
        }
    }

}
