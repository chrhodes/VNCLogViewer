// See https://aka.ms/new-console-template for more information
using System;

using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        public const string LOG_CATEGORY = "BENCHMARKS";
        private const string logMessage = "9/1/2023 7:44:43 PM|VNCLogViewer|100|Verbose|D:\\VNCLogViewer.exe|30988||31536|crhodes|App.Application_Startup||Enter";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Benchmarks!");

            //BenchmarkRunner.Run<DateParserBenchmarks>();
            //BenchmarkRunner.Run<GetNthBenchmarks>();
            BenchmarkRunner.Run<LoggingBenchmarks>();

            //GetNth Finder = new GetNth();

            //Finder.GetNthIndex2(logMessage, '|', 4);
            //Finder.GetNthIndex3(logMessage, '|', 4);
            //Finder.GetNthIndex4(logMessage, '|', 4);

        }
    }
}

