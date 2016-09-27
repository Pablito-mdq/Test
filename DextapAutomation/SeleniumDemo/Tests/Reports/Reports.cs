using System;
using System.Windows.Forms;
using NUnit.Framework;
using SeleniumDemo.Models;
using SeleniumDemo.Pages;
using SeleniumDemo.Pages.AdminPage;
using SeleniumDemo.Pages.LeftMenu;
using SeleniumDemo.Pages.LeftMenu.EventCalendar;
using SeleniumDemo.Pages.LeftMenu.GoToMall;
using SeleniumDemo.Pages.Login;
using SeleniumDemo.Pages.NominationPage;
using SeleniumDemo.Pages.Reports;
using SeleniumDemo.Tests.Pages;
using SeleniumDemo.Utils;

namespace SeleniumDemo.Tests
{ 

    internal class Reports : WorkStrideBaseTest<LoginPage>
    {
        private static string _file;
        private static string username;
        private static string client = DataParser.Getclient();
        private static string url = ConfigUtil.ImportConfigURL(string.Format("Resources\\{0}\\Url.xml",client), client);


      

        [Category("Regression")]
        [Category("BAE")]
        [Category("Sprint")]
        //WS_1225
        [Test]
        public void Reports_SortingColumns_WS_1225()
        {
            if (!DataParser.ReturnExecution("WS_1225"))
                Assert.Ignore();
            else
            {
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                Assert.AreEqual(url + "report/bae_awards", reportpage.GetCurrentUrl(), "URL is not the correct");
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(1);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(2);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(3);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(4);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(5);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(6);
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickHeader(7);
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1229
        [Test]
        public void Reports_TestLeftLinks_WS_1229()
        {
            if (!DataParser.ReturnExecution("WS_1229"))
                Assert.Ignore();
            else
            {
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("All Awards"), "Option is not well written");
                reportpage.ClickLeftMenu("All Awards");
                Assert.AreEqual(url + "report/bae_awards", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("All Awards (Sector)"), "Option is not well written");
                reportpage.ClickLeftMenu("All Awards (Sector)");
                Assert.AreEqual(url + "report/bae_awards_by_sector", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Issued Awards"), "Option is not well written");
                reportpage.ClickLeftMenu("Issued Awards");
                Assert.AreEqual(url + "report/bae_issued_awards", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Teams Awards"), "Option is not well written");
                reportpage.ClickLeftMenu("Teams Awards");
                Assert.AreEqual(url + "report/awards_by_manager", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Milestones"), "Option is not well written");
                reportpage.ClickLeftMenu("Milestones");
                Assert.AreEqual(url + "report/milestones", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Received Awards"), "Option is not well written");
                reportpage.ClickLeftMenu("Received Awards");
                Assert.AreEqual(url + "report/bae_received_awards", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Payroll (Sector)"), "Option is not well written");
                reportpage.ClickLeftMenu("Payroll (Sector)");
                Assert.AreEqual(url + "report/bae_payroll_sector", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Payroll"), "Option is not well written");
                reportpage.ClickLeftMenu("Payroll");
                Assert.AreEqual(url + "report/bae_payroll", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Budget"), "Option is not well written");
                reportpage.ClickLeftMenu("Budget");
                Assert.AreEqual(url + "report/edit_budget_tool", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Pending Approvals"), "Option is not well written");
                reportpage.ClickLeftMenu("Pending Approvals");
                Assert.AreEqual(url + "report/pending_approvals", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Team Pending Approvals"),
                    "Option is not well written");
                reportpage.ClickLeftMenu("Team Pending Approvals");
                Assert.AreEqual(url + "report/pending_approvals_by_manager", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Proxy Access"), "Option is not well written");
                reportpage.ClickLeftMenu("Proxy Access");
                Assert.AreEqual(url + "report/proxy_access", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Activity"), "Option is not well written");
                reportpage.ClickLeftMenu("Activity");
                Assert.AreEqual(url + "report/activities", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Missing Emails (Internal)"),
                    "Option is not well written");
                reportpage.ClickLeftMenu("Missing Emails (Internal)");
                Assert.AreEqual(url + "report/bae_missing_emails", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Awards By Budget"), "Option is not well written");
                reportpage.ClickLeftMenu("Awards By Budget");
                Assert.AreEqual(url + "report/awards_by_budget_owner", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Payroll By Budget"), "Option is not well written");
                reportpage.ClickLeftMenu("Payroll By Budget");
                Assert.AreEqual(url + "report/payroll_by_budget_owner", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Manager Issued Awards"),
                    "Option is not well written");
                reportpage.ClickLeftMenu("Manager Issued Awards");
                Assert.AreEqual(url + "report/manager_awards", reportpage.GetCurrentUrl(), "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Awards By Payroll (HRBP)"),
                    "Option is not well written");
                reportpage.ClickLeftMenu("Awards By Payroll (HRBP)");
                Assert.AreEqual(url + "report?reportName=bae_payroll_by_budget_owner_hrbp", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Budget Transactions"), "Option is not well written");
                reportpage.ClickLeftMenu("Budget Transactions");
                Assert.AreEqual(url + "report/budget_adjustments", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
                Assert.IsTrue(reportpage.IsOptLeftMenuNameDisplayed("Manager Award Totals"),
                    "Option is not well written");
                reportpage.ClickLeftMenu("Manager Award Totals");
                Assert.AreEqual(url + "report/manager_issued_awards", reportpage.GetCurrentUrl(),
                    "Url is not the expected one");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1231
        [Test]
        public void Reports_DateFilterWorks_WS_1231()
        {
            if (!DataParser.ReturnExecution("WS_1231"))
                Assert.Ignore();
            else
            {
                _file = "Resources\\" + client + "\\TestsData\\WS_1231.xml";
                string startDate = ReportFilterData.GetStartDate(_file),
                    finishDate = ReportFilterData.GetFinishDate(_file);
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                reportpage.ClickFilter().EnterStartDate(startDate).EnterFinishDate(finishDate).ClickSubmit();
                Assert.AreEqual(startDate, reportpage.GetDate(0), "Start Date is not the same");
                Assert.AreEqual(finishDate, reportpage.GetDate(1), "Start Date is not the same");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1227
        [Test]
        public void Reports_VerifyContainsData_WS_1227()
        {
            if (!DataParser.ReturnExecution("WS_1227"))
                Assert.Ignore();
            else
            {
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports().SelectPageSize("500");
                int row = 500, col = 7;
                for (int i = 1; i < row; i++)
                    for (int j = 1; j < col; j++)
                        Assert.IsTrue(reportpage.IsCellFull(i, j), "Cell is empty");
                Assert.Pass("All cell Are full");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1233
        [Test]
        public void Reports_TestReportLoadTimes_WS_1233()
        {
            if (!DataParser.ReturnExecution("WS_1233"))
                Assert.Ignore();
            else
            {
                int[] list = new int[21];
                for (int i = 0; i < 21; i++)
                {
                    list[i] = Convert.ToInt32("1");
                }
                ReportsPage reportpage = InitialPage.Go().Logon().ClickLogin().NavigateToReports();
                Assert.AreEqual(url + "report/bae_awards", reportpage.GetCurrentUrl(), "URL is not the correct");
                Assert.IsFalse(reportpage.LoadTakesMoreThan10sec(), "The Report takes more than 10 sec to load");
                reportpage.ClickLeftMenu("All Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[1] = 0;
                reportpage.ClickLeftMenu("All Awards (Sector)");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[2] = 0;
                reportpage.ClickLeftMenu("Issued Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[3] = 0;
                reportpage.ClickLeftMenu("Teams Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[4] = 0;
                reportpage.ClickLeftMenu("Milestones");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[5] = 0;
                reportpage.ClickLeftMenu("Received Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[6] = 0;
                reportpage.ClickLeftMenu("Payroll (Sector)");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[7] = 0;
                reportpage.ClickLeftMenu("Payroll");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[8] = 0;
                reportpage.ClickLeftMenu("Budget");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[9] = 0;
                reportpage.ClickLeftMenu("Pending Approvals");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[10] = 0;
                reportpage.ClickLeftMenu("Team Pending Approvals");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[11] = 0;
                reportpage.ClickLeftMenu("Proxy Access");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[12] = 0;
                reportpage.ClickLeftMenu("Activity");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[13] = 0;
                reportpage.ClickLeftMenu("Missing Emails (Internal)");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[14] = 0;
                reportpage.ClickLeftMenu("Awards By Budget");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[15] = 0;
                reportpage.ClickLeftMenu("Payroll By Budget");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[16] = 0;
                reportpage.ClickLeftMenu("Manager Issued Awards");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[17] = 0;
                reportpage.ClickLeftMenu("Awards By Payroll (HRBP)");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[18] = 0;
                reportpage.ClickLeftMenu("Budget Transactions");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[19] = 0;
                reportpage.ClickLeftMenu("Manager Award Totals");
                if (!reportpage.LoadTakesMoreThan10sec())
                    list[20] = 0;
                int j = 0;
                while ((list[j] == 1) && (j < 21))
                    j++;
                if (j == 21)
                    Assert.Pass("All the links are loaded in less than 10 sec");
                Assert.Fail("Not all the links are loading in less than 10 secs");
            }
        }

     

        [Category("Regression")]
        [Category("BAE")]
        //WS_1274
        [Test]
        public void BudGetReport_EditModal_WS_1277()
        {
            if (!DataParser.ReturnExecution("WS_1277"))
                Assert.Ignore();
            else
            {
                BudgetHomePage reportpage =
                    InitialPage.Go().Logon().ClickLogin().NavigateToReports().ClickBudgetLeftMenu();
                var balance = reportpage.GetAwardTable(1, 6);
                var editdetailsPage = reportpage.ClickEdit(1);
                Assert.AreEqual("ADD", reportpage.GetAddBtnTxt(), "Issuer Value is not the same");
                Assert.AreEqual("SUBTRACT", reportpage.GetSubstratBtnTxt(), "Subtract Value is not the same");
                Assert.AreEqual("DEACTIVATE", reportpage.GetDeactBtnTxt(), "Deactivate Value is not the same");
                Assert.AreEqual("CLOSE", reportpage.GetBtnCloseTxt(), "close Value is not the same");
                reportpage = editdetailsPage.EnterAmount("1000").ClickAdd();
                var amount = balance + 1000;
                Assert.AreEqual(amount, reportpage.GetAwardTable(1, 6), "Budget Value is not the same");
            }
        }

        [Category("Regression")]
        [Category("BAE")]
        //WS_1282
        [Test]
        public void BudgetReport_DeactivateModal_WS_1282()
        {
            if (!DataParser.ReturnExecution("WS_1282"))
                Assert.Ignore();
            else
            {
                BudgetHomePage reportpage =
                    InitialPage.Go().Logon().ClickLogin().NavigateToReports().ClickBudgetLeftMenu();
                var editdetailsPage = reportpage.ClickEdit(1);
                Assert.AreEqual("ADD", reportpage.GetAddBtnTxt(), "Issuer Value is not the same");
                Assert.AreEqual("SUBTRACT", reportpage.GetSubstratBtnTxt(), "Subtract Value is not the same");
                Assert.AreEqual("DEACTIVATE", reportpage.GetDeactBtnTxt(), "Deactivate Value is not the same");
                Assert.AreEqual("CLOSE", reportpage.GetBtnCloseTxt(), "close Value is not the same");
                reportpage.ClickDeactivate();
                editdetailsPage = reportpage.ClickEdit(1);
                Assert.AreEqual("Budget Active Status: false", editdetailsPage.GetDeactMsg(),
                    "Deact Text is not the same as expected");
                editdetailsPage.ClickActivate();
                reportpage = editdetailsPage.ClickEdit(1);
                Assert.AreEqual("ADD", reportpage.GetAddBtnTxt(), "Issuer Value is not the same");
                Assert.AreEqual("SUBTRACT", reportpage.GetSubstratBtnTxt(), "Subtract Value is not the same");
                Assert.AreEqual("DEACTIVATE", reportpage.GetDeactBtnTxt(), "Deactivate Value is not the same");
                Assert.AreEqual("CLOSE", reportpage.GetBtnCloseTxt(), "close Value is not the same");
                reportpage.ClickClose();
            }
        }

      
     

     
     
    }
}