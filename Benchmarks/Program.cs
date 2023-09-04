// See https://aka.ms/new-console-template for more information
using System;

using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //BenchmarkRunner.Run<DateParserBenchmarks>();
            BenchmarkRunner.Run<GetNthBenchmarks>();
        }
    }
}

