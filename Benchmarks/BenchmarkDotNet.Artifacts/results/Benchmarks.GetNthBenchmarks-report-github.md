```

BenchmarkDotNet v0.13.7, Windows 11 (10.0.22000.2360/21H2/SunValley) (Hyper-V)
Intel Xeon CPU E5-2687W v4 3.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|       Method |     Mean |    Error |   StdDev | Rank | Allocated |
|------------- |---------:|---------:|---------:|-----:|----------:|
| GetNthIndex3 | 24.17 ns | 0.115 ns | 0.096 ns |    1 |         - |
| GetNthIndex4 | 27.49 ns | 0.381 ns | 0.357 ns |    2 |         - |
| GetNthIndex2 | 29.87 ns | 0.172 ns | 0.153 ns |    3 |         - |
|  GetNthIndex | 33.62 ns | 0.199 ns | 0.186 ns |    4 |         - |
