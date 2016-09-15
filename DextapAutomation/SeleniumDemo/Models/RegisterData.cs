using System.Xml.Linq;
using MbUnit.Framework;

namespace SeleniumDemo.Models
{
    class RegisterData
    {
        private static string values;
        private static string FirstName;
        private static string LastName;
        private static string ID;
        private static string Email;

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

        public static string GetRegisterFirstName(string configFile)
        {
            return GetRegisterField(configFile, "FirstName");
        }

        public static string GetRegisterLastName(string configFile)
        {
            return GetRegisterField(configFile, "LastName");
        }

        public static string GetRegisterID(string configFile)
        {
            return GetRegisterField(configFile, "ID");
        }

        public static string GetRegisterEmail(string configFile)
        {
            return GetRegisterField(configFile, "Email");
        }

        public static string GetRegisterPreferedName(string configFile)
        {
            return GetRegisterField(configFile, "PreferedName");
        }

        public static string GetInquiryType(string configFile)
        {
            return GetRegisterField(configFile, "InquiryType");
        }

        public static string GetInquiry(string configFile)
        {
            return GetRegisterField(configFile, "Inquiry");
        }
    }
}
