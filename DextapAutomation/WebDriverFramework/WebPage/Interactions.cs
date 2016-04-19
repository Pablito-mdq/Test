using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverFramework.PageObject.Internals;

namespace WebDriverFramework.PageObject
{
    /// <summary>
    /// This class provides convenient methods for easily dealing with
    /// Keyboard and Mouse events, serving as a facade for WebDriver's low level API. 
    /// </summary>
    public class Interactions
    {
        private IWebDriver Driver;
       
        private SynchronizationOperations Sync;

        public Interactions(IWebDriver WebDriver)
        {
            this.Driver = WebDriver;
            this.Sync = new SynchronizationOperations(Driver);            
        }

        private Actions GetAction()
        {
            return new Actions(Driver);
        }

        /// <summary>
        /// Move mouse to specified element.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MoveToElement(IWebElement element)
        {
            GetAction().MoveToElement(element).Build().Perform();
        }

        /// <summary>
        /// Clicks the specified element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void ClickAction(IWebElement element)
        {
            GetAction().Click(element).Build().Perform();
        }

        /// <summary>
        /// Clicks and hold the specified element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="element">Element to operate on.</param>
        public void ClickAndHoldAction(IWebElement element)
        {
            GetAction().ClickAndHold(element).Build().Perform();
        }

        /// <summary>
        /// Drags and drop one element onto another one using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="fromElement">Element to drag around.</param>
        /// <param name="toElement">Element to drop on.</param>
        public void DragAndDropAction(IWebElement fromElement, IWebElement toElement)
        {
            GetAction().DragAndDrop(fromElement, toElement).Build().Perform();
        }

        /// <summary>
        /// ContextClick an element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void ContextClickAction(IWebElement element)
        {
            GetAction().ContextClick(element).Build().Perform();
        }

        /// <summary>
        /// KeyUp an element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        /// <param name="theKey">The key to release.</param>
        public void KeyUp(IWebElement element, string theKey)
        {
            GetAction().KeyUp(element, theKey).Build().Perform();
        }

        /// <summary>
        /// KeyDown an element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        /// <param name="theKey">The key to release.</param>
        public void KeyDown(IWebElement element, string theKey)
        {
            GetAction().KeyDown(element, theKey).Build().Perform();
        }

        /// <summary>
        /// Drags and drop one element onto designated X,Y coordinates from element using the Advanced Actions Interaction API.
        /// </summary>
        /// <param name="fromElement">Element to drag around.</param>
        /// <param name="offsetX">X coordinate delta for element to be dragged to.</param>
        /// <param name="offsetY">Y coordinate delta for element to be dragged to.</param>
        public void DragAndDropToOffset(IWebElement fromElement, int offsetX, int offsetY)
        {
            GetAction().DragAndDropToOffset(fromElement, offsetX, offsetY).Build().Perform();
        }

    }
}
