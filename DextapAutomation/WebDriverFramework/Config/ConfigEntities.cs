using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebDriverFramework.WebDriver
{
    public class Waiting
    {
        public int implicitly { get; set; }
        public int pageload { get; set; }
    }

    public class Capability
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("value")]
        public string value { get; set; }
    }

    public class Argument
    {
        [XmlAttribute("value")]
        public string value { get; set; }
    }

    public class Driver
    {
        public string name { get; set; }
        public string url { get; set; }

        [XmlArray(ElementName = "capabilities")]
        [XmlArrayItem(ElementName = "capability")]
        public List<Capability> capabilities { get; set; }

        [XmlArray(ElementName = "arguments")]
        [XmlArrayItem(ElementName = "argument")]
        public List<Argument> arguments { get; set; }

        public Driver()
        {
            this.arguments = new List<Argument>();
            this.capabilities = new List<Capability>();
        }
    }


    public class FrameworkConfig
    {
        public Waiting waiting = new Waiting();

        [XmlArray(ElementName = "drivers")]
        [XmlArrayItem(ElementName = "driver")]
        public List<Driver> drivers { get; set; }

        public FrameworkConfig()
        {
            this.drivers = new List<Driver>();
        }
    }
}
