using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class Email
    {
        public int ID { get; set; }

        public ExtractionJob ExtractionJobID { get; set; }

        public string Address { get; set; }

    }
}
