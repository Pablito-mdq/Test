using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using WebDriverFramework.PageObject.Internals;

namespace WebDriverFramework.PageObject
{
    public abstract partial class AbstractWebPage
    {
        protected void SetCookie(string name, string value, string domain, string path) {
            Cookie cookie = new Cookie(name, value, domain, path, DateTime.Now.AddDays(1));
            WebDriver.Manage().Cookies.AddCookie(cookie);
        }

        protected void SetCookie(Cookie cookie) {
            WebDriver.Manage().Cookies.AddCookie(cookie);
        }

        protected void DeleteAllCookies()
        {
            WebDriver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
