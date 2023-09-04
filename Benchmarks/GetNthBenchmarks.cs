using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class GetNthBenchmarks
    {
        //9/1/2023 7:44:43 PM|VNCLogViewer|100|Verbose|D:\VNCLogViewer.exe|30988||31536|crhodes|App.Application_Startup||Enter

        [MemoryDiagnoser]
        [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
        [RankColumn]
        public class DateParserBenchmarks
        {
            private const string logMessage = "9/1/2023 7:44:43 PM|VNCLogViewer|100|Verbose|D:\\VNCLogViewer.exe|30988||31536|crhodes|App.Application_Startup||Enter";
            private static readonly GetNth Finder = new GetNth();

            [Benchmark]
            public void GetNthIndex()
            {
                Finder.GetNthIndex(logMessage, '|', 4);
            }

        }
    }
}