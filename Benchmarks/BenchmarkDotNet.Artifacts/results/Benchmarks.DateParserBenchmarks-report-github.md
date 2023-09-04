```

BenchmarkDotNet v0.13.7, Windows 11 (10.0.22000.2360/21H2/SunValley) (Hyper-V)
Intel Xeon CPU E5-2687W v4 3.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|               Method |      Mean |    Error |   StdDev | Rank |   Gen0 | Allocated |
|--------------------- |----------:|---------:|---------:|-----:|-------:|----------:|
| GetYearFromSubstring |  90.69 ns | 1.003 ns | 0.837 ns |    1 | 0.0101 |     160 B |
|      GetYearFromSpan |  92.78 ns | 1.176 ns | 1.100 ns |    2 | 0.0101 |     160 B |
|     GetYearFromSplit |  94.33 ns | 1.413 ns | 1.252 ns |    2 | 0.0101 |     160 B |
|  GetYearFromDateTime | 396.48 ns | 7.433 ns | 6.589 ns |    3 |      - |         - |
