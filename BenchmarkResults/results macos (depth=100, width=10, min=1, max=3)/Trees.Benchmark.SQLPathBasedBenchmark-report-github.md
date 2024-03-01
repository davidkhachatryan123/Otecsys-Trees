```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method           | nodeId | parentId | Mean     | Error    | StdDev   | Gen0   | Allocated |
|----------------- |------- |--------- |---------:|---------:|---------:|-------:|----------:|
| **HasAccess**        | **2**      | **1**        | **637.0 μs** | **12.60 μs** | **23.97 μs** | **1.9531** |  **13.09 KB** |
| HasAccessOnlySQL | 2      | 1        | 645.6 μs | 12.73 μs | 19.05 μs | 1.9531 |  14.03 KB |
| **HasAccess**        | **1905**   | **1**        | **659.0 μs** | **13.11 μs** | **36.75 μs** | **1.9531** |  **13.99 KB** |
| HasAccessOnlySQL | 1905   | 1        | 637.7 μs | 12.64 μs | 11.83 μs | 1.9531 |  14.68 KB |
