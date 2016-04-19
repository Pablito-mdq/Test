using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
