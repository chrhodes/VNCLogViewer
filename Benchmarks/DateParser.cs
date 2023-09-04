using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarks
{
    // ISO Date
    // 2019-12-13T16:33:06Z

    public class DateParser
    {
        public int GetYearFromDateTime(string dateTimeAsString)
        {
            var dateTime = DateTime.Parse(dateTimeAsString);
            return dateTime.Year;
        }

        public int GetYearFromSplit(string dateTimeAsString)
        {
            var splitOnHyphen = dateTimeAsString.Split('-');
            return int.Parse(splitOnHyphen[0]);
        }

        public int GetYearFromSubstring(string dateTimeAsString)
        {
            var indexofHyphen = dateTimeAsString.IndexOf('-');
            return int.Parse(dateTimeAsString.Substring(0,indexofHyphen));
        }

        public int GetYearFromSpan(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var indexofHyphen = dateTimeAsSpan.IndexOf('-');
            return int.Parse(dateTimeAsSpan.Slice(0, indexofHyphen));
        }

        public int GetYearFromSpanWithManualConversion(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var indexofHyphen = dateTimeAsSpan.IndexOf('-');
            var yearAsASpan = dateTimeAsSpan.Slice(0,indexofHyphen);
            
            var year = 0;

            for (int i = 0; i < yearAsASpan.Length; i++)
            {
                year = year * 10 + (yearAsASpan[i] - '0');
            }

            return year;
        }
    }
}