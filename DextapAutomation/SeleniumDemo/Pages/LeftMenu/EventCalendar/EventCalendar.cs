using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Pages.NominationPage;

namespace SeleniumDemo.Pages.LeftMenu.EventCalendar
{
    public class EventCalendar: WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Recent')]")]
        private IWebElement _btnRecent;

        public EventCalendar(IWebDriver driver) : base(driver) { }


        public EventCalendar ClickRecent()
        {
            _btnRecent.Click();
            Synchronization.WaitForElementNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            return NewPage<EventCalendar>();
        }

        public string GetNameList(int pos)
        {
            IWebElement[] list = Synchronization.WaitForElementsToBePresent(By.ClassName("b1o3")).ToArray();
            return list[pos].Text;
        }

        public Step2 clickSendRecognition()
        {
            Synchronization.WaitForElementsToBePresent(By.XPath("//a[contains(@class,'sendECard')]")).FirstOrDefault().Click();
            return NewPage<Step2>();
        }

        public Step2  clickSendAniversaryCard()
        {
            Synchronization.WaitForElementsToBePresent(By.XPath("//a[contains(.,' Send Anniversary Card ')]")).FirstOrDefault().Click();
            return NewPage<Step2>();
        }
    }
}
