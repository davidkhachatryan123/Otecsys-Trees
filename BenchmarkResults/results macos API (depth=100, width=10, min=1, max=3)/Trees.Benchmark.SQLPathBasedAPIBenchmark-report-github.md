```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.3.1 (23D60) [Darwin 23.3.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method         | nodeId | parentId | Mean     | Error     | StdDev    | Median   | Allocated |
|--------------- |------- |--------- |---------:|----------:|----------:|---------:|----------:|
| **HasAccessAsync** | **2**      | **1**        | **1.069 ms** | **0.0207 ms** | **0.0316 ms** | **1.059 ms** |   **3.78 KB** |
| **HasAccessAsync** | **500**    | **1**        | **1.210 ms** | **0.0548 ms** | **0.1615 ms** | **1.141 ms** |   **3.79 KB** |
| **HasAccessAsync** | **1000**   | **1**        | **1.177 ms** | **0.0464 ms** | **0.1332 ms** | **1.108 ms** |   **3.81 KB** |
| **HasAccessAsync** | **1000**   | **509**      | **1.055 ms** | **0.0206 ms** | **0.0193 ms** | **1.047 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1500**   | **1**        | **1.248 ms** | **0.0612 ms** | **0.1796 ms** | **1.335 ms** |    **3.8 KB** |
| **HasAccessAsync** | **1500**   | **1021**     | **1.234 ms** | **0.0642 ms** | **0.1894 ms** | **1.152 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1**        | **1.079 ms** | **0.0213 ms** | **0.0511 ms** | **1.065 ms** |    **3.8 KB** |
| **HasAccessAsync** | **1673**   | **509**      | **1.448 ms** | **0.0424 ms** | **0.1224 ms** | **1.460 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1021**     | **1.495 ms** | **0.0293 ms** | **0.0513 ms** | **1.477 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1499**     | **1.425 ms** | **0.0547 ms** | **0.1603 ms** | **1.478 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1649**     | **1.496 ms** | **0.0297 ms** | **0.0600 ms** | **1.468 ms** |   **3.82 KB** |
