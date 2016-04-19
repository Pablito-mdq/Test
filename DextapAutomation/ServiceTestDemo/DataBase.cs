using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using System.IO;
using System.Transactions;

namespace ServiceTestingFramework.NUnit.SQL
{

    /// <summary>
    /// NUnit's framework DataBase attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class DataBaseAttribute : Attribute, ITestAction
    {
        protected ILog LOG = LogManager.GetLogger(typeof(DataBaseAttribute));
        private readonly string ProjectName;
        private readonly int Times;
        private TransactionScope scope;

        /// <summary>
        /// Loads a BAK file into a MSSQL server as many times as instructed. Defaults to one time.
        /// </summary>
        /// <param name="projectName">Name of the database BAK file</param>
        /// <param name="times">Number of times to replicate the database.</param>
        public DataBaseAttribute(string projectName, int times = 1)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.xml"));
            ProjectName = projectName;
            Times = times;
        }

        public void BeforeTest(TestDetails details)
        {
            // Define a transactional scope for SQL connections
            scope = new TransactionScope(); 
            
            WriteToConsole(details);
            
            doDatabaseMangling();
        }

        public void AfterTest(TestDetails details)
        {
            // Roll back transactions on SQL connections
            scope.Dispose(); 
            WriteToConsole(details);
            doDatabaseRollback();
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test | ActionTargets.Suite; }
        }

        private void doDatabaseMangling()
        {
            LOG.Info("Duplicating databases " + Times + " times...");
        }

        private void doDatabaseRollback()
        {
            LOG.Info("Wiping out databases " + Times + " times...");
        }

        private void WriteToConsole(TestDetails details)
        {
            string TestScope = details.IsSuite ? "Suite" : "Case";
            string TestFixture = details.Fixture != null ? details.Fixture.GetType().Name : "{no fixture}";
            string TestName = details.Method != null ? details.Method.Name : "{no method}";
            LOG.Info(TestScope + ": " + ProjectName + ", from " + TestFixture + "." + TestName);                
        }
    }

}
