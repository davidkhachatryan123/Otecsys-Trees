```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **556.9 μs** | **10.32 μs** | **26.83 μs** | **547.8 μs** | **0.9766** |   **8.71 KB** |
| **HasAccess** | **9873**   | **1**        | **557.7 μs** | **10.50 μs** | **19.21 μs** | **555.5 μs** | **0.9766** |   **8.71 KB** |
