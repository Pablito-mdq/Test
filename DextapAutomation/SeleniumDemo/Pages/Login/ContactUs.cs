using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WebDriverFramework.PageObject;

namespace SeleniumDemo.Pages.Login
{
    public class ContactUs : AbstractWebPage
    {
        [FindsBy(How = How.Id, Using = "forgotError")] private IWebElement _lblChangepwd;

        [FindsBy(How = How.Id, Using = "contact_us_first_name")] private IWebElement _txtFirstName;

        [FindsBy(How = How.Id, Using = "contact_us_last_name")] private IWebElement _txtLastName;

        [FindsBy(How = How.Id, Using = "contact_us_email")] private IWebElement _txtEmail;

        [FindsBy(How = How.Id, Using = "contact_us_nature_of_inquiry")] private IWebElement _cboInquiry;

        [FindsBy(How = How.Id, Using = "contact_us_comments")] private IWebElement _txtComments;

        [FindsBy(How = How.Id, Using = "contact_us_submit")] private IWebElement _btnSubmit;

        [FindsBy(How = How.Id, Using = "contact_us_order_id")] private IWebElement _txtOrderId;

        [FindsBy(How = How.Id, Using = "contact_us_month")] private IWebElement _cboMonth;

        [FindsBy(How = How.Id, Using = "contact_us_day")] private IWebElement _cboDay;

        [FindsBy(How = How.Id, Using = "contact_us_year")] private IWebElement _cboYear;
        

        public ContactUs(IWebDriver driver) : base(driver) { }

        public bool Is1stNameTxtAvl()
        {
            return _txtFirstName.Enabled && _txtFirstName.Displayed;
        }

        public bool IsLastNameTxtAvl()
        {
            return _txtLastName.Enabled && _txtLastName.Displayed;
        }

        public bool IsEmailTxtAvl()
        {
            return _txtEmail.Enabled && _txtEmail.Displayed;
        }

        public string GetInquiryOpts(int option)
        {
           IWebElement[] a = new SelectElement(_cboInquiry).Options.ToArray();
            return a[option].Text.Trim();
        }

        public bool IsMsgInquiryAvl()
        {
            return _txtComments.Enabled && _txtComments.Displayed;
        }

        public string GetSubmitBtnTxt()
        {
            if (_btnSubmit.GetAttribute("value") != string.Empty)
                return _btnSubmit.GetAttribute("value").ToUpper();
            return _btnSubmit.Text.ToUpper();
        }

        public ContactUs SelectInquiryOption(string p)
        {
            new SelectElement(_cboInquiry).SelectByText(p);
            return NewPage<ContactUs>();
        }

        public bool IsOrderIDAvl()
        {
            return _txtOrderId.Enabled && _txtOrderId.Displayed;
        }

        public bool IsYearAvl()
        {
            return _cboYear.Enabled && _cboYear.Displayed;
        }

        public bool IsMonthIDAvl()
        {
            return _cboMonth.Enabled && _cboMonth.Displayed;
        }

        public bool IsDayAvl()
        {
            return _cboDay.Enabled && _cboDay.Displayed;
        }
    }
}
