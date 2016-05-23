using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.Textron
{
    internal class RecognitionSteps : WorkStridePage
    {
        [FindsBy(How = How.Id, Using = "user_name")] private IWebElement _txtUsername;

        [FindsBy(How = How.XPath, Using = "password")] private IWebElement _txtPassword;

        [FindsBy(How = How.XPath, Using = "submit_button")] private IWebElement _btnLogon;

        public RecognitionSteps(IWebDriver driver) : base(driver)
        {
        }
    }

}
