using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;


namespace TestRunner.Methods
{
    public class Util
    {
        public static string SetBrowser()
        {
            string BrowserType;

            PrintMessage(string.Format("Hello {0}, please enter the browser type you would like to use for your tests", Environment.UserName));
            while (true)
            {
                BrowserType = Console.ReadLine().ToUpper().Trim();
                if (BrowserType == "CHROME"
                   || BrowserType == "FIREFOX"
                   || BrowserType == "IE"
                   )
                    break;
                else
                    PrintMessage(string.Format("{0} is not a valid option, please re-enter a correct value", BrowserType));
            }
            return BrowserType;
        }
        public static void PrintMessage(string Message)
        {
            Console.WriteLine(Message);
            Console.WriteLine("");
            Thread.Sleep(1000);
        }

        public static string WorkingDirectory()
        {
            string WDir = null;
            string User = Environment.UserName.ToLower();
            switch (User)
            {
                case "yogesh":
                    WDir = @"C:\Users\Yogesh.ATIV7-2\Desktop\DextapAutomation\SeleniumDemo\bin\Debug\";
                    break;

                case "victor":
                    WDir = @"C:\Users\Victor\workstride-automated-tests\DextapAutomation\SeleniumDemo\bin\Debug\";
                    break;

                case "pablorojas":
                    WDir = @"C:\Users\Pablo\Documents\workstride-automated-tests\DextapAutomation\SeleniumDemo\bin\Debug\";
                    break;
            }

            return WDir;
        }

        public static string SetClient()
        {
            string Client;
            string Confirmation;
            PrintMessage("Please set what client you would like to run the tests for: ");
            while (true)
            {
                Client = Console.ReadLine().Trim();
                PrintMessage(string.Format("Is this the correct client Name: {0}, type < Y or N >", Client));
                Confirmation = Console.ReadLine().ToLower().Trim();
                if (Confirmation != "y" && Confirmation != "n")
                {
                    PrintMessage("That was not a valid repsonse, please follow the prompts correctly !");
                }
                else
                {
                    if (Client.Length > 2 && Confirmation == "y")
                        return Client;
                    else
                        PrintMessage("Please enter a correct client name");
                }
            }
        }

        public static void SetConfigValues(string client, string browser)
        {
            string Path = WorkingDirectory() + @"Resources\Config.xml";
            XElement Doc = XElement.Load(Path);
            Doc.Element("BROWSER").Value = browser;
            Doc.Element("CLIENT").Value = client;
            Doc.Save(Path);
            PrintMessage("Setting Config Arguments...");

        }

        public static bool ConfirmAndExecute(string client, string browser, string Url)
        {
            Console.WriteLine("Please Confirm the following information: ");
            Console.WriteLine("1) Client to run : {0}", client);
            Console.WriteLine("2) Browser to use : {0}", browser);
            Console.WriteLine("3) Batchfile to run : {0}", client + ".bat");
            Console.WriteLine("4) Url to Use : {0}", Url);
            Console.WriteLine("");
            while (true)
            {
                PrintMessage("Is the above information correct? Please type <Y or N>! ");
                string response = Console.ReadLine().ToLower();
                if (response != "y" && response != "n")
                {
                    PrintMessage("That was not a valid repsonse, please follow the prompts correctly !");
                }
                else
                {
                    if (response == "y")
                        return true;
                    else
                        return false;
                }

            }
        }

        public static void CheckDirectoryAndDelete(string client)
        {
            PrintMessage("Deleting the old result files from the directory");
            string Filepath = WorkingDirectory() + @"Test_Results";

            DirectoryInfo di = new DirectoryInfo(Filepath);
            foreach (FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().Contains("xml") || File.Extension.ToLower().Contains("html"))

                    File.Delete();
            }

        }
        public static void SendEmailWithRecipients()
        {

            int HowManyUsers;
            List<string> Users = new List<string>();
            while (true)
            {
                Util.PrintMessage("Please enter how many users you want to add to the email");
                HowManyUsers = Convert.ToInt16(Console.ReadLine().Trim());
                Util.PrintMessage("Please Write the First initial and the Last Name of the users you want to email then press ENTER !!");
                while (Users.Count < HowManyUsers)
                {
                    string UserToAdd = Console.ReadLine().ToLower().Trim();
                    if (UserToAdd.Contains("@") || UserToAdd.Contains(".com"))
                    {
                        PrintMessage("Please do not add the @ Symbol or .com that is added to the string later");
                        PrintMessage("Please start from scratch and enter the users you want to email using First Initial and Last Name");
                        Users.Clear();
                    }
                    else
                    {
                        if (UserToAdd.Contains("projas"))
                             Users.Add(UserToAdd + "@devspark.com");
                        else
                             Users.Add(UserToAdd + "@workstride.com");
                    }
                }

                StringBuilder builder = new StringBuilder();
                foreach (string User in Users)
                {
                    builder.Append(User).Append("|");
                }

                string result = builder.ToString();
                PrintMessage(string.Format("Are the following Email Addresses Correct : {0}?, If so type <Y or N>", result));
                string response = Console.ReadLine().ToLower();
                if (response != "y" && response != "n")
                {
                    PrintMessage("That was not a valid repsonse, please follow the prompts correctly !");
                }
                else
                {
                    if (response == "y")
                        break;
                    else
                    {
                        PrintMessage("The prompts will restart, enter them correctly please");
                        Users.Clear();
                    }
                }
            }
            PrintMessage("Sending Email.....");
            SendEmail(Users);
        }

