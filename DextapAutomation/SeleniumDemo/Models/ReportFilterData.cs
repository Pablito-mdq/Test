using System.Xml.Linq;
using NUnit.Framework;

namespace SeleniumDemo.Models
{
    class ReportFilterData
    {
        private static string values;

        public static string GetRegisterField(string configFile, string value)
        {

            XElement xelement = XElement.Load(configFile);
            var xElement = xelement.Element(string.Format("{0}", value));
            if (xElement != null)
                values = xElement.Value;
            else
                Assert.Fail("The information for field " + value + " is not present in the file" + configFile);
            return values;
        }

        public static string GetStartDate(string configFile)
        {
            return GetRegisterField(configFile, "StartDate");
        }

        public static string GetFinishDate(string configFile)
        {
            return GetRegisterField(configFile, "FinishDate");
        }
    }
}
