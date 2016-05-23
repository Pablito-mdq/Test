using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.Reports
{
    public class AllAwards : WorkStridePage
    {
       [FindsBy(How = How.Id, Using = "//a[contains(.,'All Awards')]")]
       private IWebElement _lnkAllAwardsLkn;

       public AllAwards(IWebDriver driver) : base(driver) { }

       public string GetAwardName(int row, int col)
       {
           return Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}]", row, col))).Text;
       }

       public string GetStatus(int row, int col)
       {
           return Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}]", row, col))).Text;
       }
    }
}
