using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WebDriverFramework.WebDriver;

namespace WebDriverFramework
{
    public class Config
    {
        private static XmlDocument xmlDoc = new XmlDocument();
        private static FrameworkConfig config = new FrameworkConfig();
        private static Config instance = new Config();

        private Config()
        {
            // This has nothing to do with the Config class, it is just initializing the Log4net...shouldn't be here
            XmlConfigurator.Configure(new FileInfo("log4net.xml"));

            XmlSerializer marshaller = new XmlSerializer(typeof(FrameworkConfig));
            Stream reader = null;
            try
            {
                reader = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\FrameworkConfig.xml", FileMode.Open);
                config = (FrameworkConfig)marshaller.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public static ICapabilities getDriverCapabilities(BrowserType browser)
        {
            foreach (Driver driver in config.drivers)
            {
                if (driver.name.ToUpper().Equals(browser.ToString().ToUpper()))
                {
                    return CreateCapabilities(driver);
                }
            }
            return new DesiredCapabilities();
        }

        private static DesiredCapabilities CreateCapabilities(Driver driver)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            foreach (Capability capability in driver.capabilities)
            {
                if (capability.value != null && capability.value.Length > 0)
                {
                    capabilities.SetCapability(capability.name, capability.value);
                }
            }
            return capabilities;
        }

        public static ChromeOptions getChromeDriverArguments()
        {
            ChromeOptions options = new ChromeOptions();
            Driver chromeConfig = config.drivers.Find(x => x.name.ToUpper().Equals("CHROME"));

            if (chromeConfig == null)
            {
                return options;
            }

            foreach (Argument argument in chromeConfig.arguments)
            {
                if (argument.value != null && argument.value.Length > 0)
                {
                    options.AddArgument(argument.value);
                }
            }

            return options;
        }

        internal static TimeSpan getDriverImplicitWaitTime()
        {
            return TimeSpan.FromSeconds(config.waiting.implicitly);
        }

        internal static TimeSpan getDriverPageLoadTimeout()
        {
            return TimeSpan.FromSeconds(config.waiting.pageload);
        }
    }
}
