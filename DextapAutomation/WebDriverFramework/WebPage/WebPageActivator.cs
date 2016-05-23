using System;
using OpenQA.Selenium;
using WebDriverFramework.PageObject;

namespace WebDriverFramework.WebPage
{
    internal class WebPageActivator
    {

        internal static T Activate<T>(IWebDriver driver) where T : AbstractWebPage
        {
            T instance = (T)Activator.CreateInstance(typeof(T), driver);
            return instance;
        }
    }
}
