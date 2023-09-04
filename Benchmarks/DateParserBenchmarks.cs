using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using Microsoft.Diagnostics.Tracing.Extensions;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchmarks
    {
        private const string DateTime = "1956-11-22T20:20:00Z";
        private static readonly DateParser Parser = new DateParser();

        [Benchmark]
        public void GetYearFromDateTime()
        {
            Parser.GetYearFromDateTime(DateTime);
        }

    }
}
