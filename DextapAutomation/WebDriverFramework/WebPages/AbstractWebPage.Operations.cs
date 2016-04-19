using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverFramework.PageObject
{
    public class SynchronizableOperations
    {

        /// <summary>
        /// Causes to actively wait for X amount of time (in seconds) for object of type T to meet user specified function.
        /// "Event" implies that the return value is not known, and therefore, defined by K type.
        /// Re-check interval is set to 500 ms.
        /// 
        /// Example of a condition can be:
        ///     WaitForEvent<IWebDriver, IWebElement>(10, WebDriver, ExpectedConditions.ElementIsVisible(locator));
        ///     Above example would also return the IWebElement instance, if ElementIsVisible. TimeoutException otherwise.
        /// </summary>
        protected K WaitForEvent<T, K>(double timeInSeconds, T operatesOn, Func<T, K> function)
        {
            DefaultWait<T> wait = new DefaultWait<T>(operatesOn);
            wait.Timeout = TimeSpan.FromSeconds(timeInSeconds);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            return wait.Until<K>(function);
        }

        /// <summary>
        /// Causes to actively wait for X amount of time (in seconds) for object of type T to meet user specified function.
        /// As "condition" implies, the default returning value must be a Boolean.
        /// Re-check interval is set to 500 ms.
        /// 
        /// Example of a condition can be:
        ///     Func<IWebDriver, Boolean> TitleIsHola = delegate(IWebDriver o) { return o.Title.Equals("HOLA"); };
        ///     WaitForCondition<IWebDriver>(10, WebDriver, TitleIsHola);
        ///     
        ///     Above example would also return true/false, if TitleIsHola, TimeoutException otherwise.
        /// </summary>
        protected Boolean WaitForCondition<T>(double timeInSeconds, T operatesOn, Func<T, Boolean> function)
        {
            return WaitForEvent<T, Boolean>(timeInSeconds, operatesOn, function);
        }

        /// <summary>
        /// Causes to actively wait up to 30 seconds for the specified WebElement to be present.
        /// "Presence" means Existance AND Visibility.
        /// Re-check interval is set to 500 ms.
        /// </summary>
        protected void WaitForElementToBePresent(IWebElement element)
        {
            Func<IWebElement, Boolean> isPresent = delegate(IWebElement e) { return e.Enabled && e.Displayed; };
            WaitForEvent<IWebElement, Boolean>(30, element, isPresent);
        }
    }

    public class ActionOperations : SynchronizableOperations
    {
        private IWebDriver WebDriver;

        public ActionOperations(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
        }

        /// <summary>
        /// Move mouse to specified element.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MoveToElement(IWebElement element)
        {
            WaitForElementToBePresent(element);
            Actions action = new Actions(WebDriver);
            action.MoveToElement(element).Build().Perform();
        }

        /// <summary>
        /// Clicks the specified element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void ClickAction(IWebElement element)
        {
            WaitForElementToBePresent(element);
            Actions action = new Actions(WebDriver);
            action.Click(element).Build().Perform();
        }

        /// <summary>
        /// Clicks and hold the specified element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="element">Element to operate on.</param>
        public void ClickAndHoldAction(IWebElement element)
        {
            WaitForElementToBePresent(element);
            Actions action = new Actions(WebDriver);
            action.ClickAndHold(element).Build().Perform();
        }

        /// <summary>
        /// Drags and drop one element onto another one using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="fromElement">Element to drag around.</param>
        /// <param name="toElement">Element to drop on.</param>
        public void DragAndDropAction(IWebElement fromElement, IWebElement toElement)
        {
            WaitForElementToBePresent(fromElement);
            WaitForElementToBePresent(toElement);
            Actions action = new Actions(WebDriver);
            action.DragAndDrop(fromElement, toElement).Build().Perform();
        }

        /// <summary>
        /// ContextClick an element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void ContextClickAction(IWebElement element)
        {
            WaitForElementToBePresent(element);
            Actions action = new Actions(WebDriver);
            action.ContextClick(element).Build().Perform();
        }

        /// <summary>
        /// KeyUp an element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        /// <param name="theKey">The key to release.</param>
        public void KeyUp(IWebElement element, string theKey)
        {
            WaitForElementToBePresent(element);
            Actions action = new Actions(WebDriver);
            action.KeyUp(element, theKey).Build().Perform();
        }

        /// <summary>
        /// KeyDown an element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        /// <param name="theKey">The key to release.</param>
        public void KeyDown(IWebElement element, string theKey)
        {
            WaitForElementToBePresent(element);
            Actions action = new Actions(WebDriver);
            action.KeyDown(element, theKey).Build().Perform();
        }

        /// <summary>
        /// Drags and drop one element onto designated X,Y coordinates from element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="fromElement">Element to drag around.</param>
        /// <param name="offsetX">X coordinate delta for element to be dragged to.</param>
        /// <param name="offsetY">Y coordinate delta for element to be dragged to.</param>
        public void DragAndDropToOffset(IWebElement fromElement, int offsetX, int offsetY)
        {
            WaitForElementToBePresent(fromElement);
            Actions action = new Actions(WebDriver);
            action.DragAndDropToOffset(fromElement, offsetX, offsetY).Build().Perform();
        }

    }

    public class LocatableOperations : SynchronizableOperations
    {
        private IMouse mouse;
        private IKeyboard keyboard;

        public LocatableOperations(IWebDriver WebDriver)
        {
            this.mouse = ((IHasInputDevices)WebDriver).Mouse;
            this.keyboard = ((IHasInputDevices)WebDriver).Keyboard;
        }

        /// <summary>
        /// Performs a MouseUp event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseUp(IWebElement element)
        {
            WaitForElementToBePresent(element);
            ILocatable locatable = (ILocatable)element;
            mouse.MouseUp(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a MouseMove event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseMove(IWebElement element)
        {
            WaitForElementToBePresent(element);
            ILocatable locatable = (ILocatable)element;
            mouse.MouseMove(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a Mouse Click event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseClick(IWebElement element)
        {
            WaitForElementToBePresent(element);
            ILocatable locatable = (ILocatable)element;
            mouse.Click(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a DoubleClick event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseDoubleClick(IWebElement element)
        {
            WaitForElementToBePresent(element);
            ILocatable locatable = (ILocatable)element;
            mouse.DoubleClick(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a ContextClick event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseContextClick(IWebElement element)
        {
            WaitForElementToBePresent(element);
            ILocatable locatable = (ILocatable)element;
            mouse.ContextClick(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a MouseDown event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseDown(IWebElement element)
        {
            WaitForElementToBePresent(element);
            ILocatable locatable = (ILocatable)element;
            mouse.MouseDown(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a PressKey event.
        /// </summary>
        /// <param name="keyToPress">The key to press (as string).</param>
        public void PressKey(string keyToPress)
        {
            keyboard.PressKey(keyToPress);
        }

        /// <summary>
        /// Performs a ReleaseKey event.
        /// </summary>
        /// <param name="keyToPress">The key to release (as string).</param>
        public void ReleaseKey(string keyToRelease)
        {
            keyboard.ReleaseKey(keyToRelease);
        }

        /// <summary>
        /// Performs a SendKeys event.
        /// </summary>
        /// <param name="keyToPress">The key sequence to send (as string).</param>
        public void SendKeys(string keySequence)
        {
            keyboard.SendKeys(keySequence);
        }
    }

    public abstract partial class AbstractWebPage : SynchronizableOperations
    {

        protected ActionOperations Actions;
        protected LocatableOperations LocatableActions;

        /// <summary>
        /// Causes WebDriver to wait for X amount of time (in seconds) on a user specified locator.
        /// "Presence" means Existance AND Visibility (also means element's height & width > 0!)
        /// </summary>
        protected IWebElement WaitForElementPresenceBy(double timeInSeconds, By locator)
        {
            return WaitForEvent<IWebDriver, IWebElement>(10, WebDriver, ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Navigates browser to specified URL.
        /// </summary>
        /// <param name="url">URL to navigate to.</param>
        protected void Navigate(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Scrolls to WebElement.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        protected void ScrollTo(IWebElement element)
        {
            GetJavaScriptDriver().ExecuteScript(string.Format("window.scrollTo(0, {0});", element.Location.Y));
        }

        /// <summary>
        /// Selects all (Ctrl+a).
        /// </summary>
        protected void SelectAll()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Copies selected value (Ctrl+c)
        /// </summary>
        protected void Copy()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Pastes clipboard (Ctrl+v)
        /// </summary>
        protected void Paste()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Evals the script.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="script">The script to evaluate.</param>
        /// <returns>``0.</returns>
        protected T EvalScript<T>(string script)
        {
            object result = GetJavaScriptDriver().ExecuteScript(script);
            if (result == null)
            {
                return default(T);
            }
            return (T)result;
        }

        /// <summary>
        /// Evals the script.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="script">The script to evaluate.</param>
        /// <param name="args">Array of objects to pass to WebDriver's JS engine.</param>
        /// <returns>``0.</returns>
        protected T EvalScript<T>(string script, object[] args)
        {
            object result = GetJavaScriptDriver().ExecuteScript(script, args);
            if (result == null)
            {
                return default(T);
            }
            return (T)result;
        }

        /// <summary>
        /// Runs the script.
        /// </summary>
        /// <param name="script">The script to run.</param>
        protected void RunScript(string script)
        {
            GetJavaScriptDriver().ExecuteScript(script);
        }

        /// <summary>
        /// Runs the script, providing arguments.
        /// </summary>
        /// <param name="script">The script.</param>
        /// <param name="args">Array of objects to pass to WebDriver's JS engine.</param>
        protected void RunScript(string script, object[] args)
        {
            GetJavaScriptDriver().ExecuteScript(script, args);
        }

        protected void SwitchToFrame(IWebElement frameElement)
        {
            SwitchToFrame(frameElement.GetAttribute("name"));
        }

        protected void SwitchToFrame(string frameName)
        {
            WebDriver.SwitchTo().Frame(frameName);
        }

        protected void SwitchToWindow(string windowName)
        {
            WebDriver.SwitchTo().Window(windowName);
        }

    }
}
