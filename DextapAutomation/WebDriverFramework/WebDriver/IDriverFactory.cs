using OpenQA.Selenium;

namespace WebDriverFramework.Interfaces
{
    internal interface IDriverFactory
    {
        IWebDriver createDriver();

        IWebDriver createDriver(ICapabilities capabilities);
    }
}
