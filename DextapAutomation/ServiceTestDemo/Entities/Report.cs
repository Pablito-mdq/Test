using System;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class Report
    {
        public int ID { get; set; }

        public ExtractionJob ExtractionJobID { get; set; }

        public ReportType ReportTypeID { get; set; }

        public DateTime? LastRunDateTime { get; set; }

        public string Status { get; set; }

        public string Results { get; set; }

        public string OnNextCaseEventSection { get; set; }

    }
}
