using NUnit.Framework;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [Category("Regression")]
    class HomePageTest : WorkStrideBaseTest<LoginPage>
    {

       /// <summary>
        /// WS_XXX
        /// </summary>
        /// 
        /*
        [Test]
        public void WS_120()
        {
            if (!Utils.DataParser.ReturnExecution("WS_120"))
                Assert.Ignore();
            else
            {
                string option = "Relevant to Me", option1 = "Everyone", option2 = "Following", option3, option4;
                MainHomePage mainPage = InitialPage.Go().Logon().ClickLogin().ClickDisplayOptions();
                Assert.AreEqual(option, mainPage.GetShowOptTxt(option), "The label option is not the correct");
                Assert.AreEqual(option1, mainPage.GetShowOptTxt(option1), "The label option is not the correct");
                Assert.AreEqual(option2, mainPage.GetShowOptTxt(option2), "The label option is not the correct");
                option = "Anniversary";
                option1 = "Recognition";
                option2 = "New Hires";
                option3 = "Birthday";
                option4 = "First Time Login";
                Assert.AreEqual(option, mainPage.GetShowOptTxt(option), "The user exists or the msg is not the correct");
                Assert.AreEqual(option1, mainPage.GetShowOptTxt(option1),
                    "The user exists or the msg is not the correct");
                Assert.AreEqual(option2, mainPage.GetShowOptTxt(option2),
                    "The user exists or the msg is not the correct");
                Assert.AreEqual(option3, mainPage.GetShowOptTxt(option3),
                    "The user exists or the msg is not the correct");
                Assert.AreEqual(option4, mainPage.GetShowOptTxt(option4),
                    "The user exists or the msg is not the correct");
                Assert.IsTrue(mainPage.IDatePickerAvailable(), "Date picker is not available");
            }
        }*/
    }
}
