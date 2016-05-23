
using System;
using System.Drawing.Imaging;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace WebDriverFramework.WebDriver
{
    class DriverListener
    {
        private static ILog LOG;
        private string lastElement;
        private IWebDriver wrappedDriver;

        public DriverListener(IWebDriver driver)
        {
            LOG = LogManager.GetLogger(driver.GetType());
            this.wrappedDriver = driver;
        }

        public IWebDriver getListeningDriver()
        {
            EventFiringWebDriver efDriver = new EventFiringWebDriver(wrappedDriver);
            efDriver.ExceptionThrown += TakeScreenshotOnException;
            efDriver.ElementClicked += LogElementClicked;
            efDriver.ElementClicking += LogElementClicking;
            efDriver.FindingElement += LogFindingElement;
            efDriver.FindElementCompleted += LogElementFound;
            efDriver.Navigating += LogNavigating;
            efDriver.Navigated += LogNavigated;
            return efDriver;
        }

        private void LogNavigated(object sender, WebDriverNavigationEventArgs e)
        {
            LOG.Info("Done navigation to URL " + e.Url);
        }

        private void LogNavigating(object sender, WebDriverNavigationEventArgs e)
        {
            LOG.Info("Navigating to URL " + e.Url);
        }

        private void LogElementFound(object sender, FindElementEventArgs e)
        {
            LOG.Info("Element found using " + e.FindMethod);
        }

        private void LogFindingElement(object sender, FindElementEventArgs e)
        {
            LOG.Info("Attempting to find element " + e.FindMethod);
        }

        private void LogElementClicking(object sender, WebElementEventArgs e)
        {
            lastElement = e.Element.Text;
            LOG.Info("About to click element '" + lastElement + "'");
        }

        private void LogElementClicked(object sender, WebElementEventArgs e)
        {
            LOG.Info("Clicked element '" + lastElement + "'");
        }

        private void TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        {
            LOG.Error("Exception occurred! Taking screenshot.", e.ThrownException);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            try
            {
                ((EventFiringWebDriver)sender).GetScreenshot().SaveAsFile("Exception-" + timestamp + ".png", ImageFormat.Png);
            }
            catch (Exception ex)
            {
                LOG.Error("Could not capture screenshot!", ex);
            }
        }
    }
}
