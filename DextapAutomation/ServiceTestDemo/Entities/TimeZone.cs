using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Entities;

namespace Dextap.Testing.Entities
{
    public class Timezone
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Offset { get; set; }

        public bool IsDefault { get; set; }

        public bool DaylightSavings { get; set; }

        public int Adjustment { get; set; }

        public bool IsDaylightSavings(Date date)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Name);
            return timeZoneInfo.IsDaylightSavingTime(date.Now.Value);
        }

        public bool SupportsDaylightSavings(Date date)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Name);
            return timeZoneInfo.SupportsDaylightSavingTime;
        }

        public int GetDaylightSavingsAdjustment(Date date)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Name);
            var baseOffset = timeZoneInfo.BaseUtcOffset;
            var currentOffset = timeZoneInfo.GetUtcOffset(date.Now.Value);

            return (baseOffset.Hours - currentOffset.Hours);
        }

        public int GetStandardTimeAdjustment(Date date)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Name);
            var baseOffset = timeZoneInfo.BaseUtcOffset;
            var currentOffset = timeZoneInfo.GetUtcOffset(date.Now.Value);

            return (currentOffset.Hours - baseOffset.Hours);
        }

    }
}
