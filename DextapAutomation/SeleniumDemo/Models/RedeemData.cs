using System.Xml.Linq;
using NUnit.Framework;

namespace SeleniumDemo.Models
{
    class RedeemData
    {
        private static string values;
        private static string Name;
        private static string AwardName;
        private static string Value;
        private static string AwardValue;
        private static string Message;
        private static string Reason;
        private static string SendType;

        public static string GetAward(string configFile, string value)
        {
             
            XElement xelement = XElement.Load(configFile);
            var xElement = xelement.Element(string.Format("{0}", value));
            if (xElement != null)
                values = xElement.Value;
            else
                Assert.Fail("The field " + value + " is not present in the file" + configFile);
            return values;
        }

        public static string GetRedeemCompany(string configFile)
        {
            return GetAward(configFile,"Company");
        }

        public static string GetRedeemFirstName(string configFile)
        {
            return GetAward(configFile, "FirstName");
        }

        public static string GetRedeemSecondName(string configFile)
        {
            return GetAward(configFile, "LastName");
        }

        public static string GetRedeemAddress(string configFile)
        {
            return GetAward(configFile, "Address");
        }

        public static string GetRedeemCity(string configFile)
        {
            return GetAward(configFile, "City");
        }

        public static string GetRedeemState(string configFile)
        {
            return GetAward(configFile, "State");
        }
        public static string GetRedeemZip(string configFile)
        {
            return GetAward(configFile, "zip");
        }

        public static string GetRedeemCountry(string configFile)
        {
            return GetAward(configFile, "Country");
        }

        public static string GetRedeemPhone(string configFile)
        {
            return GetAward(configFile, "phone");
        }

        public static string GetRedeemCreditCardNumber(string configFile)
        {
            return GetAward(configFile, "CreditCardNumber");
        }

        public static string GetRedeemCreditCardName(string configFile)
        {
            return GetAward(configFile, "CreditCardName");
        }

        public static string GetRedeemCreditCardExpireYear(string configFile)
        {
            return GetAward(configFile, "CreditCardExpireYear");
        }

        public static string GetRedeemCreditCardCDI(string configFile)
        {
            return GetAward(configFile, "CreditCardCDI");
        }

        public static string GetRedeemCreditCardExpireMonth(string configFile)
        {
            return GetAward(configFile, "CreditCardExpireMonth");
        }
    }
}
