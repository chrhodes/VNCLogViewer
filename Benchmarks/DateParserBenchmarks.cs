using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchmarks
    {
        private const string DateTimeString = "1956-11-22T20:20:00Z";
        private static readonly DateParser Parser = new DateParser();

        [Benchmark]
        public void GetYearFromDateTime()
        {
            Parser.GetYearFromDateTime(DateTimeString);
        }

        [Benchmark]
        public void GetYearFromSplit()
        {
            Parser.GetYearFromSplit(DateTimeString);
        }

        [Benchmark]
        public void GetYearFromSubstring()
        {
            Parser.GetYearFromSplit(DateTimeString);
            //Parser.GetYearFromSubstring(DateTimeString);
        }

        [Benchmark]
        public void GetYearFromSpan()
        {
            Parser.GetYearFromSplit(DateTimeString);
            //Parser.GetYearFromSpan(DateTimeString);
        }

    }
}
