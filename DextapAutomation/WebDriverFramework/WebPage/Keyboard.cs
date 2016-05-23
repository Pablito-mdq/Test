using OpenQA.Selenium;

namespace WebDriverFramework.PageObject
{

    public class Keyboard
    {
        
        private IKeyboard keyboard;

        public Keyboard(IKeyboard Keyboard)
        {
            this.keyboard = Keyboard;
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
}
