using System;
using System.IO;
using System.Xml.Serialization;

namespace ServiceTestingFramework
{
    public abstract partial class AbstractServiceTest
    {
        protected string ToXML<T>(T obj)
        {
            XmlSerializer marshaller = new XmlSerializer(obj.GetType());
            StringWriter sw = new StringWriter();
            marshaller.Serialize(sw, obj);
            Console.WriteLine(sw.ToString());
            return sw.ToString();
        }
    }
}
