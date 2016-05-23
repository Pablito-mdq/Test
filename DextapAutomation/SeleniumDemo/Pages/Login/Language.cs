using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Pages.Login
{
     public class Language : AbstractWebPage
    {
        [FindsBy(How = How.Id, Using = "forgotPasswordSubmit")]
        private IWebElement _btnContinue;

        public Language(IWebDriver driver) : base(driver) { }

       
    }
}
