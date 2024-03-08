```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.3.1 (23D60) [Darwin 23.3.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method         | nodeId | parentId | Mean     | Error     | StdDev    | Median   | Allocated |
|--------------- |------- |--------- |---------:|----------:|----------:|---------:|----------:|
| **HasAccessAsync** | **2**      | **1**        | **1.442 ms** | **0.0314 ms** | **0.0915 ms** | **1.412 ms** |   **3.78 KB** |
| **HasAccessAsync** | **500**    | **1**        | **1.423 ms** | **0.0266 ms** | **0.0611 ms** | **1.419 ms** |   **3.79 KB** |
| **HasAccessAsync** | **1000**   | **1**        | **1.430 ms** | **0.0285 ms** | **0.0627 ms** | **1.423 ms** |   **3.81 KB** |
| **HasAccessAsync** | **1000**   | **509**      | **1.381 ms** | **0.0257 ms** | **0.0228 ms** | **1.382 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1500**   | **1**        | **1.422 ms** | **0.0279 ms** | **0.0525 ms** | **1.423 ms** |   **3.81 KB** |
| **HasAccessAsync** | **1500**   | **1021**     | **1.360 ms** | **0.0206 ms** | **0.0161 ms** | **1.359 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1**        | **1.419 ms** | **0.0277 ms** | **0.0447 ms** | **1.418 ms** |   **3.81 KB** |
| **HasAccessAsync** | **1673**   | **509**      | **1.384 ms** | **0.0498 ms** | **0.1451 ms** | **1.407 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1021**     | **1.246 ms** | **0.0563 ms** | **0.1660 ms** | **1.251 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1499**     | **1.134 ms** | **0.0245 ms** | **0.0699 ms** | **1.122 ms** |   **3.82 KB** |
| **HasAccessAsync** | **1673**   | **1649**     | **1.149 ms** | **0.0229 ms** | **0.0376 ms** | **1.144 ms** |   **3.82 KB** |
