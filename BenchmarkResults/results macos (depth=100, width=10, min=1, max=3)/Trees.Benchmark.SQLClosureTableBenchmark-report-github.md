```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **613.3 μs** | **20.55 μs** | **57.97 μs** | **595.6 μs** | **0.9766** |   **8.71 KB** |
| **HasAccess** | **1873**   | **1**        | **576.3 μs** | **11.44 μs** | **30.92 μs** | **563.7 μs** | **0.9766** |   **8.71 KB** |
