```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method    | nodeId | parentId | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------- |------- |--------- |---------:|---------:|---------:|-------:|----------:|
| **HasAccess** | **100**    | **1**        | **389.1 μs** | **19.49 μs** | **56.22 μs** | **0.9766** |  **10.19 KB** |
| **HasAccess** | **100**    | **50**       | **391.0 μs** | **11.13 μs** | **32.12 μs** | **1.4648** |  **10.13 KB** |
| **HasAccess** | **100**    | **99**       | **417.6 μs** | **13.08 μs** | **37.95 μs** | **1.4648** |  **10.13 KB** |
| **HasAccess** | **2**      | **1**        | **431.3 μs** | **13.79 μs** | **39.79 μs** | **0.9766** |   **8.88 KB** |
| **HasAccess** | **50**     | **51**       | **421.5 μs** | **12.84 μs** | **37.25 μs** | **1.4648** |   **9.52 KB** |
