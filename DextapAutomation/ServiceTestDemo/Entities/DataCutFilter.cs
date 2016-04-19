using System;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class DataCutFilter
    {
        public int ID { get; set; }

        public ExtractionJob ExtractionJobID { get; set; }

        public string Name { get; set; }

        public string Filter { get; set; }

        public DateTime? LastRunDateTime { get; set; }

        public string Status { get; set; }

        public string Results { get; set; }

    }
}
