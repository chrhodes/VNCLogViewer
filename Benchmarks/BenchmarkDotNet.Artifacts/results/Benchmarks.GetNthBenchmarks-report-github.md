```

BenchmarkDotNet v0.13.7, Windows 11 (10.0.22000.2360/21H2/SunValley) (Hyper-V)
Intel Xeon CPU E5-2687W v4 3.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|       Method |     Mean |    Error |   StdDev | Rank | Allocated |
|------------- |---------:|---------:|---------:|-----:|----------:|
| GetNthIndex4 | 24.21 ns | 0.515 ns | 0.687 ns |    1 |         - |
| GetNthIndex3 | 24.23 ns | 0.429 ns | 0.401 ns |    1 |         - |
| GetNthIndex2 | 29.99 ns | 0.625 ns | 0.669 ns |    2 |         - |
|  GetNthIndex | 32.17 ns | 0.239 ns | 0.212 ns |    3 |         - |
