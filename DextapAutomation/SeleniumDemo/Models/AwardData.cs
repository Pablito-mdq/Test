using System;
using System.Xml.Linq;

namespace SeleniumDemo.Models
{
    class AwardData
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
            return values;
        }

        public static string GetAwardUserName(string configFile)
        {
            return GetAward(configFile,"Name");
        }

        public static string GetAwardName(string configFile)
        {
            return GetAward(configFile, "AwardName");
        }

        public static string GetAwardValue(string configFile)
        {
            return GetAward(configFile, "Value");
        }

        public static string GetAwardAmountValue(string configFile)
        {
            return GetAward(configFile, "AmountValue");
        }

         public static int GetAwardAmountValueNumbers(string configFile)
        {
            return Int32.Parse(GetAward(configFile, "AmountValueInt"));
        }

        public static string GetAwardMessage(string configFile)
        {
            return GetAward(configFile, "Message");
        }
        public static string GetAwardReason(string configFile)
        {
            return GetAward(configFile, "Reason");
        }

        public static string GetAwardDeliverType(string configFile)
        {
            return GetAward(configFile, "SendType");
        }

        public static string GetAwardImpact(string configFile)
        {
            return GetAward(configFile, "Impact");
        }

        public static string GetApprovalUserName(string configFile)
        {
            return GetAward(configFile, "ApprovalName");
        }

        public static string GetAwardPopulationImpact(string configFile)
        {
            return GetAward(configFile, "PopulationImpact");
        }

        public static string GetAwardFinancialImpact(string configFile)
        {
            return GetAward(configFile, "FinancialImpact");
        }

        public static string GetAwardBussinesImpact(string configFile)
        {
            return GetAward(configFile, "BussinesImpact");
        }

        public static string GetSecondAwardName(string configFile)
        {
            return GetAward(configFile, "SecondAwardName");
        }

        public static string GetAwardProjectTask(string configFile)
        {
            return GetAward(configFile, "ProjectTask");
        }

        public static string GetAwardObjetives(string configFile)
        {
            return GetAward(configFile, "Objectives");
        }

        public static string GetAwardCompanyValue(string configFile)
        {
            return GetAward(configFile, "CompanyValue");
        }

        public static string GetAwardSubType1(string configFile)
        {
            return GetAward(configFile, "AwardSubType1");
        }

        public static string GetAwardSubType2(string configFile)
        {
            return GetAward(configFile, "AwardSubType2");
        }

        public static string GetAwardCCEmail(string configFile)
        {
            return GetAward(configFile, "CCEmail");
        }

        public static string GetAwardFutureDate(string configFile)
        {
            return GetAward(configFile, "FutureDate");
        }
    }
}
