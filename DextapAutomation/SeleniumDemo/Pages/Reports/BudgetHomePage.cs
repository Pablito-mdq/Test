using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.Pages.Reports
{
    public class BudgetHomePage : WorkStridePage
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(@data-operator,'Add')]")]
        private IWebElement _btnAdd;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-operator,'Subtract')]")]
        private IWebElement _btnSubtract;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-operator,'Deactivate')]")]
        private IWebElement _btnDeact;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'close')]")]
        private IWebElement _btnClose;

        [FindsBy(How = How.Id, Using = "amount")]
        private IWebElement _txtAmount;

        [FindsBy(How = How.XPath, Using = "//button[@class='budget_Activate']")]
        private IWebElement _btnActivate;

        public BudgetHomePage(IWebDriver driver) : base(driver) { }

        public float GetAwardTable(int row, int col)
        {
            Synchronization.WaitForElementNotToBePresent(By.XPath("//div[contains(@class,'loader')]"));
            var quant = Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[{1}]",row,col))).Text;
            return float.Parse(quant.Substring(1, 7));
        }

        public BudgetHomePage ClickEdit(int p)
        {
            Synchronization.WaitForElementToBePresent(By.XPath(string.Format("//*[@id='report-table-container']/table/tbody[3]/tr[{0}]/td[7]/input",p))).Click();
            return NewPage<BudgetHomePage>();
        }

        public string GetAddBtnTxt()
        {
            return _btnAdd.Text;
        }

        public string GetSubstratBtnTxt()
        {
            return _btnSubtract.Text;
        }

        public string GetDeactBtnTxt()
        {
            return _btnDeact.Text;
        }

        public string GetBtnCloseTxt()
        {
            return _btnClose.Text;
        }

        public BudgetHomePage EnterAmount(string p)
        {
            _txtAmount.SendKeys(p);
            return this;
        }


        public BudgetHomePage ClickAdd()
        {
            _btnAdd.Click();
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            return NewPage<BudgetHomePage>();
        }

        public BudgetHomePage ClickDeactivate()
        {
            Synchronization.WaitForElementToBePresent(_btnDeact);
            _btnDeact.Click();
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            return NewPage<BudgetHomePage>();
        }

        public string GetDeactMsg()
        {
            var a = Synchronization.WaitForElementToBePresent(By.XPath("//strong[contains(.,'Budget Active Status: ')]")).Text;
            var b = Synchronization.WaitForElementToBePresent(By.XPath("//*[@id='modal']/div/div[1]/div[2]/text()")).Text;
            return a + " " + b;

        }

        public BudgetHomePage ClickActivate()
        {
            _btnActivate.Click();
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            return NewPage<BudgetHomePage>();
        }

        public BudgetHomePage ClickClose()
        {
            _btnClose.Click();
            return NewPage<BudgetHomePage>();
        }
    }
}
