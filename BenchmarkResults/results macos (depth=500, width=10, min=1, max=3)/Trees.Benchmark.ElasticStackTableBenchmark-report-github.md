```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **427.2 μs** | **17.07 μs** | **49.26 μs** |      **-** |   **9.07 KB** |
| **HasAccess** | **9873**   | **1**        | **447.2 μs** | **15.34 μs** | **44.51 μs** | **2.9297** |  **18.32 KB** |
