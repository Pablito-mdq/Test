using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeleniumDemo.Models
{
    class GeneralData
    {
        private static string values;
        private static string username;

        public static string GetData(string configFile, string value)
        {

            XElement xelement = XElement.Load(configFile);
            var xElement = xelement.Element(string.Format("{0}", value));
            if (xElement != null)
                values = xElement.Value;
            else
                Assert.Fail("The field" + value + "is not present in the file" + configFile);
            return values;
        }

        public static string GetUrl(string configFile)
        {
            return GetData(configFile, "Url");
        }
    }
}

