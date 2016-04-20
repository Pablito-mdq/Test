using NUnit.Framework;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Tests.Pages;

namespace SeleniumDemo.Tests
{
    /// <summary>
    /// DX-3
    /// 
    /// </summary>
    [Category("Regression")]
    class SampleTestSuite : DextapBaseTest<LoginPage>
    {

        /// <summary>
        /// 
        /// </summary>
        /// 
        [Test]
        public void WS_Login()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("support@workstride.com");
            loginPage.EnterPassword("Demo9494");
            MainHomePage myJobs = loginPage.Login();
        }

        [Test]
        public void WS_Rewards()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("support@workstride.com");
            loginPage.EnterPassword("Demo9494");
            MainHomePage home = loginPage.Login();
            AdminHomePage rewards = home.NavigateToAdminHomePage();
           
        }
       
        [Test]
        public void WS_Proxy()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("support@workstride.com");
            loginPage.EnterPassword("Demo9494");
            MainHomePage home = loginPage.Login();
            AdminHomePage adminPage = home.NavigateToAdminHomePage();
            ProxyHomePage proxyPage = adminPage.LoginProxyAsuser();
            proxyPage.EnterUserName("Joanna Copeland");
            home = proxyPage.ProxyToMainHomePage();
            Assert.AreEqual("You are proxied in under: Joanna Copeland", home.GetProxyLoginMsg(), "The message of proxy login is not correct");
        }

        [Test]
        public void WS_Nomination()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("support@workstride.com");
            loginPage.EnterPassword("Demo9494");
            MainHomePage home = loginPage.Login();
            NominationHomePage nominationPage = home.NavigateToNomination();
            nominationPage.SearchEmployee("Joanna Copeland");
            nominationPage.SelectAward();
            nominationPage.SelectValues().FillMsg().FillReason().ClickNext();
            nominationPage.PrintReward().SendRecognition();
            Assert.AreEqual("Success!",nominationPage.GetSuccesMsg(),"The recognition was not send successfully");
        }

        [Test]
        public void DX_25()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("bassid");
            loginPage.EnterPassword("dextap218");
            MainHomePage myJobs = loginPage.Login();
            EditProfilePage Profile = myJobs.NavigateToolsProfile();
            Profile.SelectRegion("CFS1 (OLY UK)");
            Profile.Save();
            Profile.PopupConfirm();
            //AdminPage NewJob = Profile.NavigateNewJob();
            //Assert.AreEqual("CFS1 (OLY UK)", NewJob.GetRegion(), "Region entered is not default email");
        }
        [Test]
        public void DX_26()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("bassid");
            loginPage.EnterPassword("dextap218");
            MainHomePage myJobs = loginPage.Login();
            EditProfilePage Profile = myJobs.NavigateToolsProfile();
           // Profile.EnterEmail("test@kantar.com");
            Profile.Save();
            Profile.PopupConfirm();
            //AdminPage NewJob = Profile.NavigateNewJob();
            //Assert.AreNotEqual("test@kantar.com", NewJob.GetEmailJob(), "Email entered is not default email");
        }
        [Test]
        public void DX_29()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("bassid");
            loginPage.EnterPassword("dextap218");
            MainHomePage myJobs = loginPage.Login();
           // Assert.IsTrue(myJobs.ShowJobList(), "Job List cannot be show");
            Assert.IsTrue(myJobs.ShowsEntriesDisplayed(), "Doesnt show quantity of entries");
            myJobs.SelectShowEntries("100");
            Assert.AreEqual("100",myJobs.GetShowEntries(),"Show entries Quantity is not the option that was choose");

        }
        [Test]
        public void DX_41()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("bassido");
            loginPage.EnterPassword("dextap2181");
            loginPage.Logon();
            Assert.IsTrue(loginPage.LoginErrorMsg(), "Job List cannot be show");
            loginPage.EnterUsername("bassid");
            loginPage.EnterPassword("dextap2181");
            loginPage.Logon();
            Assert.IsTrue(loginPage.LoginErrorMsg(), "Job List cannot be show");
        }
        [Test]
        public void DX_42()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("bassid");
            loginPage.EnterPassword("dextap218");
            MainHomePage myJobs = loginPage.Login();
           // Assert.IsTrue(myJobs.ShowJobList(),"Job List cannot be show");
        }
        [Test]
        public void DX_56()
        {
        LoginPage loginPage = InitialPage.Go();
        Assert.IsTrue(loginPage.VerifyVersion(),"The Dextap version is not the last one");     
        }
        [Test]
        public void DX_62()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("bassid");
            loginPage.EnterPassword("dextap218");
            //AdminPage NewJob = loginPage.Login().NavigateNewJob();
            //Assert.AreNotEqual("This Data View dropdown will be populated by the system depending on the Export Type selected. The Data View can be adjusted after selecting the Export Type. Variables with an HDATA-only view (unexpanded/unbounded loops or grids) cannot be extracted in the following Data Types: CSV, Excel, Sav, and XML. Selecting one of these Data Types with a VDATA view will result in a data file which excludes any HDATA-only variables.", NewJob.GetDataMsg(), "Help data tool tip is not visible");
        }
        [Test]
        public void DX_112()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("bassid");
            loginPage.EnterPassword("dextap218");
           /* AdminPage NewJob = loginPage.Login().NavigateNewJob();
            Assert.IsTrue(NewJob.FormDisplay(), "Cannot display New Job Form");
            NewJob.SelectExportType("DDF (Beta)");
            Assert.IsTrue(NewJob.LegacyShellEnable(), "Export Legacy Shell Variables is not Enable");
            NewJob.SelectExportType("CSV");
            Assert.IsFalse(NewJob.LegacyShellEnable(), "Export Legacy Shell Variables is Enable");
            NewJob.SelectExportType("DAU");
            Assert.IsFalse(NewJob.LegacyShellEnable(), "Export Legacy Shell Variables is Enable");
            NewJob.SelectExportType("Excel");
            Assert.IsFalse(NewJob.LegacyShellEnable(), "Export Legacy Shell Variables is Enable");
            NewJob.SelectExportType("Quantum");
            Assert.IsFalse(NewJob.LegacyShellEnable(), "Export Legacy Shell Variables is Enable");
            NewJob.SelectExportType("SPSS");
            Assert.IsFalse(NewJob.LegacyShellEnable(), "Export Legacy Shell Variables is Enable");*/
        }
        [Test]
        public void DX_97()
        {
            LoginPage loginPage = InitialPage.Go();
            loginPage.EnterUsername("bassid");
            loginPage.EnterPassword("dextap218");
            MainHomePage MyJobs = loginPage.Login();
           /* AdminPage NewJob = MyJobs.NavigateNewJob();
            Assert.IsTrue(NewJob.EndDateDisplayed(), "Cannot display End Date Field");
            NewJob.SelectEndDate("10/31/2014");
            Assert.IsTrue(NewJob.CalendarPickerDisplay(), "Calendar picker cannot be open");
            NewJob.SelectServerType("Live");
            NewJob.SelectDatabase("Cluster T6 - Live 6.0.1");
            NewJob.setJobName("C4DU");
            NewJob.CopyMDDFile("C4DAD.mdd");
            NewJob.SaveJob();
            Assert.IsTrue(MyJobs.ShowJobList(), "Job List cannot be show");*/
        }
    }
}
