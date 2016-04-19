using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class FrequencyType
    {
        public const string THREE_TIMES_A_DAY = "Three Times A Day";
        public const string DAILY = "Daily";
        public const string WEEKLY = "Weekly";
        public const string INACTIVE = "Inactive";
        public const string QUOTA_LIMIT = "Quota Limit";
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Scheduleable { get; set; }

        public bool IsDefault { get; set; }

    }
}