        public static string CheckAndSetUrl(string client)
        {
            string Url = null;
            string CurrentUrl = null;
            string Path = WorkingDirectory() + @"Resources\Url.xml";
            XElement Doc = XElement.Load(Path);
            while (true)
            {
                if (client.ToLower().Contains("all"))
                {
                    Url = "All url's will be used from the URL.xml file in the resources folder";
                    Util.PrintMessage("Please make sure all URL's are set correctly in the config file");
                    return Url;
                }
                else
                {
                    CurrentUrl = Doc.Element(client).Value;
                    Console.WriteLine("Is this the correct URL to run the tests on : {0} ? Enter <Y or N> ", CurrentUrl);
                    string response = Console.ReadLine().ToLower();
                    if (response != "y" && response != "n")
                    {
                        PrintMessage("That was not a valid repsonse, please follow the prompts correctly !");
                    }
                    else
                    {
                        if (response == "y")
                        {
                            Console.WriteLine("The tests will run on : {0}", CurrentUrl);
                            return CurrentUrl;
                        }
                        else
                        {
                            Console.WriteLine("Please enter the url you would like to run the tests on !");
                            Url = Console.ReadLine().ToLower();
                            Doc.Element(client).Value = Url;
                            Doc.Save(Path);
                            Console.WriteLine("Setting Url In File ...");
                            return Url;
                        }
                    }
                }
            }
        }

        public static void WaitForResults(string Client)
        {
            int ClientNumber;
            if (Client.ToLower().Contains("all"))
                ClientNumber = ClientCount();
            else
                ClientNumber = 1;
            int TimeCounter = 0;
            while (true)
            {
                DirectoryInfo info = new DirectoryInfo(WorkingDirectory() + @"Test_Results");
                var Files = info.GetFiles("*.html");
                if (Files.Length == ClientNumber)
                    break;
                if (TimeCounter == 12)
                {
                    PrintMessage("After waiting 12 seconds all the results have not been created, please look into it.");
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    TimeCounter = TimeCounter + 1;
                }

            }

        }
        public static void ExecuteTestReporter(string client)
        {
            while (true)
            {
                PrintMessage("Would you like to create the test result files ? <Y or N>");
                string response = Console.ReadLine().ToLower();
                if (response != "y" && response != "n")
                {
                    PrintMessage("That was not a valid repsonse, please follow the prompts correctly !");
                }
                else
                {
                    if (response == "y")
                    {
                        string ResultBatchFile = string.Format(@"TestResultsBatchFiles\{0}Results.bat", client);
                        Util.PrintMessage("Executing Test Reporter...");
                        Util.ExecuteProcess(ResultBatchFile);
                        break;
                    }

                    else
                    {
                        PrintMessage("Are you sure you dont want to create the test result files <Y or N>?");
                        string SecondAttempt = Console.ReadLine().ToLower();
                        if (SecondAttempt == "y")
                        {
                            PrintMessage("Exiting Program, have a nice day");
                            Environment.Exit(0);
                        }
                        else
                            PrintMessage("You will be prompted to enter Y or N again.");
                    }
                }
            }
            PrintMessage("Waiting for Test Results...");
            WaitForResults(client);
        }
        public static int ClientCount()
        {
            DirectoryInfo Info = new DirectoryInfo(WorkingDirectory() + @"TestBatchFiles");
            int Count = (Info.GetFiles().Length) - 1;
            return Count;
        }

        public static void ExecuteProcess(string Filename)
        {
            //// Use ProcessStartInfo class

            ProcessStartInfo startInfo = new ProcessStartInfo();
            if (Filename.ToLower().Trim().Contains("results"))
                startInfo.WorkingDirectory = WorkingDirectory() + @"Test_Results\";
            else
                startInfo.WorkingDirectory = WorkingDirectory();
            startInfo.CreateNoWindow = false;
            startInfo.FileName = Filename;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = "C-Sharp Console application";

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    @"Something went wrong when trying to run the tests, 
                    here is the exception: {0} ", e.ToString());
            }
        }

        public static void SendEmail(List<string> Recipients)
        {
            string Sender;
            string Password;

            using (StreamReader Reader = new StreamReader(WorkingDirectory() + @"EmailCreds.txt"))
            {
                Sender = Reader.ReadLine().Trim();
                Password = Reader.ReadLine().Trim();
            }

            MailMessage message = new MailMessage(Sender, Recipients[0]);
            message.Subject = "Test Results";
            message.Body = "Attached are results from todays test run";
            SmtpClient client = new SmtpClient("mail.giveanything.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(Sender, Password);

            //Attaches the relevant result files
            string Filepath = WorkingDirectory() + @"Test_Results\";
            DirectoryInfo di = new DirectoryInfo(Filepath);
            foreach (FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().Contains("html"))
                {
                    message.Attachments.Add(new Attachment(File.FullName));
                }
            }

            //Add Recipients to Email
            for (int i = 1; i < Recipients.Count; i++)
            {
                message.To.Add(Recipients[i]);
            }

            //Sends the email and disposes the message and client objects
            try
            {
                client.Send(message);
                PrintMessage("Email was successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong when trying to send the email, here is the exception: {0}",
                            ex.ToString());
            }
            finally
            {
                client.Dispose();
                message.Dispose();
            }

        }

        public static void KillLeftOverProcesses()
        {

            PrintMessage("Results files have been created for all clients, cleaning up left over windows and processes.");

            Process[] RunningProcesses = Process.GetProcesses();
            foreach (Process p in RunningProcesses)
            {
                if (p.MainWindowTitle.ToLower().Contains("nunit") || p.ProcessName.Contains("nunit"))
                {
                    p.Kill();
                }
            }

            PrintMessage("Press any key to exit. Have a Nice Day!");
        }
    }
}
