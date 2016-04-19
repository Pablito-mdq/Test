using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class Region
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public string OutputLocation { get; set; }

        public bool DefaultType { get; set; }

    }
}
