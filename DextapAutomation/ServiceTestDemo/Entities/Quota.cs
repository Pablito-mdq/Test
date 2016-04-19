using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class Quota
    {
        public int ID { get; set; }

        public ExtractionJob ExtractionJobID { get; set; }

        public int QuotaLimit { get; set; }

    }
}
