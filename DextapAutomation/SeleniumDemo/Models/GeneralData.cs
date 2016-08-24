using System;
using System.Xml.Linq;
using NUnit.Framework;

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

        public static int GetDataInt(string configFile, string value)
        {

            XElement xelement = XElement.Load(configFile);
            var xElement = xelement.Element(string.Format("{0}", value));
            if (xElement != null)
                values = xElement.Value;
            else
                Assert.Fail("The field" + value + "is not present in the file" + configFile);
            return Int32.Parse(values);
        }

        public static string GetUrl(string configFile)
        {
            return GetData(configFile, "Url");
        }

        public static string path(string configFile)
        {
            return GetData(configFile, "path");
        }

        public static int width(string configFile)
        {
            return GetDataInt(configFile, "width");
        }

        public static int height(string configFile)
        {
            return GetDataInt(configFile, "height");
        }

        public static string path2(string configFile)
        {
            return GetData(configFile, "path2");
        }

        public static string GetPathCreditCard1Img(string configFile)
        {
            return GetData(configFile, "CreditCard1Url");
        }

        public static string GetPathCreditCard2Img(string configFile)
        {
            return GetData(configFile, "CreditCard2Url");
        }

        public static string GetPathFile(string configFile)
        {
            return GetData(configFile, "PathFile");
        }

        public static string GetFileName(string configFile)
        {
            return GetData(configFile, "FileName");
        }

        public static string GetPathWrongFile(string configFile)
        {
            return GetData(configFile, "PathWrongFile");
        }
    }
}

