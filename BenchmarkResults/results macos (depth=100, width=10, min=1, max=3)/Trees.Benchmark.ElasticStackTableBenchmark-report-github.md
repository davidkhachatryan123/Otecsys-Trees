```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method               | nodeId | parentId | Mean       | Error    | StdDev    | Gen0   | Allocated |
|--------------------- |------- |--------- |-----------:|---------:|----------:|-------:|----------:|
| **HasAccess**            | **1905**   | **1**        |   **423.4 μs** | **13.97 μs** |  **40.76 μs** | **0.9766** |  **11.59 KB** |
| HasAccessSearchQuery | 1905   | 1        | 1,300.0 μs | 87.57 μs | 252.66 μs |      - |  18.22 KB |
| **HasAccess**            | **2**      | **1**        |   **412.7 μs** | **11.24 μs** |  **32.80 μs** | **1.4648** |   **9.77 KB** |
| HasAccessSearchQuery | 2      | 1        | 1,173.6 μs | 58.69 μs | 172.13 μs | 1.9531 |  18.09 KB |
