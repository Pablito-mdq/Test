using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;

namespace WebDriverFramework.PageObject
{
    public abstract partial class AbstractWebPage
    {
        private IJavaScriptExecutor GetJavaScriptDriver()
        {
            IJavaScriptExecutor jsDriver = null;
            if (WebDriver.GetType().Equals(typeof(NgWebDriver)))
            {
                jsDriver = ((NgWebDriver)WebDriver).WrappedDriver as IJavaScriptExecutor;
            }
            else
            {
                jsDriver = WebDriver as IJavaScriptExecutor;
            }

            return jsDriver;
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

    }
}
