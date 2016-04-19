using log4net;
using log4net.Config;
using System.IO;

namespace ServiceTestingFramework
{
    public abstract partial class AbstractServiceTest
    {
        protected ILog LOG;
      
        public AbstractServiceTest()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.xml"));
            this.LOG = LogManager.GetLogger(this.GetType());
            client.BaseAddress = GetTargetAddress();
        }
    }

}
