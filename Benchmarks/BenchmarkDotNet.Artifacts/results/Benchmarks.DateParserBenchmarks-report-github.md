```

BenchmarkDotNet v0.13.7, Windows 11 (10.0.22000.2360/21H2/SunValley) (Hyper-V)
Intel Xeon CPU E5-2687W v4 3.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|               Method |      Mean |    Error |   StdDev | Rank |   Gen0 | Allocated |
|--------------------- |----------:|---------:|---------:|-----:|-------:|----------:|
|     GetYearFromSplit |  97.33 ns | 0.557 ns | 0.494 ns |    1 | 0.0101 |     160 B |
| GetYearFromSubstring | 100.84 ns | 1.705 ns | 1.512 ns |    2 | 0.0101 |     160 B |
|      GetYearFromSpan | 101.67 ns | 2.037 ns | 1.806 ns |    2 | 0.0101 |     160 B |
|  GetYearFromDateTime | 395.39 ns | 2.109 ns | 1.761 ns |    3 |      - |         - |
