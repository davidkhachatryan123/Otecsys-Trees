```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **1873**   | **1**        | **374.4 μs** | **16.80 μs** | **49.01 μs** | **0.9766** |  **10.77 KB** |
| **HasAccess** | **2**      | **1**        | **416.2 μs** | **20.18 μs** | **57.59 μs** | **0.9766** |   **8.84 KB** |
