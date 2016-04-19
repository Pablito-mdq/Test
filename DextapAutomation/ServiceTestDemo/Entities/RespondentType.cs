using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class RespondentType
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public bool DefaultType { get; set; }
    }
}
