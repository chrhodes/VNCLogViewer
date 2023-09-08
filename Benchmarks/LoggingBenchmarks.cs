using System;

using BenchmarkDotNet.Attributes;

using VNC;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LoggingBenchmarks
    {
        private const string logMessage = "9/1/2023 7:44:43 PM|VNCLogViewer|100|Verbose|D:\\VNCLogViewer.exe|30988||31536|crhodes|App.Application_Startup||Enter";
        private static readonly GetNth Finder = new GetNth();

        [Benchmark]
        public void LogPlaceholders()
        {
            DateTime now = DateTime.Now;
            Int32 count = 10;
            string message = "Hello Garbage collector";

            for (int i = 0; i < count; i++)
            {
                Log.Info(string.Format("DateTime{0} i:({1}) message:({2})", now, i, message), Program.LOG_CATEGORY);
            }
            
        }

        [Benchmark]
        public void LogInterpolated()
        {
            DateTime now = DateTime.Now;
            Int32 count = 10;
            string message = "Hello Garbage collector";

            for (int i = 0; i < count; i++)
            {
                Log.Info($"DateTime{now} i:({i}) message:({message})", Program.LOG_CATEGORY);
            }
        }

    }
}