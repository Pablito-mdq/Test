
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    
    public class Notification
    {
        public int ID { get; set; }

        public ExtractionJob ExtractionJobID { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public string ExtraData { get; set; }

        public bool PostProcess { get; set; }

    }
}
