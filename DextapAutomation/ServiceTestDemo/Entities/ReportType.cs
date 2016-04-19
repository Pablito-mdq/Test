using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class ReportType
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TemplateFileName { get; set; }

        public string RequiredMDMVariables { get; set; }

        public string DefaultOnNextCaseEventSection { get; set; }

        public bool Active { get; set; }

    }
}
