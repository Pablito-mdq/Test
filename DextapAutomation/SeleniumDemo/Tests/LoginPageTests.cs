using NUnit.Framework;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.Login;

namespace SeleniumDemo.Tests
{
    class LoginPageTests : WorkStrideBaseTest<LoginPage>
    {
        public const string file ="Resources\\Enhanced_Proxy.xml";

        [Category("Smoke")]
        //WS-917
        [Test]
        public void Validate_Login_Generic()
        {
            if (!Utils.DataParser.ReturnExecution("Validate_Login_Generic"))
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

        [Category("Smoke")]
        //WS-917
        [Test]
        public void Login()
        {
            if (!Utils.DataParser.ReturnExecution("Login"))
                Assert.Ignore();
            else
            {
                LoginPage loginPage = InitialPage.Go().Logon();
                MainHomePage myJobs = loginPage.ClickLogin();
                Assert.IsTrue(loginPage.Imlogin(), "You are not login");
            }
        }


        [Category("Smoke")]
        //WS-917
        [Test]
        public void Fail_Login()
        {
            if (!Utils.DataParser.ReturnExecution("Fail_Login"))
                Assert.Ignore();
            else
            {
                LoginPage loginPage = InitialPage.Go().FailLogon();
                loginPage.ClickLogin();
                Assert.AreEqual("Not Found - Invalid Credentials", loginPage.GetFailLoginMsg(),
                    "The message is not the correct for fail login");
            }
        }

        [Category("Smoke")]
        //WS-917
        [Test]
        public void Join_Now()
        {
            if (!Utils.DataParser.ReturnExecution("Join_Now"))
                Assert.Ignore();
            else
            {
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "email field is not available");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "continue button is not available");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "email field is not available");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                Assert.IsTrue(registerPage.IRegisterBtnAvailable(), "email field is not available");
            }
        }

        [Category("Smoke")]
        //WS-917
        [Test]
        public void Forgot_Password()
        {
            if (!Utils.DataParser.ReturnExecution("Forgot_Password"))
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

        [Category("Smoke")]
        //WS-917
        [Test]
        public void Contact_Us()
        {
            if (!Utils.DataParser.ReturnExecution("Contact_Us"))
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




        /*
        [Category("Smoke")]
        [Test]
        public void EmployeeNotFound()
        {
            NominationHomePage nominationPage = InitialPage.Go().Logon().ClickLogin().NavigateToNomination();
            nominationPage.SearchEmployeeNotFound("Chuck Norris");
            Assert.AreEqual("We can't find anyone matching your search.", nominationPage.GetErrorEmployeeMsg(), "The user exists or the msg is not the correct");
        }
        */
    }
}
