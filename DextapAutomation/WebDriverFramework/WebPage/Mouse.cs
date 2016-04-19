using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverFramework.PageObject.Internals;

namespace WebDriverFramework.PageObject
{

    public class Mouse
    {
        private IMouse mouse;
        private SynchronizationOperations Sync;

        public Mouse(IMouse Mouse, SynchronizationOperations Sync)
        {
            this.mouse = Mouse;
            this.Sync = Sync;
        }

        /// <summary>
        /// Performs a MouseUp event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseUp(IWebElement element)
        {
            ILocatable locatable = (ILocatable)element;
            mouse.MouseUp(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a MouseMove event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseMove(IWebElement element)
        {
            ILocatable locatable = (ILocatable)element;
            mouse.MouseMove(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a Mouse Click event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseClick(IWebElement element)
        {
            ILocatable locatable = (ILocatable)element;
            mouse.Click(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a DoubleClick event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseDoubleClick(IWebElement element)
        {
            ILocatable locatable = (ILocatable)element;
            mouse.DoubleClick(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a ContextClick event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseContextClick(IWebElement element)
        {
            ILocatable locatable = (ILocatable)element;
            mouse.ContextClick(locatable.Coordinates);
        }

        /// <summary>
        /// Performs a MouseDown event on the specified element via ILocatable interface.
        /// </summary>
        /// <param name="elementName">Element to operate on.</param>
        public void MouseDown(IWebElement element)
        {
            ILocatable locatable = (ILocatable)element;
            mouse.MouseDown(locatable.Coordinates);
        }
    }
}
