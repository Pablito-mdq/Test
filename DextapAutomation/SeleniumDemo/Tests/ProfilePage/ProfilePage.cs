using NUnit.Framework;
using SeleniumDemo.Pages;
using SeleniumDemo.Utils;
using SeleniumDemo.Models;
using System.Windows.Forms;

namespace SeleniumDemo.Tests.ProfilePage
{
    class ProfilePage : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string client = DataParser.Getclient();

        [Category("Regression")]
        [Category("BAE")]
        //WS-317
        [Test]
        public void Settings_UpdatePassword_WS_1347()
        {
            if (!DataParser.ReturnExecution("WS_1347"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1347.xml";
                string password = GeneralData.GetPassword(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                var editProfile = home.EditProfile();
                editProfile.EnterPassword(password).EnterConfirmationPwd(password).ClickSubmit();
                Assert.AreEqual("Settings Successfully Saved!", editProfile.GetSuccessMsg(),
                    "Error Msg is not show or its wrong");
                home = editProfile.ClickOK().ClickSignOut().Logon().ClickLogin();
                Assert.AreEqual("Welcome Tester to the BAE Systems, IMPACT!", home.GetWelcomeTitle(),
                    "You are not in the Main Page");
            }
        }


        [Category("Regression")]
        [Category("BAE")]
        //WS-317
        [Test]
        public void ProfilePage_UpdatePassword_WS_1334()
        {
            if (!DataParser.ReturnExecution("WS_1334"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1334.xml";
                string password = GeneralData.GetPassword(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                var editProfile = home.EditProfile();
                editProfile.EnterPassword(password).EnterConfirmationPwd(password).ClickSubmit();
                Assert.AreEqual("Invalid Data - Password must have at least: 1 numeric characters, but only has: 0",
                    editProfile.GetErrorMsg(), "Error Msg is not show or its wrong");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-917
        [Test]
        public void Profile_UpdatingFields_WS_175()
        {
            if (!DataParser.ReturnExecution("WS_175"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_175.xml";
                string preferredName = RegisterData.GetRegisterPreferedName(_file);
                EditProfilePage profilePage = InitialPage.Go().Logon().ClickLogin().EditProfile();
                Assert.AreEqual("Profile Settings", profilePage.GetTitleName("Profile Settings"),
                    "Title is now well spell");
                profilePage.EnterPreferedName(preferredName).ClickSubmit();
                Assert.AreEqual(preferredName, profilePage.GetShowName(preferredName), "Prefered Name is now well spell");
                MainHomePage mainPage = profilePage.NavigateToHomePage();
                Assert.AreEqual("Welcome " + preferredName + " to the BAE Systems, IMPACT!", mainPage.GetWelcomeTitle(),
                    "Welcome Ttile is now well spell");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS-317
        [Test]
        public void Profile_UpdatePhotoAvatar_WS_1059()
        {
            if (!DataParser.ReturnExecution("WS_1059"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1059.xml";
                string path = GeneralData.path(_file);
                int width = GeneralData.width(_file), height = GeneralData.height(_file);
                MainHomePage home = InitialPage.Go().Logon().ClickLogin();
                var a = home.EditProfile();
                a.ClickUploadphoto();
                SendKeys.SendWait(path);
                SendKeys.SendWait("{ENTER}");
                int b = width * height;
                var c = a.getsizeuploadim();
                Assert.AreNotEqual(b, c, "The size is the same so,the image is not changed");
            }
        }



    }
}
