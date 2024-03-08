```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.3.1 (23D60) [Darwin 23.3.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method         | nodeId | parentId | Mean     | Error    | StdDev   | Allocated |
|--------------- |------- |--------- |---------:|---------:|---------:|----------:|
| **HasAccessAsync** | **1000**   | **1**        | **511.1 μs** | **12.06 μs** | **35.55 μs** |   **3.81 KB** |
| **HasAccessAsync** | **1000**   | **509**      | **506.0 μs** | **12.53 μs** | **36.96 μs** |   **3.82 KB** |
| **HasAccessAsync** | **1500**   | **1**        | **513.1 μs** | **12.05 μs** | **35.53 μs** |   **3.81 KB** |
| **HasAccessAsync** | **1500**   | **1021**     | **543.1 μs** | **12.82 μs** | **37.19 μs** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1**        | **549.5 μs** | **13.20 μs** | **38.91 μs** |   **3.81 KB** |
| **HasAccessAsync** | **1673**   | **1021**     | **552.3 μs** | **13.32 μs** | **39.27 μs** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1499**     | **555.2 μs** | **12.06 μs** | **35.56 μs** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1649**     | **557.6 μs** | **13.09 μs** | **38.61 μs** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **509**      | **560.5 μs** | **12.09 μs** | **34.89 μs** |   **3.82 KB** |
| **HasAccessAsync** | **2**      | **1**        | **571.6 μs** | **11.53 μs** | **34.01 μs** |   **3.78 KB** |
| **HasAccessAsync** | **500**    | **1**        | **585.1 μs** | **11.68 μs** | **32.36 μs** |   **3.79 KB** |