using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Tests.Sprint
{
    public class BulkAward : WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "selectedFile")] private IWebElement _btnUploadFile;

        public BulkAward(IWebDriver driver) : base(driver)
        {
        }

        public BulkAward UploadFile()
        {
            _btnUploadFile.Click();
            return NewPage<BulkAward>();
        }

        public BulkAward WaitForFileToUpload()
        {
            Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[@aria-valuetext='100%']"));
            return NewPage<BulkAward>();
        }

        public bool WasFileSuccessfullyUpload()
        {
            return Synchronization.WaitForElementToBePresent(
                By.XPath("//i[contains(@class,'success icon ion-checkmark-circled')]")).Displayed;
        }
    }
}
