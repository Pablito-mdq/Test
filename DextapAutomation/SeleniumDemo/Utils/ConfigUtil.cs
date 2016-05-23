using System.Xml.Linq;
using WebDriverFramework;

namespace SeleniumDemo.Utils
{
    class ConfigUtil
    {
        public static BrowserType BROWSER;
        public static string info;
        public static XElement DATA;
        public static string values;

        public static BrowserType ImportConfig(string configFile)
        {
            XElement xelement = XElement.Load(configFile);
            info = xelement.Element("BROWSER").Value;
            switch (info)
            {
                    case "CHROME" :
                    BROWSER = BrowserType.Chrome;
                    return BROWSER;
                    break;
                    case "FIREFOX" :
                    BROWSER = BrowserType.Firefox;
                    return BROWSER;
                    break;
                    case "IE" :
                    BROWSER = BrowserType.IE;
                    return BROWSER;
                    break;
            }
            return BROWSER;
        }

        public static string ImportConfigUsername(string configFile)
        {
            XElement xelement = XElement.Load(configFile);
            info = xelement.Element("USERNAME").Value;
            return info;
        }

        public static string ImportConfigPassword(string configFile)
        {
            XElement xelement = XElement.Load(configFile);
            info = xelement.Element("PASSWORD").Value;
            return info;
        }

        public static string ImportConfigURL(string configFile,string client)
        {
            XElement xelement = XElement.Load(configFile);
            info = xelement.Element(string.Format("{0}",client)).Value;
            return info;
        }

        public static string ImportClient(string configFile)
        {
            XElement xelement = XElement.Load(configFile);
            var info = xelement.Element("CLIENT").Value;
            return info;
        }
    }
}
