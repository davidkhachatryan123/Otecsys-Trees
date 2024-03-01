```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **2**      | **1**        | **591.7 μs** | **11.79 μs** | **28.48 μs** | **0.9766** |   **8.71 KB** |
| **HasAccess** | **50**     | **51**       | **582.0 μs** | **11.53 μs** | **23.03 μs** | **0.9766** |   **8.71 KB** |
| **HasAccess** | **100**    | **1**        | **658.7 μs** | **29.47 μs** | **82.15 μs** | **0.9766** |   **8.71 KB** |
| **HasAccess** | **100**    | **50**       | **603.9 μs** | **13.75 μs** | **39.45 μs** | **0.9766** |   **8.71 KB** |
| **HasAccess** | **100**    | **99**       | **617.7 μs** | **15.69 μs** | **44.50 μs** | **0.9766** |   **8.71 KB** |
