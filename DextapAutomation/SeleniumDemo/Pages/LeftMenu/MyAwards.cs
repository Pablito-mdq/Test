using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using WebDriverFramework.WebPage;

namespace SeleniumDemo.Pages.LeftMenu
{
    public class MyAwards : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='report-table-container']")]
        private static IWebElement _tableAwards;



        public MyAwards(IWebDriver driver) : base(driver)
        {
            Synchronization.WaitForElementsNotToBePresent(By.XPath("//div[contains(@id,'ui-spinner-container')]"));
        }

        public string GetAwardName(int row,int col)
        {
            return Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}]", row, col))).Text;
        }

        public DetailsAward OpenDetailsAward(int row,int col)
        {
            IWebElement details =
                Synchronization.WaitForElementToBePresent(
                    By.XPath(string.Format(
                        "//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}]/a[1]/img",row,col)));               
            details.Click();
            return NewPage<DetailsAward>();
            }
    }
}
