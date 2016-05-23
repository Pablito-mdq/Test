using System;
using System.Text.RegularExpressions;

namespace SeleniumDemo.Utils
{
    class DateUtils
    {
        //return "today's system's date unformatted(culture sensitive)";
        public static DateTime GetCurrentDate()
        {
            return DateTime.Today;
        }

        public static string GetDateDueToday()
        {
            //Console.WriteLine("Get due today date: " + GetCurrentDate().ToShortDateString());
            string format = "MM/dd/yy";

            return Regex.Replace(GetCurrentDate().ToString(format), "-", "/");
        }

        //return "current date minus 4 days";
        public static string GetDateOverdue()
        {
            //Console.WriteLine("Get overdue date: " + GetCurrentDate().AddDays(-4).ToShortDateString());
            string format = "MM/dd/yy";

            return Regex.Replace(GetCurrentDate().AddDays(-4).ToString(format), "-", "/");
        }

        //return "current date plus 4 days";
        public static string GetDateDue()
        {
            //Console.WriteLine("Get due date: " + GetCurrentDate().AddDays(4).ToShortDateString());
            string format = "MM/dd/yy";

            return Regex.Replace(GetCurrentDate().AddDays(4).ToString(format), "-", "/");
        }
    }
}
