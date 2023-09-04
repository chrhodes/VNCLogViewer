using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class GetNthBenchmarks
    {
        private const string logMessage = "9/1/2023 7:44:43 PM|VNCLogViewer|100|Verbose|D:\\VNCLogViewer.exe|30988||31536|crhodes|App.Application_Startup||Enter";
        private static readonly GetNth Finder = new GetNth();

        [Benchmark]
        public void GetNthIndex()
        {
            Finder.GetNthIndex(logMessage, '|', 4);
        }

        [Benchmark]
        public void GetNthIndex2()
        {
            Finder.GetNthIndex2(logMessage, '|', 4);
        }

        [Benchmark]
        public void GetNthIndex3()
        {
            Finder.GetNthIndex3(logMessage, '|', 4);
        }
    }
}