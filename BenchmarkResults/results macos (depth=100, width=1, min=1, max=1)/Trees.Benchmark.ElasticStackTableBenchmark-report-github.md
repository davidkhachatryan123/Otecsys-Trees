```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.2.1 (23C71) [Darwin 23.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method               | nodeId | parentId | Mean       | Error     | StdDev    | Gen0   | Allocated |
|--------------------- |------- |--------- |-----------:|----------:|----------:|-------:|----------:|
| **HasAccess**            | **100**    | **1**        |   **401.1 μs** |  **15.38 μs** |  **44.87 μs** | **0.9766** |  **11.02 KB** |
| HasAccessSearchQuery | 100    | 1        | 1,195.4 μs |  81.25 μs | 239.57 μs | 1.9531 |  18.09 KB |
| **HasAccess**            | **100**    | **50**       |   **404.0 μs** |  **13.98 μs** |  **41.01 μs** | **0.9766** |  **11.02 KB** |
| HasAccessSearchQuery | 100    | 50       | 1,538.9 μs |  77.71 μs | 225.45 μs |      - |  18.22 KB |
| **HasAccess**            | **100**    | **99**       |   **414.3 μs** |  **11.94 μs** |  **34.64 μs** | **1.4648** |  **11.02 KB** |
| HasAccessSearchQuery | 100    | 99       | 1,427.6 μs |  75.06 μs | 218.95 μs |      - |  18.22 KB |
| **HasAccess**            | **2**      | **1**        |   **416.6 μs** |  **12.92 μs** |  **37.89 μs** | **1.4648** |   **9.77 KB** |
| HasAccessSearchQuery | 2      | 1        | 1,151.6 μs |  57.38 μs | 168.30 μs | 1.9531 |  18.09 KB |
| **HasAccess**            | **50**     | **51**       |   **443.5 μs** |  **12.87 μs** |  **37.54 μs** | **0.9766** |  **10.41 KB** |
| HasAccessSearchQuery | 50     | 51       | 1,506.7 μs | 106.79 μs | 306.39 μs |      - |  18.23 KB |
