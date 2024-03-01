```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
Intel Core i5-4670 CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method               | nodeId | parentId | Mean       | Error    | StdDev   | Median     | Gen0   | Allocated |
|--------------------- |------- |--------- |-----------:|---------:|---------:|-----------:|-------:|----------:|
| **HasAccess**            | **100**    | **1**        |   **907.0 μs** | **13.40 μs** | **11.19 μs** |   **903.6 μs** | **1.9531** |  **10.27 KB** |
| HasAccessSearchQuery | 100    | 1        | 2,539.2 μs | 50.12 μs | 61.56 μs | 2,532.4 μs | 3.9063 |  17.22 KB |
| **HasAccess**            | **100**    | **50**       |   **890.5 μs** | **16.93 μs** | **45.18 μs** |   **865.5 μs** | **1.9531** |  **10.27 KB** |
| HasAccessSearchQuery | 100    | 50       | 3,261.9 μs | 56.23 μs | 52.60 μs | 3,261.6 μs | 3.9063 |  17.22 KB |
| **HasAccess**            | **100**    | **99**       |   **875.7 μs** | **17.33 μs** | **28.96 μs** |   **861.0 μs** | **1.9531** |  **10.27 KB** |
| HasAccessSearchQuery | 100    | 99       | 3,173.1 μs | 44.28 μs | 39.26 μs | 3,170.6 μs | 3.9063 |  17.22 KB |
| **HasAccess**            | **2**      | **1**        |   **881.6 μs** | **17.62 μs** | **40.14 μs** |   **861.2 μs** | **1.9531** |   **9.02 KB** |
| HasAccessSearchQuery | 2      | 1        | 2,500.9 μs | 49.13 μs | 50.45 μs | 2,480.8 μs | 3.9063 |  17.22 KB |
| **HasAccess**            | **50**     | **51**       |   **877.8 μs** | **16.41 μs** | **14.55 μs** |   **876.9 μs** | **1.9531** |   **9.66 KB** |
| HasAccessSearchQuery | 50     | 51       | 3,274.2 μs | 58.61 μs | 54.82 μs | 3,250.3 μs | 3.9063 |  17.22 KB |