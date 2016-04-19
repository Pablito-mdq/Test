using NUnit.Framework;
using ServiceTestingFramework;
using System;
using ServiceTestingFramework.Dextap.Utilities;
using Testing.Entities;
using System.Net;

namespace ServiceTestDemo
{
    [TestFixture]
    public abstract class DextapBaseServiceTest : AbstractServiceTest
    {
        protected override string GetTargetAddress()
        {
            return Config.DEXTAP_URL;
        }

        protected void SubmitJob(ExtractionJob job, int times = 1)
        {
            string Payload = ToXML<ExtractionJob>(job);
            Console.WriteLine(Payload);
            AddHeader("Content-Type", "text/xml");
            for (int time = 0; time < times; time++)
            {
                Object response = DoPostRequest(Config.DEXTAP_UPLOAD_JOB_API, Payload);
                Console.WriteLine(response);
            }
        }
    }
}
