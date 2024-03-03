```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev    | Median   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|----------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **679.8 μs** | **35.50 μs** | **100.72 μs** | **651.2 μs** |      **-** |   **8.75 KB** |
| **HasAccess** | **1000**   | **1**        | **644.7 μs** | **23.18 μs** |  **64.23 μs** | **631.7 μs** | **0.9766** |   **8.71 KB** |
