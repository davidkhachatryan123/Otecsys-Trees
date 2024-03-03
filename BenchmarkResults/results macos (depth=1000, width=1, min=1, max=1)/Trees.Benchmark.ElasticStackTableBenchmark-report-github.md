```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **1000**   | **1**        | **541.0 μs** | **32.71 μs** | **93.86 μs** | **3.9063** |  **31.98 KB** |
| **HasAccess** | **2**      | **1**        | **542.3 μs** | **27.42 μs** | **77.78 μs** | **0.9766** |   **8.94 KB** |
