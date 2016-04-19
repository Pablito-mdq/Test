using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using Protractor;
using System;
using System.Collections.Generic;
using System.Reflection;
using WebDriverFramework.Drivers;
using WebDriverFramework.Interfaces;
using WebDriverFramework.WebDriver;

namespace WebDriverFramework.Factories
{
    internal class DriverFactory
    {
        public IWebDriver getDriverFor(BrowserType browser)
        {
            /**
             * Create browser specific factory
             */
            IDriverFactory factory;
            switch (browser)
            {
                case BrowserType.Firefox:
                    factory = new FirefoxFactory();
                    break;
                case BrowserType.Chrome:
                    factory = new ChromeFactory();
                    break;
                case BrowserType.IE:
                    factory = new IEFactory();
                    break;
                case BrowserType.Android:
                    factory = new AndroidFactory();
                    break;
                case BrowserType.IOS:
                    factory = new IOSFactory();
                    break;
                case BrowserType.PhantomJS:
                    factory = new PhantomFactory();
                    break;
                case BrowserType.Remote:
                    factory = new RemoteDriverFactory();
                    break;
                default:
                    throw new InvalidOperationException("Browser not supported!");
            }

            ICapabilities capabilities = Config.getDriverCapabilities(browser);
            IWebDriver driver = factory.createDriver(capabilities);

            // Set a default implicit timeout
            driver.Manage().Timeouts().ImplicitlyWait(Config.getDriverImplicitWaitTime());
            driver.Manage().Timeouts().SetPageLoadTimeout(Config.getDriverPageLoadTimeout());

            return new DriverListener(driver).getListeningDriver();
        }

        public IWebDriver getDriverWithAngularSupportFor(BrowserType browser)
        {
            /**
             * Wrap driver with AngularJS support
             */
            return new NgWebDriver(getDriverFor(browser));

        }


    }

    class FirefoxFactory : IDriverFactory
    {
        public IWebDriver createDriver()
        {
            return createDriver(DesiredCapabilities.Firefox());
        }

        public IWebDriver createDriver(ICapabilities capabilities)
        {
            IWebDriver driver = (IWebDriver)new FirefoxDriver(capabilities);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }

    class ChromeFactory : IDriverFactory
    {
        public IWebDriver createDriver()
        {
            return createDriver(DesiredCapabilities.Chrome());
        }

        public IWebDriver createDriver(ICapabilities capabilities)
        {
            /**
             * Transform capabilities to Dictionary<string,object> and place it
             * reflectively as member of ChromeOptions.
             * 
             * Sucks, but everything here is immutable, non enumerable, etc
             */
            DesiredCapabilities dc = (DesiredCapabilities)capabilities;
            FieldInfo[] fields = dc.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, object> values = (Dictionary<string, object>)fields[0].GetValue(dc);

            ChromeOptions options = Config.getChromeDriverArguments();
            fields = options.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                if (field.Name.Equals("additionalCapabilities"))
                {
                    field.SetValue(options, values);
                    break;
                }
            }

            IWebDriver driver = (IWebDriver)new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory + @"\libs", options);
            driver.Manage().Window.Maximize();
            return driver;
        }

    }

    class IEFactory : IDriverFactory
    {
        public IWebDriver createDriver()
        {
            return createDriver(DesiredCapabilities.InternetExplorer());
        }

        public IWebDriver createDriver(ICapabilities capabilities)
        {
            IWebDriver driver = (IWebDriver)new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory + @"\libs");
            driver.Manage().Window.Maximize();
            return driver;
        }
    }

    class AndroidFactory : IDriverFactory
    {
        public IWebDriver createDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            return createDriver(capabilities);
        }

        public IWebDriver createDriver(ICapabilities capabilities)
        {
            return (IWebDriver)new SwipeableWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
        }
    }

    class IOSFactory : IDriverFactory
    {
        public IWebDriver createDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            return createDriver(capabilities);
        }

        public IWebDriver createDriver(ICapabilities capabilities)
        {
            IWebDriver driver = (IWebDriver)new SwipeableWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            /**
             * Usually Mobile Safari has just one window. By switching to it, Appium
             * is put under web view mode, instead of UIAElements mode. To exit web
             * view context and go back to native portion of the app, call:
             * "mobile: leaveWebView" with execute_script() in RemoteWebDriver
             */
            System.Collections.ObjectModel.ReadOnlyCollection<string> windows = driver.WindowHandles;
            foreach (string window in windows)
            {
                driver.SwitchTo().Window(window);
            }

            return driver;
        }
    }

    class RemoteDriverFactory : IDriverFactory
    {
        public IWebDriver createDriver()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            return createDriver(capabilities);
        }

        public IWebDriver createDriver(ICapabilities capabilities)
        {
            return new SwipeableWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
        }
    }

    class PhantomFactory : IDriverFactory
    {
        public IWebDriver createDriver()
        {
            return createDriver(DesiredCapabilities.PhantomJS());
        }

        public IWebDriver createDriver(ICapabilities capabilities)
        {
            /**
             * Transform capabilities to Dictionary<string,object> and place it
             * reflectively as member of ChromeOptions.
             * 
             * Sucks, but everything here is immutable, non enumerable, etc
             */
            DesiredCapabilities dc = (DesiredCapabilities)capabilities;
            FieldInfo[] fields = dc.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, object> values = (Dictionary<string, object>)fields[0].GetValue(dc);

            PhantomJSOptions options = new PhantomJSOptions();
            foreach (KeyValuePair<string, object> capability in values)
            {
                options.AddAdditionalCapability(capability.Key.ToString(), (capability.Value == null ? "" : capability.Value.ToString()));
            }

            string executable = AppDomain.CurrentDomain.BaseDirectory + @"\libs";
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService(executable);
            IWebDriver driver = (IWebDriver)new PhantomJSDriver(service, options);
            return driver;
        }
    }
}
