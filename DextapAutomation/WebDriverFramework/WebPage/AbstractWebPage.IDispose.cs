using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WebDriverFramework.PageObject
{
    public abstract partial class AbstractWebPage : IDisposable
    {
        private bool isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method. 
            // Therefore, you should call GC.SupressFinalize to 
            // take this object off the finalization queue 
            // and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    WebDriver.Quit();
                    WebDriver.Dispose();
                }

                isDisposed = true;
            }
        }

        // In C#, you don't explicitly override the Finalize() method. 
        // You write a method that looks like a C++ destructor, and the compiler 
        // takes that to be your implementation of the Finalize() method

        // This destructor will run only if the Dispose method 
        // does not get called. 
        // It gives your base class the opportunity to finalize. 
        // Do not provide destructors in types derived from this class.
        ~AbstractWebPage()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }

    }
}
