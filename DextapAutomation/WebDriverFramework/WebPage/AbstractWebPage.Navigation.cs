using OpenQA.Selenium;
using System;

namespace WebDriverFramework.PageObject
{
    public abstract partial class AbstractWebPage
    {

        /// <summary>
        /// Navigates browser to specified URL.
        /// </summary>
        /// <param name="url">URL to navigate to.</param>
        protected void Navigate(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Scrolls browser's window to WebElement.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        protected void ScrollTo(IWebElement element)
        {
            GetJavaScriptDriver().ExecuteScript(string.Format("window.scrollTo(0, {0});", element.Location.Y));
        }

        /// <summary>
        /// Switch WebDriver's focus to given frame.
        /// </summary>
        /// <param name="frameElement">The WebElement representing the frame to switch to.</param>
        protected void SwitchToFrame(IWebElement frameElement)
        {
            SwitchToFrame(frameElement.GetAttribute("name"));
        }

        /// <summary>
        /// Switch WebDriver's focus to given frame name.
        /// </summary>
        /// <param name="frameName">The name of the frame to switch to.</param>
        protected void SwitchToFrame(string frameName)
        {
            WebDriver.SwitchTo().Frame(frameName);
        }

        /// <summary>
        /// Switch WebDriver's focus to given window name.
        /// </summary>
        /// <param name="windowName">The name of the window to switch to.</param>
        protected void SwitchToWindow(string windowName)
        {
            WebDriver.SwitchTo().Window(windowName);
        }
    }
}
