```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method               | nodeId | parentId | Mean       | Error    | StdDev    | Median     | Gen0   | Allocated |
|--------------------- |------- |--------- |-----------:|---------:|----------:|-----------:|-------:|----------:|
| **HasAccess**            | **1948**   | **1**        | **1,023.9 μs** | **35.24 μs** | **100.55 μs** |   **979.5 μs** |      **-** |  **10.85 KB** |
| HasAccessSearchQuery | 1948   | 1        | 2,865.2 μs | 96.55 μs | 284.68 μs | 2,811.9 μs |      - |  17.23 KB |
| **HasAccess**            | **2**      | **1**        |   **895.5 μs** | **11.12 μs** |   **8.68 μs** |   **892.8 μs** | **1.9531** |   **8.98 KB** |
| HasAccessSearchQuery | 2      | 1        | 2,559.2 μs | 48.09 μs |  40.16 μs | 2,561.2 μs | 3.9063 |  17.22 KB |
