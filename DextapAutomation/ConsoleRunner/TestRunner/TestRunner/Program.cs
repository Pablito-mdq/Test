using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRunner.Methods;
using System.Xml;
using System.Diagnostics;

namespace TestRunner
{
    class Program
    {

        static void Main(string[] args)
        {

            string Client = null;
            string BatchFileName = null;
            string UrlToRun = null;
            string Browser = null;

            //Used to set all the config arguments before the tests run.
            while (true)
            {
                Browser = Util.SetBrowser();
                Client = Util.SetClient();
                UrlToRun = Util.CheckAndSetUrl(Client);
                Util.SetConfigValues(Client, Browser);
                BatchFileName = string.Format(@"TestBatchFiles\{0}.bat", Client);
                bool GoodToGo = Util.ConfirmAndExecute(Client, Browser, UrlToRun);

                if (GoodToGo)
                {
                    break;
                }
                else
                {
                    Util.PrintMessage("The Program is restarting, please follow the prompts correctly!");
                }
            }

            //Cleans up results directory
            Util.CheckDirectoryAndDelete(Client);

            //Executes Tests
            Util.PrintMessage("Running Tests...");
            Util.ExecuteProcess(BatchFileName);

            //Executes Test Report And Sends Email
            Util.ExecuteTestReporter(Client);
            Util.SendEmailWithRecipients();
            //Util.KillLeftOverProcesses();

        }
    }
}
