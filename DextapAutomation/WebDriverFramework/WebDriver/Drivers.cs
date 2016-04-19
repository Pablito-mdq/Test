using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverFramework.Drivers
{
    internal class MyNavigation : INavigation
    {
        private RemoteWebDriver WebDriver;
        private WebDriverWait wait;

        public MyNavigation(RemoteWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            /**
             * Configure to wait for up to 20 secs, pooling every 1 sec
             */
            this.wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromSeconds(1);
        }
        public void Back()
        {
            WebDriver.Navigate().Back();
        }

        public void Forward()
        {
            WebDriver.Navigate().Forward();
        }

        public void GoToUrl(Uri url)
        {
            WebDriver.Navigate().GoToUrl(url.AbsoluteUri);
        }

        public void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        public bool IsAndroid()
        {
            return WebDriver.Capabilities.BrowserName.ToLower().Contains("android");
        }
        public bool IsIOS()
        {
            return WebDriver.Capabilities.BrowserName.ToLower().Contains("ios");
        }

        public void GoToUrl(string url)
        {
            if (IsAndroid())
            {
                WebDriver.SwitchTo().Window("NATIVE");
                IWebElement urlBar = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//UrlInputView[@id='url']")));
                urlBar.Clear();
                urlBar.SendKeys(url + "\n");
                WebDriver.SwitchTo().Window("WEBVIEW");
            }
            else
            {
                WebDriver.Navigate().GoToUrl(url);
            }
        }
    }

    internal class SwipeableWebDriver : RemoteWebDriver, IHasTouchScreen
    {
        private RemoteTouchScreen touch;
        public new INavigation Navigate;

        public SwipeableWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities) : base(remoteAddress, desiredCapabilities)
        {
            touch = new RemoteTouchScreen(this);
            Navigate = new MyNavigation(this);
        }

        public ITouchScreen TouchScreen
        {
            get { return touch; }
        }
    }
}