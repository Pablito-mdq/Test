using System.Collections.Generic;
using System.Xml.Serialization;

namespace SeleniumDemo.Models
{
    public class TestExecutionModel
    {
      [XmlRoot("TestList")]
      public class TestList
      {
        [XmlElement("Test")]
        public List<Test> Testcases { get; set; }
      }

        public class Test
        {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Execution")]
        public string Execution { get; set; }
    }

    }
}
