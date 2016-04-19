using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class DBServer
    {
        public int ID { get; set; }

        public ServerType ServerType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string MDDCopyLocation { get; set; }

        public bool Dmri { get; set; }

        public ExtractionType ExtractionType { get; set; }

        public string Dpm { get; set; }

        public bool IsLegacy { get; set; }

        public bool CheckDpm { get; set; }

        public bool Active { get; set; }

        public bool ValidateDMRI { get; set; }


    }
}
