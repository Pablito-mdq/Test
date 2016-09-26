using NUnit.Framework;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.Login;
using SeleniumDemo.Utils;
using SeleniumDemo.Models;

namespace SeleniumDemo.Tests
{
    class Registration : WorkStrideBaseTest<LoginPage>
    {
        string client = DataParser.Getclient();
        string _file;


        [Category("Regression")]
        [Category("BAE")]
        //WS_1212
        [Test]
        public void Registration_EmailUnsuccesfull_WS_1212()
        {
            if (!DataParser.ReturnExecution("WS_1212"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1212.xml";
                string firstName = RegisterData.GetRegisterFirstName(_file),
                    lastName = RegisterData.GetRegisterLastName(_file),
                    ID = RegisterData.GetRegisterID(_file),
                    email = RegisterData.GetRegisterEmail(_file);
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.AreEqual("First Name", registerPage.GetName("First Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.AreEqual("Last Name", registerPage.GetName("Last Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.AreEqual("Employee ID", registerPage.GetName("Employee ID"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.AreEqual("Email Address", registerPage.GetName("Email Address"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                registerPage.EnterFirstName(firstName)
                    .EnterLastName(lastName)
                    .EnterEmployeeID(ID)
                    .EnterEmployeeEmail(email)
                    .ClickRegister();
                Assert.AreEqual(
                    "Hmm, we couldn't find anyone matching the information you entered. Please make sure your email and Employee ID are correct. Also, maybe we have a different variation of your first or last name?",
                    registerPage.GetSuccessMsg(), "Message is not the expected");
            }
        }



        [Category("Regression")]
        [Category("BAE")]
        //WS_1212
        [Test]
        public void Registration_UnsuccesfullFirstName_WS_1216()
        {
            if (!DataParser.ReturnExecution("WS_1216"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1216.xml";
                string firstName = RegisterData.GetRegisterFirstName(_file),
                    lastName = RegisterData.GetRegisterLastName(_file),
                    ID = RegisterData.GetRegisterID(_file),
                    email = RegisterData.GetRegisterEmail(_file);
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.AreEqual("First Name", registerPage.GetName("First Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.AreEqual("Last Name", registerPage.GetName("Last Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.AreEqual("Employee ID", registerPage.GetName("Employee ID"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.AreEqual("Email Address", registerPage.GetName("Email Address"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                registerPage.EnterFirstName(firstName)
                    .EnterLastName(lastName)
                    .EnterEmployeeID(ID)
                    .EnterEmployeeEmail(email)
                    .ClickRegister();
                Assert.AreEqual(
                    "Hmm, we couldn't find anyone matching the information you entered. Please make sure your email and Employee ID are correct. Also, maybe we have a different variation of your first or last name?",
                    registerPage.GetSuccessMsg(), "Message is not the expected");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1212
        [Test]
        public void Registration_UnsuccesfulEmpId_WS_1218()
        {
            if (!DataParser.ReturnExecution("WS_1218"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1218.xml";
                string firstName = RegisterData.GetRegisterFirstName(_file),
                    lastName = RegisterData.GetRegisterLastName(_file),
                    ID = RegisterData.GetRegisterID(_file),
                    email = RegisterData.GetRegisterEmail(_file);
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.AreEqual("First Name", registerPage.GetName("First Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.AreEqual("Last Name", registerPage.GetName("Last Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.AreEqual("Employee ID", registerPage.GetName("Employee ID"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.AreEqual("Email Address", registerPage.GetName("Email Address"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                registerPage.EnterFirstName(firstName)
                    .EnterLastName(lastName)
                    .EnterEmployeeID(ID)
                    .EnterEmployeeEmail(email)
                    .ClickRegister();
                Assert.AreEqual(
                    "Hmm, we couldn't find anyone matching the information you entered. Please make sure your email and Employee ID are correct. Also, maybe we have a different variation of your first or last name?",
                    registerPage.GetSuccessMsg(), "Message is not the expected");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-917
        [Test]
        public void Registration_JoinNowSuccess_WS_1052()
        {
            if (!DataParser.ReturnExecution("WS_1052"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1052.xml";
                string firstName = RegisterData.GetRegisterFirstName(_file),
                    lastName = RegisterData.GetRegisterLastName(_file),
                    ID = RegisterData.GetRegisterID(_file),
                    email = RegisterData.GetRegisterEmail(_file);
                Register registerPage = InitialPage.Go().ClickJoinNow();
                Assert.AreEqual("First Name", registerPage.GetName("First Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsFirstNameFieldAvailable(), "First Name field is not available");
                Assert.AreEqual("Last Name", registerPage.GetName("Last Name"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsLastNameAvailable(), "Last Name button is not available");
                Assert.AreEqual("Employee ID", registerPage.GetName("Employee ID"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsIDFieldAvailable(), "ID field is not available");
                Assert.AreEqual("Email Address", registerPage.GetName("Email Address"), "First Name is now well spell");
                Assert.IsTrue(registerPage.IsEmailFieldAvailable(), "email field is not available");
                registerPage.EnterFirstName(firstName)
                    .EnterLastName(lastName)
                    .EnterEmployeeID(ID)
                    .EnterEmployeeEmail(email)
                    .ClickRegister();
                Assert.AreEqual(
                    "Success!\r\nWe found you. Check your inbox at " + email +
                    " for a link to finish registration. Thank you!", registerPage.GetSuccessMsg(),
                    "Message is not the expected");
            }
        }


    }
}
