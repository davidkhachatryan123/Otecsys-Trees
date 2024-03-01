```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **596.4 μs** | **17.67 μs** | **48.36 μs** | **580.6 μs** | **0.9766** |    **8.8 KB** |
| **HasAccess** | **1873**   | **1**        | **584.5 μs** | **11.65 μs** | **33.24 μs** | **574.2 μs** | **0.9766** |   **9.63 KB** |
