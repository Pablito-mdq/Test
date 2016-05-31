using NUnit.Framework;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.Login;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{
    class LoginPageTests : WorkStrideBaseTest<LoginPage>
    {
        public const string file ="Resources\\Enhanced_Proxy.xml";

        [Category("Regression")]
        //WS-917
        [Test]
        public void Validate_Login_Generic()
        {
            if (!DataParser.ReturnExecution("Validate_Login_Generic"))
                Assert.Ignore();
            else
            {
                LoginPage loginPage = InitialPage.Go();
                Assert.AreEqual("Email Address", loginPage.GetUsernameTitleGeneric(), "title is not IMPACT ID");
                Assert.AreEqual("Password", loginPage.GetPasswordTitleGeneric(), "title is not Password");
                Assert.IsTrue(loginPage.IsUsernameFieldAvl(), "username field is not available");
                Assert.IsTrue(loginPage.IsPasswordFieldAvl(), "password field is not available");
            }
        }

        [Category("Regression")]
        //WS-917
        [Test]
        public void Login()
        {
            if (!DataParser.ReturnExecution("Login"))
                Assert.Ignore();
            else
            {
                LoginPage loginPage = InitialPage.Go().Logon();
                MainHomePage myJobs = loginPage.ClickLogin();
                Assert.IsTrue(loginPage.Imlogin(), "You are not login");
            }
        }


        [Category("Regression")]
        //WS-917
        [Test]
        public void Fail_Login()
        {
            if (!DataParser.ReturnExecution("Fail_Login"))
                Assert.Ignore();
            else
            {
                LoginPage loginPage = InitialPage.Go().FailLogon();
                loginPage.ClickLogin();
                Assert.AreEqual("Not Found - Invalid Credentials", loginPage.GetFailLoginMsg(),
                    "The message is not the correct for fail login");
            }
        }

        [Category("Regression")]
        //WS-917
        [Test]
        public void Join_Now()
        {
            if (!DataParser.ReturnExecution("Join_Now"))
                Assert.Ignore();
            else
            {
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                Assert.IsTrue(registerPage.IRegisterBtnAvailable(), "Register button is not available");
            }
        }

        [Category("Regression")]
        //WS-917
        [Test]
        public void Forgot_Password()
        {
            if (!DataParser.ReturnExecution("Forgot_Password"))
                Assert.Ignore();
            else
            {
                ForgotPassword forgotPasswordPage = InitialPage.Go().ClickForgotPassword();
                Assert.AreEqual("Change Your Password", forgotPasswordPage.GetLabelTitle(), "The label is not correct");
                Assert.AreEqual("Find your account", forgotPasswordPage.GetLabelSubTitle(), "The label is not correct");
                Assert.IsTrue(forgotPasswordPage.IsEmailFieldAvailable(), "email field is not available");
                Assert.IsTrue(forgotPasswordPage.IsBtnContinueAvailable(), "continue button is not available");
                Assert.AreEqual("Continue", forgotPasswordPage.GetBtnContinueTxt(), "The label is not correct");
            }
        }

        [Category("Regression")]
        //WS-917
        [Test]
        public void Contact_Us()
        {
            if (!DataParser.ReturnExecution("Contact_Us"))
                Assert.Ignore();
            else
            {
                ContactUs contactUsPage = InitialPage.Go().ClickContactUs();
                Assert.IsTrue(contactUsPage.Is1stNameTxtAvl(), "The label is not correct");
                Assert.IsTrue(contactUsPage.IsLastNameTxtAvl(), "The label is not correct");
                Assert.IsTrue(contactUsPage.IsEmailTxtAvl(), "email field is not available");
                Assert.AreEqual("Access - Password", contactUsPage.GetInquiryOpts(0), "Option is not correct");
                Assert.AreEqual("Access - Username", contactUsPage.GetInquiryOpts(1), "Option is not correct");
                Assert.AreEqual("Access - Non Registered User", contactUsPage.GetInquiryOpts(2), "Option is not correct");
                Assert.AreEqual("Access - Email Address", contactUsPage.GetInquiryOpts(3), "Option is not correct");
                Assert.AreEqual("Gift Certificate - Balance", contactUsPage.GetInquiryOpts(4), "Option is not correct");
                Assert.AreEqual("Gift Certificate - Add Value", contactUsPage.GetInquiryOpts(5), "Option is not correct");
                Assert.AreEqual("Gift Certificate - History", contactUsPage.GetInquiryOpts(6), "Option is not correct");
                Assert.AreEqual("Gift Certificate - Activation Status", contactUsPage.GetInquiryOpts(7),
                    "Option is not correct");
                Assert.AreEqual("Gift Certificate - Order Status", contactUsPage.GetInquiryOpts(8),
                    "Option is not correct");
                for (int i = 4; i < 9; i++)
                {
                    contactUsPage.SelectInquiryOption(contactUsPage.GetInquiryOpts(i));
                    Assert.IsTrue(contactUsPage.IsOrderIDAvl(), "Order id field is not available");
                    Assert.IsTrue(contactUsPage.IsYearAvl(), "Order id field is not available");
                    Assert.IsTrue(contactUsPage.IsMonthIDAvl(), "Order id field is not available");
                    Assert.IsTrue(contactUsPage.IsDayAvl(), "Order id field is not available");
                }
                Assert.AreEqual("Other", contactUsPage.GetInquiryOpts(9), "Option is not correct");
                Assert.IsTrue(contactUsPage.IsMsgInquiryAvl(), "continue button is not available");
                Assert.AreEqual("SUBMIT", contactUsPage.GetSubmitBtnTxt(), "The label is not correct");
            }
        }
        
        [Category("Regression")]
        [Test]
        public void Recognition_Employee_Not_Found()
        {
            if (!DataParser.ReturnExecution("Recognition_Employee_Not_Found"))
                Assert.Ignore();
            else
            {
                NominationHomePage nominationPage = InitialPage.Go().Logon().ClickLogin().NavigateToNomination();
                nominationPage.SearchEmployeeNotFound("Chuck Norris");
                Assert.AreEqual("Unfortunately we are unable to provide any suggestions at this time. Try using the field above to look-up a colleague.", nominationPage.GetErrorEmployeeMsg(),
                    "The user exists or the msg  not the correct");
            }
        }
        
    }
}
