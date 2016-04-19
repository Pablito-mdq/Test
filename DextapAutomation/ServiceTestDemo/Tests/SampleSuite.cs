using Meyn.TestLink;
using NUnit.Framework;
using ServiceTestDemo;
using ServiceTestingFramework.NUnit.SQL;
using Testing.Entities;

namespace ServiceTestingFramework.TestCase
{
    [TestLinkFixture(
        Url = "http://10.236.116.51:8030/testlink/lib/api/xmlrpc.php",
        ProjectName = "Dextap",
        UserId = "tester",
        TestPlan = "Automatic Testing",
        TestSuite = "SampleSuite",
        DevKey = "ae28ffa45712a041fa0b31dfacb75e29")]
    public class SampleSuite : DextapBaseServiceTest
    {
        [Test]
        [DataBase("XYZ", 1)]
        public void SampleTest()
        {
            ExtractionJob job = new ExtractionJob();
            job.Password = "wGWwVUq42MYioNozvII9IA=="; // Encryption.EncryptToBase64String("abc123");
            job.Owner = "hartmanm";
            SubmitJob(job, 1);
        }
    }
}
