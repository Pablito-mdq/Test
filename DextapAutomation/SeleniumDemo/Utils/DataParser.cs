using System.Xml.Linq;
using System.Xml.XPath;

namespace SeleniumDemo.Utils
{
    /// <summary>
    /// reads an XML file containing test data organized by tests
    /// </summary>

    public class DataParser
    {
        private static string client = ConfigUtil.ImportClient("Resources\\Config.xml");

        public static XElement DeserializeObject(string filename)
        {
            // Use the Deserialize method to restore the object's state.
            XElement tests = XElement.Load(filename);
            return tests;
        }

        public static bool ReturnExecution(string name)
        {

            XElement list = DeserializeObject("Resources\\" + client + "\\TestsExecution\\" + client + ".xml");
            XElement result = list.XPathSelectElement(string.Format("//Test[@Name='{0}']",name));
            if (result == null)
                return false;
            if (result.Attribute("Execution").Value == "Yes")
                return true;
            return false;

        }
    }
}