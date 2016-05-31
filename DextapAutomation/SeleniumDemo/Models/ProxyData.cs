using System.Xml.Linq;

namespace SeleniumDemo.Models
{
    class ProxyData
    {
        private static string values;
        private static string username;

        public static string GetProxy(string configFile, string value)
        {

            XElement xelement = XElement.Load(configFile);
            var xElement = xelement.Element(string.Format("{0}", value));
            if (xElement != null)
                values = xElement.Value;
            return values;
        }

        public static string GetProxyUserName(string configFile)
        {
            return GetProxy(configFile, "ProxyName");
        }

    }
}
