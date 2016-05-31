using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.LeftMenu
{
    public class DetailsAward : MyAwards
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'ADMIN')]")]
        private IWebElement _lnkAdmin;

        public DetailsAward(IWebDriver driver) : base(driver) { }

        public string GetDetailsAward(string name)
        {
            return FindElement(By.XPath(string.Format("//p[contains(.,'{0}')]",name))).Text;
        }

        public string GetDetailsValue(string name)
        {
            return FindElement(By.XPath(string.Format("//p[contains(.,'{0}')]", name))).Text;
        }

        public string GetDetailsMsg()
        {
            return FindElement(By.XPath("//p[contains(@class,'reward-message')]")).Text;
        }

        public string GetDetailsReason(string name)
        {
            return FindElement(By.XPath(string.Format("//p[contains(.,'{0}')]",name))).Text;
        }
    }
}
